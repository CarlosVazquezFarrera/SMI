namespace SMI.ViewModels.Inicio
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.Helpers;
    using SMI.Models;
    using SMI.OS;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class InicioViewModel: ViewModelBase
    {
        public InicioViewModel()
        {
            Empleados = new ObservableCollection<Empleado> { 
                new Empleado { Nombre = "Juan" },
                new Empleado { Nombre = "Carlos" },
                new Empleado { Nombre = "Fernando" },
                new Empleado { Nombre = "Carolina" },
                new Empleado { Nombre = "Hernesto" },
                new Empleado { Nombre = "Maria" },
                new Empleado { Nombre = "Rosa" },
                new Empleado { Nombre = "Pablo" },
                };
        }


        private string nombre;
        public string Nombre
        {
            get { return this.nombre; }
            set { Set(ref this.nombre, value); }
        }

        private ObservableCollection<Empleado> empleados;
        public ObservableCollection<Empleado> Empleados
        {
            get { return this.empleados; }
            set { Set(ref this.empleados, value); }
        }



        public ICommand MostrarCommand
        {
            get
            {
                return new RelayCommand<Empleado>(Mostrar);
            }
        }
        private void Mostrar(Empleado empleado)
        {
            Nombre = empleado.Nombre;
        }


        public ICommand CerrarSesionCommand
        {
            get
            {
                return new RelayCommand(CerrarSesion);
            }
        }
        private async void CerrarSesion()
        {
            Configuracion.MantenerSesion = false;
            await Navigation.NavigateTo(PagesKeys.Login);
        }


    }
}
