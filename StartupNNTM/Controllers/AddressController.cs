using Microsoft.AspNetCore.Mvc;
using StartupNNTM.Service;

namespace StartupNNTM.Controllers
{

    [Route("")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;


        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("Province")]
        public async Task<IActionResult> GetProvinces()
        {
            var reuslt = await _addressService.GetAll();
            return Ok(reuslt);
        }

        [HttpGet("District")]
        public async Task<IActionResult> GetDistricts(string provincesId)
        {
            var reuslt = await _addressService.GetAllDistrict(provincesId);
            return Ok(reuslt);
        }

        [HttpGet("GetDistrictsById")]
        public async Task<IActionResult> GetDistrictById(string provincesId)
        {
            var reuslt = await _addressService.GetDistrictsById(provincesId);
            return Ok(reuslt);
        }

        [HttpGet("Ward")]
        public async Task<IActionResult> GetWards(string districtId)
        {
            var reuslt = await _addressService.GetAllWard(districtId);
            return Ok(reuslt);
        }

        [HttpGet("GetWardsById")]
        public async Task<IActionResult> GetWardById(string districtId)
        {
            var reuslt = await _addressService.GetWardsById(districtId);
            return Ok(reuslt);
        }
    }
}
