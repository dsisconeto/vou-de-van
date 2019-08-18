using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;

namespace Storage
{
    public class AzureStorage : Storage, IStorage
    {
        private readonly CloudBlobClient _cloudBlobClient;

        public AzureStorage(CloudBlobClient cloudBlobClient)
        {
            _cloudBlobClient = cloudBlobClient;
        }

        protected override async Task<string> CopyFileTo(string containerName, string fileName, IFormFile file)
        {
            var container = await MakeContainer(containerName);
            var cloudBlockBlob = container.GetBlockBlobReference(fileName);

            using (var stream = file.OpenReadStream())
            {
                await cloudBlockBlob.UploadFromStreamAsync(stream);
            }

            return cloudBlockBlob.Uri.ToString();
        }


        private async Task<CloudBlobContainer> MakeContainer(string containerName)
        {
            var cloudBlobContainer = _cloudBlobClient.GetContainerReference(containerName);

            if (await cloudBlobContainer.CreateIfNotExistsAsync() == false)
            {
                return cloudBlobContainer;
            }


            var permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            };

            await cloudBlobContainer.SetPermissionsAsync(permissions);


            return cloudBlobContainer;
        }
    }
}