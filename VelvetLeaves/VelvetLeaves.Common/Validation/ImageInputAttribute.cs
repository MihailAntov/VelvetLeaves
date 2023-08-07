

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Common.Validation
{
    public class ImageInputAttribute : ValidationAttribute
    {
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private readonly Dictionary<string, byte[]> expectedSignatures = new Dictionary<string, byte[]>
        {
            {".jpg",new byte[]{ 0xFF, 0xD8, 0xFF, 0xE0 } },
            {".jpeg",new byte[]{ 0xFF, 0xD8, 0xFF, 0xE0 } },
            {".png", new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } }
        };



        private readonly int maxFileSizeBytes = 10 * 1024 * 1024; // 10MB

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is IEnumerable<IFormFile> files)
            {

                foreach (var file in files)
                {

                    // Verify the file extension
                    if (!IsValidExtension(file.FileName))
                    {
                        return new ValidationResult("Invalid file format.Only JPG, JPEG, PNG, and GIF are allowed.");
                    }

                    // Perform signature validation
                    if (!IsValidSignature(file))
                    {
                        return new ValidationResult("Invalid file signature.");
                    }

                    // Check the file size
                    if (file.Length > maxFileSizeBytes)
                    {
                        return new ValidationResult("File size exceeds the maximum allowed limit.");
                    }


                }

            }
            else if (value != null && value is IFormFile file)
            {
                if (!IsValidExtension(file.FileName))
                {
                    return new ValidationResult("Invalid file format.Only JPG, JPEG, PNG, and GIF are allowed.");
                }

                // Perform signature validation
                if (!IsValidSignature(file))
                {
                    return new ValidationResult("Invalid file signature.");
                }

                // Check the file size
                if (file.Length > maxFileSizeBytes)
                {
                    return new ValidationResult("File size exceeds the maximum allowed limit.");
                }
            }

            // Always return success since we have updated the value
            return ValidationResult.Success;
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
                if (!expectedSignatures.ContainsKey(extension))
                {
                    return false;
                }

                byte[] buffer = new byte[expectedSignatures[extension].Length];
                stream.Read(buffer, 0, expectedSignatures[extension].Length);

                // Compare the read bytes with the expected signature
                return buffer.SequenceEqual(expectedSignatures[extension]);
            }
        }
    }
}
