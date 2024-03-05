using Microsoft.AspNetCore.Mvc;
using SneatAPI.Entity;
using SneatAPI.Model;

namespace SneatAPI.Services.Admin
{
    public interface IAdminService
    {
        //Task<List<AdminSneatEntity>> AddAdmin(AdminSenat adminSenat);

        Task<AdminSneatEntity> AddAdmin(AdminSneat adminSneat);
    }
}
