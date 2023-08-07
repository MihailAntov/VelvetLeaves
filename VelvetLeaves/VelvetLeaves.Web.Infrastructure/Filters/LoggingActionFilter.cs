

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace VelvetLeaves.Web.Infrastructure.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger logger;
        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "Action {0} in controller {1} executed at {2}";
            int code;
            DateTime time = DateTime.UtcNow;
            string action = filterContext.ActionDescriptor.DisplayName;
            string controller = filterContext.Controller.GetType().Name;

            if (filterContext.Exception == null && filterContext.Result != null)
            {
                code = 2000;
            }
            else if (filterContext.Result == null)
            {
                code = 2001;
                message = "Action {0} in controller {1} executed at {2} and returned null";
                logger.LogWarning(code, message, action, controller, time);
                return;
            }
            else
            {
                code = 2002;
                
                message = "Action {0} in controller {1} executed at {2} and threw exception {3}";
                Exception? exception = filterContext.Exception;
                logger.LogError(code, message, action, controller, time, exception);
                return;
            }

            


            logger.LogInformation(code, message, action, controller, time);

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message = "Action {0} in controller {1} hit by user {2} at {3}";
            int code = 0;

            

            if(filterContext.HttpContext.Request.Method == "GET")
            {
                code = 1000;
            }else if (filterContext.HttpContext.Request.Method == "POST")
            {
                code = 1001;
            }

            string userId = filterContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            DateTime time = DateTime.UtcNow;
            string action = filterContext.ActionDescriptor.DisplayName;
            string controller = filterContext.Controller.GetType().Name;


            logger.LogInformation(code, message, action, controller, userId, time);
        }
    }
}
