namespace SMI.ViewModels.Inicio
{
    using GalaSoft.MvvmLight;
    using SMI.Infrastructure.BL;
    using SMI.Models;
    using System;
    using System.Collections.ObjectModel;

    public class PendientesViewModel: ViewModelBase
    {
        LoginBL bl = new LoginBL();
        public PendientesViewModel()
        {
            cargar();
        }

        private async void cargar()
        {
            var listaBl = await bl.Login();
            Lista = new ObservableCollection<WeatherForecast>(listaBl);
        }

        private ObservableCollection<WeatherForecast> lista;
        public ObservableCollection<WeatherForecast> Lista
        {
            get { return this.lista; }
            set { Set(ref this.lista, value); }
        }
    }
}
