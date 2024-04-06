using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public interface IUserService
    {
        Task<ApiResult<string>> GetImage(string request);

        Task<ApiResult<UserViewModel>> GetUserDetail(string email);

        Task<ApiResult<string>> SetImageUser(string name, IFormFile image);

        Task<ApiResult<UserViewModel>> Update(UserViewUpdate request);


    }
}
