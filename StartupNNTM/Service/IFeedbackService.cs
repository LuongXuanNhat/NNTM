using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public interface IFeedbackService 
    {

        Task<ApiResult<string>> createFeedback(FeedbackView feedbackView);

        Task<ApiResult<List<TopicFeedbackView>>> getAllTopic();
        Task<ApiResult<List<TypeFeedbackView>>> getAllType();

    }
}
