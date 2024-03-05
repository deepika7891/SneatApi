using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SneatAPI.Entity.Register
{
    public class loginEntity
    {
        [Key]

        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
