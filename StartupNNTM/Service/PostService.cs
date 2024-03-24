using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Crypto;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public class PostService : IPostService
    {


        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly NntmContext _dataContext;
        private readonly IImageService _image;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PostService(UserManager<User> userManager, IImageService image, NntmContext nntmContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _dataContext = nntmContext;
            _image = image;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<ApiResult<PostVm>> Create(PostVm request, string name, Post post)
        {
            var user = await _userManager.FindByNameAsync(name);

            post.CreatedAt = DateTime.Now;
            post.UserId = user.Id;
            post.TypeId = Guid.Parse(request.TypeId);
            post.Content = request.Content;
            post.Price = request.Price;
            post.Title = request.Title;
            try
            {
                _dataContext.Posts.Add(post);
                await _dataContext.SaveChangesAsync();
                post.Images = await SaveImagesAsync(post.Id, request.Images);

          


             }
            catch (Exception ex)
            {

            }

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





    }
}
