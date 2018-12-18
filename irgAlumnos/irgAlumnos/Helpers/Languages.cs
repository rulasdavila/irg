namespace irgAlumnos.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string NoInternet
        {
            get { return Resource.NoInternet; }
        }

        public static string Pays
        {
            get { return Resource.Pays; }
        }
        
        public static string TurnOnInternet
        {
            get { return Resource.TurnOnInternet; }
        }

        public static string NoServidor
        {
            get { return Resource.NoServidor; }
        }

        public static string Version
        {
            get { return Resource.Version; }
        }

        public static string UserError
        {
            get { return Resource.UserError; }
        }

        public static string PasswordError
        {
            get { return Resource.PasswordError; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string LoginButton
        {
            get { return Resource.LoginButton; }
        }

        public static string VersionError
        {
            get { return Resource.VersionError; }
        }
    }
}
