namespace irgDocentes.ViewModels
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
