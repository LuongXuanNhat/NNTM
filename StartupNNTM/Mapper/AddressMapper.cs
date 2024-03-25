using AutoMapper;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Mapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<ProvinceViewModel, Province>().ReverseMap();
            CreateMap<District, DistrictViewModel>().ReverseMap();
            CreateMap<Ward, WardViewModel>().ReverseMap();
            CreateMap<Address, AddressVm>().ReverseMap();
            CreateMap<Address, AddressView>().ReverseMap();
        }
    }
}
