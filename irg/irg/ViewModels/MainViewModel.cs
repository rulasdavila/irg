namespace irg.ViewModels
{
    public class MainViewModel
    {
        public PagosViewModel Pagos { get; set; }

        public MainViewModel()
        {
            this.Pagos = new PagosViewModel();
        }
    }
}
