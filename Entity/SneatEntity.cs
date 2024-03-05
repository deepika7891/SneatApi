namespace SneatAPI.Entity
{
    public class SneatEntity
    {
        public Guid Id { get; set; }

        public String FullName { get; set; } = string.Empty;

        public String Email { get; set; } = string.Empty;

        public String PhoneNumber { get; set; } = string.Empty;

        public String State { get; set; } = string.Empty;

        public String Country { get; set; } = string.Empty;

        public String CompanyName { get; set; } = string.Empty;
    }
}
