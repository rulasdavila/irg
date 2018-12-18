namespace irgAlumnos.ViewModels
{
    public class MainViewModel
    {
        public PagosViewModel Pagos { get; set; }
        public AppSoyRenaViewModel Version { get; set; }
        public LoginViewModel Login { get; set; }

        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
    }
}
