namespace SneatAPI.Services.uploadImage
{
    public class UploadeService : IUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;


        public UploadeService(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }



        public async Task<string> UploadFile(IFormFile formFile)
        {
            try
            {
                if (formFile is not null && formFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath ?? "wwwroot", "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    Directory.CreateDirectory(uploadsFolder);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }


                    // Construct and return the URL
                    var baseUrl = _webHostEnvironment.WebRootPath ?? "wwwroot";
                    var relativePath = Path.Combine("uploads", uniqueFileName).Replace("\\", "/");
                    var imageUrl = Path.Combine(baseUrl, relativePath);

                    return imageUrl;
                }
                else
                {
                    return "Error: Invalid file.";
                }
            }
            catch (Exception ex)
            {
                return $"Error: Internal server error - {ex.Message}";
            }      
        }
        
    }
}
