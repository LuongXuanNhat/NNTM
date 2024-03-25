using StartupNNTM.Models;
using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public interface IAddressService
    {
        Task<ApiResult<List<ProvinceViewModel>>> GetAll();
        Task<ApiResult<List<DistrictViewModel>>> GetAllDistrict(string provincesId);
        Task<ApiResult<List<WardViewModel>>> GetAllWard(string districtId);
        Task<ApiResult<Guid>> AddAddress(AddressVm address);
        Task<ApiResult<List<DistrictViewModel>>> GetDistrictsById(string provincesId);
        Task<ApiResult<List<WardViewModel>>> GetWardsById(string districtId);
    }
}
