namespace SMI
{
    using SMI.Helpers;
    using SMI.Views.Inicio;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = (Configuracion.MantenerSesion) ? new NavigationPage(new InicioPage()) : new NavigationPage(new MainPage());
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
