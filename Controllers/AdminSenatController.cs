using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using SneatAPI.DataContext;
using SneatAPI.Entity;
using SneatAPI.Model;
using SneatAPI.Services.uploadImage;
using SneatAPI.Services.Admin;

namespace SneatAPI.Controllers
{

    [Route("api/AdminSneat")]
    [ApiController]
    public class AdminSenatController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IUploadService _uploadService;

        public AdminSenatController(IAdminService adminService,IUploadService uploadService)
        {
            this._adminService = adminService;
            this._uploadService = uploadService;
        }

        [HttpPost("AddAdmin")]
        public async Task<ActionResult<List<SneatEntity>>> AddAdmin([FromForm] AdminSneat adminSneat)
        {
            
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }

            if (adminSneat.ImageFile != null)
            {
                string fileResult = await _uploadService.UploadFile(adminSneat.ImageFile);

                if (fileResult.StartsWith("Error"))
                {
                    // Handle the case where file upload fails
                    status.StatusCode = 0;
                    status.Message = "Error uploading file: " + fileResult;
                }
                else
                {
                    adminSneat.PicturePath = Path.GetFileName(fileResult); // Set PicturePath to the uniqueFileName

                    var admin = await _adminService.AddAdmin(adminSneat);

                    if (admin != null)
                    {
                        status.StatusCode = 1;
                        status.Message = "Added successfully";
                        status.ImageUrl = fileResult; // Include image URL in the response
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error on adding product";
                    }
                }
            }



            return Ok(status);
        }
    }
}
