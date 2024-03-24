using AutoMapper;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper() {
            CreateMap<PostVm, Post>().ForMember(dest => dest.Images,opt => opt.Ignore());
                }
    }
}
