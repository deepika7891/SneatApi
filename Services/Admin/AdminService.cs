using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneatAPI.DataContext;
using SneatAPI.Entity;
using SneatAPI.Model;

namespace SneatAPI.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly SneatContext _sneatContext;

        public AdminService(SneatContext sneatContext)
        {
            _sneatContext = sneatContext;
        }



        public async Task<AdminSneatEntity> AddAdmin([FromForm] AdminSneat adminSneat)
        {
            var data = new AdminSneatEntity
            {
                FirstName = adminSneat.FirstName,
                LastName = adminSneat.LastName,
                PhoneNo = adminSneat.PhoneNo,
                Address = adminSneat.Address,
                City = adminSneat.City,
                ZipNumber = adminSneat.ZipNumber,
                CompanyName = adminSneat.CompanyName,
                Language = adminSneat.Language,
                PicturePath = adminSneat.PicturePath,
            };

            _sneatContext.AdminSneat.Add(data);
            await _sneatContext.SaveChangesAsync();
            return data;
        }


        //public async Task<List<AdminSneatEntity>> AddAdmin(AdminSenat adminSenat)
        //{
        //    var alldata = new AdminSneatEntity
        //    {
        //        FirstName = adminSenat.FirstName,
        //        LastName = adminSenat.LastName,
        //        PhoneNo = adminSenat.PhoneNo,
        //        Address = adminSenat.Address,
        //        City = adminSenat.City,
        //        ZipNumber = adminSenat.ZipNumber,
        //        CompanyName = adminSenat.CompanyName,
        //        Language = adminSenat.Language,
        //        PicturePath = adminSenat.PicturePath,
        //    };

        //    _sneatContext.AdminSneat.Add(alldata);
        //    await _sneatContext.SaveChangesAsync();
        //    return await _sneatContext.AdminSneat.ToListAsync();
        //}
    }
}
