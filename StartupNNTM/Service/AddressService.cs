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

        public async Task<ApiResult<Guid>> AddAddress(AddressVm address)
        {
            Address item = _mapper.Map<Address>(address);
            item.Id = Guid.NewGuid();
            await _dataContext.Address.AddAsync(item);
            await _dataContext.SaveChangesAsync();
            return new ApiSuccessResult<Guid>(item.Id);
        }

        public async Task<ApiResult<List<ProvinceViewModel>>> GetAll()
        {
            var provinces = await _dataContext.Provinces.ToListAsync();
            var result = new List<ProvinceViewModel>();
            foreach(var item in provinces)
            {
                var province = _mapper.Map<ProvinceViewModel>(item);
                result.Add(province);

            }
            return new ApiSuccessResult<List<ProvinceViewModel>>(result);

        }

        public async Task<ApiResult<List<DistrictViewModel>>> GetAllDistrict(string provincesId)
        {
            var provinces = await _dataContext.Districts.Where(x => x.ProvinceId.ToString().Equals(provincesId)).ToListAsync();
            var result = new List<DistrictViewModel>();
            foreach (var item in provinces)
            {
                var province = _mapper.Map<DistrictViewModel>(item);
                result.Add(province);

            }
            return new ApiSuccessResult<List<DistrictViewModel>>(result);
        }

        public async Task<ApiResult<List<WardViewModel>>> GetAllWard(string districtId)
        {
            var provinces = await _dataContext.Wards.Where(x=>x.DistrictId.ToString().Equals(districtId)).ToListAsync();
            var result = new List<WardViewModel>();
            foreach (var item in provinces)
            {
                var province = _mapper.Map<WardViewModel>(item);
                result.Add(province);

            }
            return new ApiSuccessResult<List<WardViewModel>>(result);
        }

        public async Task<ApiResult<List<DistrictViewModel>>> GetDistrictsById(string provincesId)
        {
            var districts = await _dataContext.Districts.Where(x => x.ProvinceId == int.Parse(provincesId)).ToListAsync();
            return new ApiSuccessResult<List<DistrictViewModel>>(_mapper.Map<List<DistrictViewModel>>(districts));
        }

        public async Task<ApiResult<List<WardViewModel>>> GetWardsById(string districtId)
        {
            var wards = await _dataContext.Wards.Where(x => x.DistrictId == int.Parse(districtId)).ToListAsync();
            return new ApiSuccessResult<List<WardViewModel>>(_mapper.Map<List<WardViewModel>>(wards));
        }
    }
}
