namespace SMI.ViewModels.Inicio
{
    using GalaSoft.MvvmLight;
    using SMI.Infrastructure.BL;
    using SMI.Models;
    using System;
    using System.Collections.ObjectModel;

    public class PendientesViewModel: ViewModelBase
    {
        
        public PendientesViewModel()
        {
           
        }

        private ObservableCollection<WeatherForecast> lista;
        public ObservableCollection<WeatherForecast> Lista
        {
            get { return this.lista; }
            set { Set(ref this.lista, value); }
        }
    }
}
