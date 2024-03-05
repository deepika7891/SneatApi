using System.ComponentModel.DataAnnotations.Schema;

namespace SneatAPI.Entity
{
    public class AdminSneatEntity
    {
        public Guid Id { get; set; } 

        public String? FirstName { get; set; } 
        public String? LastName { get; set; } 
        public String? PhoneNo { get; set; } 
        public string? Address { get; set; } 
        public string? City { get; set; } 
        public string? ZipNumber { get; set; } 
        public string? CompanyName { get; set; } 
        public string? Language { get; set; } 
        public string? PicturePath { get; set; } 

        [NotMapped]
        public IFormFile? ImageFile { get; set; } 

    }
}
