using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAllianceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        bool authenticated = false;
        public LogIn()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool authenticated = false;
            if (App.Authenticator != null)

                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
                await Navigation.PushAsync(new LandingPage());
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            if (authenticated == true)
            {
                // Set syncItems to true in order to synchronize the data
                // on startup when running in offline mode.
                //await RefreshItems(true, syncItems: false);

                // Hide the Sign-in button.
                this.loginButton.IsVisible = false;
            }

            // Set syncItems to true in order to synchronize the data on startup when running in offline mode



        }
    }
}
