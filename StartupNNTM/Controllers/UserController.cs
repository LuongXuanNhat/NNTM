using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartupNNTM.Service;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Controllers
{

    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserDetail()
        {
            var result = await _userService.GetUserDetail(User.Identity.Name);
            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }


        [HttpGet("Image")]
        [Authorize]
        public async Task<IActionResult> GetImage()
        {
            var result = await _userService.GetImage(User.Identity.Name);
            return result.IsSuccessed ? Ok(result.ResultObj) : BadRequest(result.Message);
        }

        [HttpPost("Image")]
        [Authorize]
        public async Task<IActionResult> SetImage(IFormFile image)
        {
            var result = await _userService.SetImageUser(User.Identity.Name, image);
            return result.IsSuccessed ? Ok(result.ResultObj) : BadRequest(result.Message);
        }


        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UserViewUpdate request)
        {
            var result = await _userService.Update(request);
            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }






    }
}
