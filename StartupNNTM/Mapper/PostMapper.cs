using AutoMapper;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper() {
            CreateMap<PostVm, Post>()
                .ForMember(dest => dest.Address,opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<Post, PostView>()
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
            CreateMap<Image, ImageVm>()
                .ReverseMap();
        }
    }
}
