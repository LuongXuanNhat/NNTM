using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;
using System.Text;

namespace StartupNNTM.Service
{
    public class UserService : IUserService
    {
        private readonly IImageService _image;
        public readonly ILogger<UserService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly NntmContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IAddressService _address;



        public UserService(NntmContext context, ILogger<UserService> logger,
       IAddressService address,
        UserManager<User> userManager,
        IMapper mapper,

        IImageService image
            )
        {
            _logger = logger;
            _image = image;
            _userManager = userManager;
            _dataContext = context;
            _mapper = mapper;
            _address = address;
        }

        public async Task<ApiResult<UserViewModel>> GetUserDetail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var address = _dataContext.Address.AsQueryable();

            if (user == null)
                return new ApiErrorResult<UserViewModel>("Lỗi");

            user.Address = await address
           .Where(x => x.Id.Equals(user.AddressId))
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
            var userDetail = _mapper.Map<UserViewModel>(user);
            return new ApiSuccessResult<UserViewModel>(userDetail);
        }

        public async Task<ApiResult<string>> GetImage(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return new ApiSuccessResult<string>(_image.ConvertByteArrayToString(user.Image, Encoding.UTF8));
        }

        public async Task<ApiResult<string>> SetImageUser(string name, IFormFile image)
        {
            var user = await _userManager.FindByNameAsync(name);
            user.Image = await _image.ConvertFormFileToByteArray(image);
            _dataContext.User.Update(user);
            await _dataContext.SaveChangesAsync();
            return new ApiSuccessResult<string>("Cập nhập ảnh đại diện thành công");
        }


        public async Task<ApiResult<UserViewModel>> Update(UserViewUpdate request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            var address = await _address.AddAddress(request.AddressVm);

            user.PhoneNumber = request.PhoneNumber;
            user.DateOfBirth = request.DateOfBirth;
            user.Gender = request.Gender;
            user.AddressId = address.ResultObj;
            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                var address1 = _dataContext.Address.AsQueryable();

                user.Address = await address1.Where(x => x.Id.Equals(user.AddressId))
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
                var userDetail = _mapper.Map<UserViewModel>(user);
                return new ApiSuccessResult<UserViewModel>(userDetail);

            }
            else
            {
                return new ApiErrorResult<UserViewModel>("Lỗi khi cập nhật thông tin người dùng");
            }
        }





    }
}
