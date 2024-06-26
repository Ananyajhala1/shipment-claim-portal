using Azure.Storage.Blobs;
using ClaimsAPI.Models;

namespace ClaimsApi.Helpers
{
    public static class FileHelper
    {

        public static async Task<string> UploadFiles(MemoryStream memoryStream,string FileName)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicstrgacc;AccountKey=qXECSVkO9xXDf0zkvQZ86zBNz7misCqaNAX0ph+vMImbVR0+gcN3Iq8Udn5eZZprhuED5dsI1q2i+AStjrKawA==;EndpointSuffix=core.windows.net";

            string containerName = "musicgroup";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(FileName);

           //removed azue conncation 
            //todo: take base64 string as param and conver to stream
            //then following code will work
           
            memoryStream.Position = 0;

            //uploading file stream to azure blob
            await blobClient.UploadAsync(memoryStream);

            //await blobClient.DownloadContentAsync();

            //retrieving file uri

            return blobClient.Uri.AbsoluteUri;

        }

        public static async Task<string> DownloadFiles(string FileName)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=musicstrgacc;AccountKey=qXECSVkO9xXDf0zkvQZ86zBNz7misCqaNAX0ph+vMImbVR0+gcN3Iq8Udn5eZZprhuED5dsI1q2i+AStjrKawA==;EndpointSuffix=core.windows.net";

            string containerName = "musicgroup";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(FileName);



            if (blobClient.ExistsAsync().Result)
            {
                var ms = new MemoryStream();

                blobClient.DownloadTo(ms);
                byte[] data = ms.ToArray();
                string docBase64 = Convert.ToBase64String(data);
                return docBase64;


            }

            else

                return "";
            // returns empty array

        }
        








    }





}
