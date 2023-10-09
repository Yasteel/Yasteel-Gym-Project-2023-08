namespace GymApp.API.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;

    using GymApp.API.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobClient;

        public BlobService(BlobServiceClient blobClient)
        {
            this.blobClient = blobClient;
        }
        public async Task<IEnumerable<string>> GetAllBlobs(string containerName)
        {
            // allows to access data in container
            var containerClient = this.blobClient.GetBlobContainerClient(containerName);
            var files = new List<string>();
            var blobs = containerClient.GetBlobsAsync();

            await foreach(var blob in blobs)
            {
                files.Add(blob.Name);
            }

            return files;
        }

        public async Task<string> GetBlob(string name, string containerName)
        {
            var containerClient = this.blobClient.GetBlobContainerClient(containerName);
            var blob = containerClient.GetBlobClient(name);

            return blob.Uri.AbsoluteUri;
        }
        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            var containerClient = this.blobClient.GetBlobContainerClient(containerName);

            // check if file exists in container
            // if exists -> file will be replaced
            // if !exists -> temp file will be created
            var blobClient = containerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            return result != null;
        }

        public async Task<bool> DeleteBlobAsync(string name, string containerName)
        {
            var containerClient = this.blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
