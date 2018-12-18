namespace irgDocentes.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using irg.Common.Models;
    using Helpers;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class VersionViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<AppSoyRena> version;
        public bool isRefreshing;

        public ObservableCollection<AppSoyRena> Version
        {
            get { return this.version; }
            set { this.SetValue(ref this.version, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public VersionViewModel()
        {
            this.apiService = new ApiService();
            this.LoadVersion();
        }

        private async void LoadVersion()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlVersionController"].ToString();
            var response = await this.apiService.GetList<Pagos>(url, prefix, controller);

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            var list = (List<AppSoyRena>)response.Result;
            this.Version = new ObservableCollection<AppSoyRena>(list);
            
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadVersion);
            }
        }
    }
}
