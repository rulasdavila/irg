using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace irgAlumnos
{
    using Helpers;
    using irg.Common.Models;
    using Services;
    using Views;
    using Xamarin.Forms;
    
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //LoadVersion();
            MainPage = new NavigationPage(new LoginPage());
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

        private async void LoadVersion()
        {
            ApiService apiService = new ApiService();

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                Application.Current.Resources["VersionServidor"] = "0.0";
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlVersionController"].ToString();

            var response = await apiService.GetList<AppSoyRena>(url, prefix, $"{controller}?descripcion=SoyRenaAlumnos", false);

            if (!response.IsSuccess)
            {
                Application.Current.Resources["VersionServidor"] = "0.0";
                return;
            }

            var list = (AppSoyRena)response.Result;

            Application.Current.Resources["VersionServidor"] = list.version;
        }
    }
}