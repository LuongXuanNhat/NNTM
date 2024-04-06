using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StartupNNTM.Models;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;

namespace StartupNNTM.Service
{
    public class ImageService : IImageService
    {
        private const string USER_CONTENT_FOLDER_NAME = "Images";
        private readonly string URL = SystemConstants.UrlWeb;
        private readonly string _userContentFolder;
        private readonly NntmContext _dataContext;
        public ImageService(IWebHostEnvironment webHostEnvironment, NntmContext dataContext)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
            _dataContext = dataContext;
        }

        public async Task AddImage(IFormFileCollection files, string postId)
        {
            foreach (var img in files)
            {
                var url = await SaveFile(img);
                var image = new Models.Image
                {
                    Url = url,
                    PostId = postId
                };
                await _dataContext.Images.AddAsync(image);
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(output);
            return URL + "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }


        public async Task<byte[]> ConvertFormFileToByteArray(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public string ConvertByteArrayToString(byte[]? byteArray, Encoding encoding)
        {
            return byteArray is not null ? Convert.ToBase64String(byteArray) : string.Empty;
        }



       /* public async Task DeleteChangedImagesByPostId(string postId, List<IFormFile> newImages)
        {
            // Tìm tất cả các hình ảnh thuộc về bài đăng có postId tương ứng
            var existingImages = await _dataContext.Images.Where(img => img.PostId == postId).ToListAsync();

            // Duyệt qua danh sách các hình ảnh cũ
            foreach (var existingImage in existingImages)
            {
                // Kiểm tra xem hình ảnh cũ có tồn tại trong danh sách hình ảnh mới hay không
                var isImageChanged = newImages.Any(newImage => Path.GetFileName(newImage.FileName) == Path.GetFileName(existingImage.Url));

                // Nếu hình ảnh cũ không tồn tại trong danh sách hình ảnh mới, xoá hình ảnh cũ
                if (!isImageChanged)
                {
                    var filePath = Path.Combine(_userContentFolder, Path.GetFileName(existingImage.Url));

                    // Xoá hình ảnh từ thư mục
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    // Xoá hình ảnh từ cơ sở dữ liệu
                    _dataContext.Images.Remove(existingImage);
                }
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            await _dataContext.SaveChangesAsync();
        }
*/




    }
}
