using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.Storage.Auth;
using XamarinAllianceApp.Controllers;
using XamarinAllianceApp.Services;

namespace XamarinAllianceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        private ImageService imageMobileService;
        private GuidService guidService;

        public LandingPage()
        {
            InitializeComponent();
            imageMobileService = new ImageService();
            guidService = new GuidService();
        }

        private async void imageBtn_Clicked(object sender, EventArgs e)
        {

            await DiplayImage();

        }

        private async void charactersBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterListPage());
        }


        private async Task DiplayImage()
        {

            var imageStream = await imageMobileService.GetImageAsync();
            imageStream.Seek(0, System.IO.SeekOrigin.Begin);
            imageStream.Position = 0;
            this.imageArea.Source = ImageSource.FromStream(() => imageStream);
            imageArea.IsVisible = true;

        }

        private async Task guidBtn_Clicked(object sender, EventArgs e)
        {
            var guid= await guidService.GetGuidAsync();
            guidLabel.Text = "DIPLOMA GUID:" + guid;
        }
    }



}
