
namespace GymApp.API.Controllers
{
    using GymApp.API.Interfaces;
    
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService blobService;

        public BlobController(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetBlob()
        {
            return await this.blobService.GetAllBlobs("images");
        }

        [HttpPost]
        public async Task<bool> UploadBlob(IFormFile file)
        {
            if (file == null || file.Length < 1)
            {
                return false;
            }

            var fileName = $"{Guid.NewGuid()} {Path.GetExtension(file.FileName)}";
            var result = await this.blobService.UploadBlob(fileName, file, "images");

            return result ? true : false;
        }

        //[HttpPost]
        //public async Task<bool> DeleteFile(string name)
        //{
        //    return await this.blobService.DeleteBlobAsync(name, "images");
        //}
    }
}
