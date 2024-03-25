using System.Text;

namespace StartupNNTM.Service
{
    public interface IImageService
    {
        Task AddImage(ICollection<IFormFile> files, string postId);
        Task<string> SaveFile(IFormFile file);
    }
}
