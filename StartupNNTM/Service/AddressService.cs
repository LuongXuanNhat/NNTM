using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StartupNNTM.Models;
using StartupNNTM.ViewModels;
using System.Runtime.InteropServices;

namespace StartupNNTM.Service
{
    public class AddressService : IAddressService
    {

        private readonly NntmContext _dataContext;
        private readonly IMapper _mapper;

        public AddressService(NntmContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public async Task<ApiResult<List<ProvinceViewModel>>> GetAll()
        {
            var provinces = await _dataContext.Districts.ToListAsync();
            var result = new List<ProvinceViewModel>();
            foreach(var item in provinces)
            {
                var province = _mapper.Map<ProvinceViewModel>(item);
                result.Add(province);

            }



            return new ApiSuccessResult<List<ProvinceViewModel>>(result);

        }

      /*  public async Task<ApiResult<ProvinceViewModel>> GetByFindName(string name)
        {

        }
       */



    }
}
