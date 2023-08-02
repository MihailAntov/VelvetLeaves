

using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class HelperService : IHelperService
    {
        public async Task<string> Currency()
        {
            return "лв.";
        }
    }
}
