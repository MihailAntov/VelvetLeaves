
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

        public async Task<IList<string>> WriteToDisk(IFormFile file)
        {
            

            string wwwPath = _hostingEnvironment.WebRootPath;
            //string contentPath = _hostingEnvironment.ContentRootPath;
            IList<string> result = new List<string>();  
            string path = Path.Combine(wwwPath, "Img");


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetRandomFileName();

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);

                result.Add(Path.Combine(path, fileName));
            }

            return result;


        }
    }
}
