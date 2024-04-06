using System.Text;

namespace StartupNNTM.Service
{
    public interface IImageService
    {
        Task AddImage(IFormFileCollection files, string postId);
        //Task DeleteChangedImagesByPostId(string postId,List<IFor>)
        Task<string> SaveFile(IFormFile file);
        Task<byte[]> ConvertFormFileToByteArray(IFormFile formFile);

        string ConvertByteArrayToString(byte[]? byteArray, Encoding encoding);



    }
}
