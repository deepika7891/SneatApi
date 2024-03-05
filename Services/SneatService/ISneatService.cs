using SneatAPI.Entity;
using SneatAPI.Model;

namespace SneatAPI.Services.SneatService
{
    public interface ISneatService
    {
        Task<List<SneatEntity>> GetAll();

        Task<List<SneatEntity>> AddData(Sneat sneat);

        Task<SneatEntity> Delete(string name);
    }
}
