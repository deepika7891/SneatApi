using Microsoft.AspNetCore.Mvc;
using SneatAPI.Entity;
using SneatAPI.Model;
using SneatAPI.Services.SneatService;

namespace SneatAPI.Controllers
{
    [Route("api/Senat")]
    [ApiController]
    public class SneatController : Controller
    {
        private readonly ISneatService _sneatService;

        public SneatController(ISneatService sneatService)
        {
            _sneatService = sneatService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SneatEntity>>> GetAll()
        {
            return await _sneatService.GetAll();
        }

        [HttpPost("AddSneat")]
        public async Task<ActionResult<List<SneatEntity>>> AddData(Sneat sneat)
        {
            try
            {
                var result = await _sneatService.AddData(sneat);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle the exception or return a specific error response
                return StatusCode(500, $"data is no added {ex}");
            }
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<SneatEntity>> Delete(string name)
        {
            var deleted = await _sneatService.Delete(name);

            if (deleted == null)
            {
                return NotFound(); // Return 404 if the entity with the given ID is not found.
            }

            return Ok("delete successfully");
        }
    }
}
