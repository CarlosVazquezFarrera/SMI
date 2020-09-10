namespace SMI
{
    using SMI.Helpers;
    using SMI.Views;
    using Xamarin.Forms;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = (Configuracion.MantenerSesion) ? new NavigationPage(new RootTabbed()) : new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
