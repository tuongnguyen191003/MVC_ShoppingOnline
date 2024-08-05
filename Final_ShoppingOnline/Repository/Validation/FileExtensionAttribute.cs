using System.ComponentModel.DataAnnotations;

namespace Final_ShoppingOnline.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public FileExtensionAttribute(params string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant(); // Chuyển đổi sang chữ thường

                if (!_allowedExtensions.Any(x => extension.EndsWith(x, StringComparison.OrdinalIgnoreCase)))
                {
                    return new ValidationResult($"Allowed extensions are: {string.Join(", ", _allowedExtensions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
