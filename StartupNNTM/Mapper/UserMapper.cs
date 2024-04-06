using AutoMapper;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressView
                {
                    Id = src.Address.Id,
                    ProvinceId = src.Address.ProvinceId,
                    ProvinceName = src.Address.Province.FullName,
                    DistrictId = src.Address.DistrictId,
                    DistrictName = src.Address.District.FullName,
                    WardId = src.Address.WardId,
                    WardName = src.Address.Ward.FullName,
                    Detail = src.Address.Detail
                }))
                .ReverseMap();

            CreateMap<User, UserViewUpdate>().ForMember(dest => dest.AddressVm, opt => opt.MapFrom(src => new AddressView
            {
                Id = src.Address.Id,
                ProvinceId = src.Address.ProvinceId,
                ProvinceName = src.Address.Province.FullName,
                DistrictId = src.Address.DistrictId,
                DistrictName = src.Address.District.FullName,
                WardId = src.Address.WardId,
                WardName = src.Address.Ward.FullName,
                Detail = src.Address.Detail
            }))
                .ReverseMap();



        }

    }
}
