

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VelvetLeaves.Web.Infrastructure.Filters
{
    public class ImageResourceFilter : IAsyncResourceFilter
    {

        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
        private readonly byte[] expectedSignature = new byte[] { /* Expected signature bytes here */ };
        private readonly int maxFileSizeBytes = 10 * 1024 * 1024; // 10MB
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context.HttpContext.Request.HasFormContentType)
            {
                var form = await context.HttpContext.Request.ReadFormAsync();
                var formFiles = form.Files;

                foreach (var file in formFiles)
                {
                    // Verify the file extension
                    if (!IsValidExtension(file.FileName))
                    {
                        context.ModelState.AddModelError("Image", "Invalid file format. Only JPG, JPEG, PNG, and GIF are allowed.");
                    }

                    // Perform signature validation
                    if (!IsValidSignature(file))
                    {
                        context.ModelState.AddModelError("Image", "Invalid file signature.");
                    }

                    // Check the file size
                    if (file.Length > maxFileSizeBytes)
                    {
                        context.ModelState.AddModelError("Image", "File size exceeds the maximum allowed limit.");
                    }
                }
            }

            // The resource filter is finished processing. Continue to the action.
            var result = await next();
        }

        private bool IsValidExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return allowedExtensions.Contains(extension);
        }

        private bool IsValidSignature(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                // Read the first few bytes of the file to compare with the expected signature
                byte[] buffer = new byte[expectedSignature.Length];
                stream.Read(buffer, 0, expectedSignature.Length);

                // Compare the read bytes with the expected signature
                return buffer.SequenceEqual(expectedSignature);
            }
        }
    }
}
