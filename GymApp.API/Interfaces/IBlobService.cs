namespace GymApp.API.Interfaces
{
    public interface IBlobService
    {
        Task<string> GetBlob(string name, string containerName);

        Task<IEnumerable<string>> GetAllBlobs(string containerName);

        Task<bool> UploadBlob(string name, IFormFile file, string containerName);

        Task<bool> DeleteBlobAsync(string name, string containerName);
    }
}
