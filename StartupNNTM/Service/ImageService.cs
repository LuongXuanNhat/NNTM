using Microsoft.AspNetCore.Hosting;
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

        public async Task AddImage(ICollection<IFormFile> files, string postId)
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
    }
}
