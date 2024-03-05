using Microsoft.EntityFrameworkCore;
using SneatAPI.Entity;
using SneatAPI.Entity.Register;

namespace SneatAPI.DataContext
{
    public class SneatContext : DbContext
    {
        public SneatContext(DbContextOptions<SneatContext> options): base(options)
        {
            
        }
         
        public DbSet<SneatEntity> SneatEntities { get; set; }

        public DbSet<AdminSneatEntity> AdminSneat { get; set; }

        public DbSet<RegisterEntity> RegisterEntities { get; set; }

        public DbSet<loginEntity> loginEntities { get; set; }
    }
}
