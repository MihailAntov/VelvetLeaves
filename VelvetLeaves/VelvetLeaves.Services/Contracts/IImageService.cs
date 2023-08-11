

using Microsoft.AspNetCore.Http;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Services.Contracts
{
    public interface IImageService
    {

        public  Task<string?> GetAsync(string id);

        public  Task<string?> CreateAsync(IFormFile content);
        public Task<IEnumerable<string?>> CreateRangeAsync(IEnumerable<IFormFile> files);
        public Task<VelvetLeaves.Data.ObjectDatabase.Image> CreateFromStringAsync(string id, string content);

        public  Task UpdateAsync(string id, IFormFile content);

        public  Task<bool> RemoveAsync(string id);

        public Task<bool> ExistsByIdAsync(string id);
    }
}
