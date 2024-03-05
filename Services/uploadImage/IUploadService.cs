namespace SneatAPI.Services.uploadImage
{
    public interface IUploadService
    {
        Task<string> UploadFile(IFormFile formFile);
    }
}
