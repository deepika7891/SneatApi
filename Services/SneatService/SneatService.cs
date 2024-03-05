using Microsoft.EntityFrameworkCore;
using SneatAPI.DataContext;
using SneatAPI.Entity;
using SneatAPI.Model;

namespace SneatAPI.Services.SneatService
{
    public class SneatService : ISneatService
    {
        private readonly SneatContext _sneatContext;

        public SneatService(SneatContext sneatContext)
        {
            _sneatContext = sneatContext;
        }

        public async Task<List<SneatEntity>> GetAll()
        {
            var data = await _sneatContext.SneatEntities.ToListAsync();
            return data;
        }

        public async Task<List<SneatEntity>> AddData(Sneat sneat)
        {
            var alldata = new SneatEntity
            {
                FullName = sneat.FullName,
                Email = sneat.Email,
                PhoneNumber = sneat.PhoneNumber,
                State = sneat.State,
                Country = sneat.Country,
                CompanyName = sneat.CompanyName,
            };

            _sneatContext.SneatEntities.Add(alldata);
            await _sneatContext.SaveChangesAsync();
            return await _sneatContext.SneatEntities.ToListAsync();
        }

        public async Task<SneatEntity> Delete(string name)
        {
            var delete = await _sneatContext.SneatEntities.FirstOrDefaultAsync(e => e.FullName == name);

            if (delete != null)
            {
                _sneatContext.SneatEntities.Remove(delete);
                await _sneatContext.SaveChangesAsync();
            }

            return delete;
        }
    }
}
