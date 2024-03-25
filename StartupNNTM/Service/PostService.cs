using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupNNTM.Migrations;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StartupNNTM.Service
{
    public class PostService : IPostService
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly NntmContext _dataContext;
        private readonly IImageService _image;
        private readonly IMapper _mapper;
        private readonly IAddressService _address;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PostService(UserManager<User> userManager, IImageService image, NntmContext nntmContext, IMapper mapper, 
            IWebHostEnvironment hostEnvironment, IAddressService address)
        {
            _userManager = userManager;
            _dataContext = nntmContext;
            _image = image;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _address = address;
        }

        public async Task<ApiResult<string>> CreatePost(PostVm post)
        {

            var postItem = _mapper.Map<Post>(post);
            postItem.Id = SanitizeString(post.Title) + DateTime.Now.ToString("-HHmmss");
            var address = await _address.AddAddress(post.AddressVm);
            
            postItem.AddressId = address.ResultObj;
            await _dataContext.Posts.AddAsync(postItem);
            await _dataContext.SaveChangesAsync();

            await _image.AddImage(post.Images, postItem.Id);
            

            return new ApiSuccessResult<string>(postItem.Id);
        }

        private string SanitizeString(string title)
        {
            string withoutDiacritics = RemoveDiacritics(title).ToLower().Trim();
            withoutDiacritics = ReplaceVietnameseChars(withoutDiacritics); // Thay đổi vị trí của hàm này
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"\s+", "-");
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"-{2,}", "-");
            string sanitizedString = Regex.Replace(withoutDiacritics, @"[^a-z0-9-]", "");

            return sanitizedString;
        }

        private string RemoveDiacritics(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        private string ReplaceVietnameseChars(string input)
        {
            input = input.Replace("ư", "u")
                    .Replace("ô", "o").Replace("ơ", "o")
                    .Replace("đ", "d").Replace("ê", "e")
                    .Replace("â", "a").Replace("ă", "a");
            return input;
        }
        public async Task<ApiResult<List<Models.Type>>> GetTypes()
        {
            var types = await _dataContext.Types.ToListAsync();
            return new ApiSuccessResult<List<Models.Type>>(types);
        }

        private async Task<List<Image>> SaveImagesAsync(string postId, IEnumerable<IFormFile> images)
        {
            var savedImages = new List<Image>();
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");

            foreach (var imageFile in images)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    var image = new Image
                    {
                        Url = uniqueFileName,
                        PostId = postId
                    };

                    _dataContext.Images.Add(image);
                    savedImages.Add(image);
                }
            }

            return savedImages;
        }

        public async Task<ApiResult<List<PostView>>> GetAll()
        {
            var images =  _dataContext.Images.AsQueryable();
            var address =  _dataContext.Address.AsQueryable();
            var products = await _dataContext.Posts.ToListAsync();
            foreach (var item in products)
            {
                item.Images = await images
                    .Where(x=>x.PostId.Equals(item.Id))
                    .Select(x => new Image { Id = x.Id, Url = x.Url, PostId = x.PostId })
                    .ToListAsync();
                item.Address = await address
                    .Where(x => x.Id.Equals(item.AddressId))
                    .Include(a => a.Province)
                    .Include(a => a.District)
                    .Include(a => a.Ward)
                    .Select(x => new Address
                    {
                        Id = x.Id,
                        Detail = x.Detail,
                        DistrictId = x.DistrictId,
                        ProvinceId = x.ProvinceId,
                        WardId = x.WardId,
                        Province = new Province { Id = x.Province.Id, FullName = x.Province.FullName },
                        District = new District { Id = x.District.Id, FullName = x.District.FullName },
                        Ward = new Ward { Id = x.Ward.Id, FullName = x.Ward.FullName }
                    })
                    .FirstAsync();
            }

            var result = _mapper.Map<List<PostView>>(products);

            return new ApiSuccessResult<List<PostView>>(result);
        }

        public async Task<ApiResult<PostView>> GetDetail(string id)
        {
            var product = await _dataContext.Posts.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return new ApiSuccessResult<PostView>(_mapper.Map<PostView>(product));
        }
    }
}
