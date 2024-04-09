using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly NntmContext _ntmContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;


        public FeedbackService(NntmContext ntmContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _ntmContext = ntmContext;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }


        public async Task<ApiResult<string>> createFeedback(FeedbackView feedbackView)
        {
            var feedback = new Feedback();
            feedback.Id = Guid.NewGuid();
            feedback.content = feedbackView.Content;
            feedback.CreatedAt = DateTime.Now;
            feedback.TopicFeedbackId = Guid.Parse(feedbackView.TopicFeedbackId);
            feedback.TypeFeedbackId = Guid.Parse(feedbackView.TypeFeedbackId);
            feedback.UserId = Guid.Parse(feedbackView.UserId);
            await _ntmContext.Feedbacks.AddAsync(feedback);
            await _ntmContext.SaveChangesAsync();

            return new ApiSuccessResult<string>("");
        }

        public async Task<ApiResult<List<TopicFeedbackView>>> getAllTopic()
        {
            var list = await _ntmContext.TopicFeedbacks.ToListAsync();
            var result = new List<TopicFeedbackView>();
            foreach (var item in list)
            {
                var topic = _mapper.Map<TopicFeedbackView>(item);
                result.Add(topic);
            }
            return new ApiSuccessResult<List<TopicFeedbackView>>(result);

        }
         
        public async Task<ApiResult<List<TypeFeedbackView>>> getAllType()
        {
            var list = await _ntmContext.TypeFeedbacks.ToListAsync();
            var result = new List<TypeFeedbackView>();
            foreach (var item in list)
            {
                var type = _mapper.Map<TypeFeedbackView>(item);
                result.Add(type);
            }
            return new ApiSuccessResult<List<TypeFeedbackView>>(result);

        }




    }
}
