

using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace VelvetLeaves.Web.Infrastructure.Filters
{
    public class StringResourceFilter : IAsyncResourceFilter
    {
        private readonly IHtmlSanitizer _sanitizer;
        public StringResourceFilter(IHtmlSanitizer sanitizer)
        {
            _sanitizer = sanitizer;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context.HttpContext.Request.HasFormContentType)
            {
                var form = await context.HttpContext.Request.ReadFormAsync();

                var htmlSanitizer = context.HttpContext.RequestServices.GetRequiredService<IHtmlSanitizer>();

                var sanitizedForm = SanitizeFormHtml(form, htmlSanitizer);

                context.HttpContext.Request.Form = sanitizedForm;
            }

            await next();
        }


        private IFormCollection SanitizeFormHtml(IFormCollection form, IHtmlSanitizer htmlSanitizer)
        {
            var sanitizedValuesDictionary = new Dictionary<string, StringValues>();
            foreach (var key in form.Keys)
            {
                var originalValue = form[key];
                var sanitizedValues = originalValue.Select(value => htmlSanitizer.Sanitize(value));

                sanitizedValuesDictionary[key] = new StringValues(sanitizedValues.ToArray());
            }

            return new FormCollection(sanitizedValuesDictionary);
        }
    }
}
