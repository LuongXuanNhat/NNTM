using System.Text;

namespace StartupNNTM.Service
{
    public class ImageService : IImageService
    {
        public string ConvertByteArrayToString(byte[]? byteArray, Encoding encoding)
        {
            return byteArray is not null ? Convert.ToBase64String(byteArray) : string.Empty;
        }

        public async Task<byte[]> ConvertFormFileToByteArray(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
