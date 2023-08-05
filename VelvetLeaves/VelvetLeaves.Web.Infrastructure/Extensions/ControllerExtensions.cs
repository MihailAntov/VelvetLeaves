

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.Web.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static void LogActivity(this ControllerBase controller, ILogger logger)
        {
            string message = $"{controller.GetType().Name} visited at {DateTime.UtcNow}";
            logger.LogTrace(message);
        }
    }
}
