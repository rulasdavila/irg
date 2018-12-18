namespace irgDocentes.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using irg.Common.Models;
    using irgDocentes.Helpers;
    using irgDocentes.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PagosViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Pagos> pagos;
        public bool isRefreshing;

        public ObservableCollection<Pagos> Pagos
        {
            get { return this.pagos; }
            set { this.SetValue(ref this.pagos, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public PagosViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPagos();
        }

        private async void LoadPagos()
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
            var controller = Application.Current.Resources["UrlPagosController"].ToString();
            var response = await this.apiService.GetList<Pagos>(url, prefix, controller);

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            var list = (List<Pagos>)response.Result;
            this.Pagos = new ObservableCollection<Pagos>(list);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPagos);
            }
        }
    }
}
