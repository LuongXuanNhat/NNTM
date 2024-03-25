
using StartupNNTM.ViewModels;

namespace StartupNNTM.Service
{
    public interface IPostService
    {
        Task<ApiResult<string>> CreatePost(PostVm post);
        Task<ApiResult<List<PostView>>> GetAll();
        Task<ApiResult<PostView>> GetDetail(string id);
        Task<ApiResult<List<Models.Type>>> GetTypes();

    }
}
