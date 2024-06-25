using Azure.Storage.Blobs;
using ClaimsAPI.Models;

namespace ClaimsApi.Helpers
{
    public static class FileHelper
    {

        public static async Task<string> UploadFiles(MemoryStream memoryStream,string FileName)
        {
          
            string containerName = "musicgroup";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(FileName);

          
            //todo: take base64 string as param and conver to stream
            //then following code will work
           
            memoryStream.Position = 0;

            //uploading file stream to azure blob
            await blobClient.UploadAsync(memoryStream);
            //retrieving file uri

            return blobClient.Uri.AbsoluteUri;

        }

       






    }





}
