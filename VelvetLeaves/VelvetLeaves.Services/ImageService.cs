
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IList<string>> WriteToDisk(IFormFile file, string fileName)
        {
            

            string wwwPath = _hostingEnvironment.WebRootPath;
            //string contentPath = _hostingEnvironment.ContentRootPath;
            IList<string> result = new List<string>();  
            string path = Path.Combine(wwwPath, "Img");

            string[] permittedExtensions = { ".jpg", ".png" };

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                return result;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullFileName = fileName + ext;

            using (FileStream stream = new FileStream(Path.Combine(path,fullFileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);

                result.Add(fullFileName);
            }

            return result;


        }
    }
}
