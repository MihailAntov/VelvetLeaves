

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VelvetLeaves.Web.Infrastructure.Filters
{
    public class ImageResourceFilter : IAsyncResourceFilter
    {

        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private readonly Dictionary<string, byte[]> expectedSignatures = new Dictionary<string, byte[]>
        {
            {".jpg",new byte[]{ 0xFF, 0xD8, 0xFF, 0xE0 } },
            {".jpeg",new byte[]{ 0xFF, 0xD8, 0xFF, 0xE0 } },
            {".png", new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } }
        };
        
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
            await next();
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
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                byte[] buffer = new byte[expectedSignatures[extension].Length];
                stream.Read(buffer, 0, expectedSignatures[extension].Length);

                // Compare the read bytes with the expected signature
                return buffer.SequenceEqual(expectedSignatures[extension]);
            }
        }
    }
}
