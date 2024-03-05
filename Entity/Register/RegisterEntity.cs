using System.ComponentModel.DataAnnotations;

namespace SneatAPI.Entity.Register
{
    public class RegisterEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
