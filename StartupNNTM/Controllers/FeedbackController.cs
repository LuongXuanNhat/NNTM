using Microsoft.AspNetCore.Mvc;
using StartupNNTM.Service;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Controllers
{


    [ApiController]
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("Create")]
        //[Authorize]
        public async Task<IActionResult> CreateFeedback(FeedbackView feedbackView)
        {
            var result = await _feedbackService.createFeedback(feedbackView);
            return Ok(result);
        }


        [HttpGet("Topic")]
        public async Task<IActionResult> GetTopic()
        {
            var reuslt = await _feedbackService.getAllTopic();
            return Ok(reuslt);
        }

        [HttpGet("Type")]
        public async Task<IActionResult> GetType()
        {
            var reuslt = await _feedbackService.getAllType();
            return Ok(reuslt);
        }


    }
}
