using System.Text;

namespace StartupNNTM.Service
{
    public interface IImageService
    {
        Task AddImage(IFormFileCollection files, string postId);
        Task<string> SaveFile(IFormFile file);
    }
}
