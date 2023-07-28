

using Microsoft.AspNetCore.Http;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Services.Contracts
{
    public interface IImageService
    {
        //public Task<IList<string>> WriteToDisk(IFormFile file, string fileName);
        public Task<List<string>> GetAllAsync();

        public  Task<string?> GetAsync(string id);

        public  Task<string?> CreateAsync(IFormFile content);
        public Task<IEnumerable<string?>> CreateRangeAsync(IEnumerable<IFormFile> files);
        public Task CreateFromStringAsync(string id, string content);

        public  Task UpdateAsync(string id, IFormFile content);

        public  Task RemoveAsync(string id);
    }
}
