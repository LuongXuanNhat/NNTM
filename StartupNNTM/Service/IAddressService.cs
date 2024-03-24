using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public interface IAddressService
    {
        Task<ApiResult<List<ProvinceViewModel>>> GetAll();
    }
}
