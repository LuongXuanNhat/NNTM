using Microsoft.AspNetCore.Mvc;
using StartupNNTM.Service;

namespace StartupNNTM.Controllers
{

    [Route("Address")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;


        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("Province")]
        public async Task<IActionResult> Index()
        {
            var reuslt = await _addressService.GetAll();
            return reuslt is null ? BadRequest(reuslt) : Ok(reuslt);
        }

    }
}
