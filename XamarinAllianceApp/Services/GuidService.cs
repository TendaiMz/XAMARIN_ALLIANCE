using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAllianceApp.Helpers;

namespace XamarinAllianceApp.Services
{
    class GuidService
    {
        MobileServiceClient _client { get; set; }
        public GuidService()
        {
            _client = new MobileServiceClient(Constants.mobileServiceClientUrl);
        }

     
        public async Task<String> GetGuidAsync()
        {
            var guid = await _client.InvokeApiAsync("/api/XamarinAlliance/ReceiveCredit");
            return guid.ToString();
        }
        
    }
}
