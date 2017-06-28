using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAllianceApp.Helpers;

namespace XamarinAllianceApp.Services
{
    public  class ImageService
    {
        MobileServiceClient _client { get; set; }
        public ImageService()
        {
            _client = new MobileServiceClient(Constants.mobileServiceClientUrl);
        }
        public async Task<MemoryStream> GetImageAsync()
        {


            var token = await _client.InvokeApiAsync("/api/StorageToken/CreateToken");

            string storageAccountName = "xamarinalliance";

            StorageCredentials credentials = new StorageCredentials(token.ToString());

            CloudStorageAccount account = new CloudStorageAccount(credentials, storageAccountName, null, true);

            var client1 = account.CreateCloudBlobClient();

            var container = client1.GetContainerReference("images");
            var blob = container.GetBlobReference("XAMARIN-Alliance-logo.png");

            MemoryStream stream = new MemoryStream();

            await blob.DownloadToStreamAsync(stream);
            return stream;

        }
    }
}
