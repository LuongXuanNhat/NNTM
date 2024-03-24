using System.Text;

namespace StartupNNTM.Service
{
    public interface IImageService
    {
        Task<byte[]> ConvertFormFileToByteArray(IFormFile formFile);
        string ConvertByteArrayToString(byte[]? byteArray, Encoding encoding);
    }
}
