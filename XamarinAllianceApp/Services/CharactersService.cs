using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAllianceApp.Helpers;
using XamarinAllianceApp.Models;

namespace XamarinAllianceApp.Services
{
    class CharactersService
    {
        MobileServiceClient _client { get; set; }
        public CharactersService()
        {
                       
            _client = new MobileServiceClient(Constants.mobileServiceClientUrl);
        }

        public async Task<ObservableCollection<Character>>  GetCharactersAsync()
        {
            IMobileServiceTable<Character> CharacterTable = _client.GetTable<Character>();
            var characters = await CharacterTable.ToListAsync();
            return new ObservableCollection<Character>(characters);           
        }

       

    }
}
