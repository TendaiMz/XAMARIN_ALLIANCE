using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAllianceApp.Views;

namespace XamarinAllianceApp
{

    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }
    public class App : Application
    {
        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new LogIn());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

