using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartupNNTM.Service;
using StartupNNTM.ViewModels;

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

        [HttpGet("Types")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await _postService.GetTypes());
        }

        [HttpPost("Create")]
        //[Authorize]
        public async Task<IActionResult> CreatePost([FromForm] PostVm post)
        {
            var result = await _postService.CreatePost(post);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postService.GetAll();
            return Ok(result);
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> GetDetail(string id)
        {
            var result = await _postService.GetDetail(id);
            return Ok(result);
        }


    }
}
