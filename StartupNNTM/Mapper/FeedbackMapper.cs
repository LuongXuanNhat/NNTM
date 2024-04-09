using AutoMapper;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Mapper
{
    public class FeedbackMapper : Profile
    {
        public FeedbackMapper() {
          
            CreateMap<Feedback, FeedbackView>().ReverseMap();
            CreateMap<TopicFeedback, TopicFeedbackView>().ReverseMap();
            CreateMap<TypeFeedback,TypeFeedbackView>().ReverseMap();  
         


        }
    }
}
