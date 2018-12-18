namespace irgAlumnos.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using irg.Common.Models;
    using Services;
    using Xamarin.Forms;

    public class LoginViewModel :BaseViewModel
    {
        #region Attributes
        private ApiService apiService { get; set; }
        private bool isUpdate;
        private bool isRunning;
        private bool isEnabled;
        private bool isVisible;
        #endregion

        #region Properties
        public string User { get; set; }
        public string Pass { get; set; }
        public bool IsUpdate
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
        public bool IsRunning
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
        public bool IsVisible
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            apiService = new ApiService();
            LoadVersion();
            this.isEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    Languages.UserError, 
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(Pass))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    Languages.PasswordError, 
                    Languages.Accept);
                return;
            }

            this.isRunning = true;
            this.isEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.isRunning = false;
                this.isEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    connection.Message, 
                    Languages.Accept);
                return;
            }

            //var url = Application.Current.Resources["UrlAPI"].ToString();
            //var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            //var controller = Application.Current.Resources["UrlUsuariosController"].ToString();
            //var response = await this.apiService.GetList<Usuarios>(url, prefix, controller);


            this.isRunning = false;
            this.isEnabled = true;
            isVisible = !isUpdate;
            return;
        }

        private async void LoadVersion()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                isUpdate = false;
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlVersionController"].ToString();

            var response = await apiService.GetList<AppSoyRena>(url, prefix, $"{controller}?descripcion=SoyRenaAlumnos", false);

            if (!response.IsSuccess)
            {
                isUpdate = false;
                return;
            }

            var list = (AppSoyRena)response.Result;

            if (Application.Current.Resources["Version"].ToString() != list.version)
            {
                isUpdate = false;
                return;
            }
            isUpdate = true;
        }
        #endregion
    }
}
