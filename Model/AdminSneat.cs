using System.ComponentModel.DataAnnotations.Schema;

namespace SneatAPI.Model
{
    public class AdminSneat
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNo { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string ZipNumber { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string PicturePath { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
