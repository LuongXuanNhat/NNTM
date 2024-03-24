using Microsoft.AspNetCore.Mvc;
using StartupNNTM.Service;

namespace StartupNNTM.Controllers
{
    [ApiController]
    [Route("Post")]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;

        public PostController(IPostService postService) { 
            _postService = postService;
        }

/*
        [HttpGet("Discover")]
        public async  Task<IActionResult> Index()
        {
        }*/


    }
}
