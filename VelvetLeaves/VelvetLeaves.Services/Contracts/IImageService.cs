

using Microsoft.AspNetCore.Http;

namespace VelvetLeaves.Services.Contracts
{
    public interface IImageService
    {
        public Task<IList<string>> WriteToDisk(IFormFile file);
    }
}
