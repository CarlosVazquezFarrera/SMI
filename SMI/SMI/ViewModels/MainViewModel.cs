namespace SMI.ViewModels
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.Helpers;
    using SMI.Infrastructure.BL;
    using SMI.Models;
    using SMI.OS;
    using SMI.OS.Keys;
    using System.Windows.Input;
    public class MainViewModel: ViewModelBase
    {
        #region Constructor
        public MainViewModel()
        {
        }
        #endregion

        #region Attributes
        private bool mantenerSesion;
        private readonly Response response = new Response();
        private Empleado empleado = new Empleado();
        LoginBL bl = new LoginBL();
        #endregion

        #region Properties
        /// <summary>
        /// Define si el usuario ha habilitado la opción de mantener su sesipon abierta
        /// </summary>
        public bool MantenerSesion
        {
            get { return this.mantenerSesion; }
            set { 
                Set(ref this.mantenerSesion, value);
                Configuracion.MantenerSesion = value;
            }
        }
        public Empleado Empleado
        {
            get { return this.empleado; }
            set { Set(ref this.empleado, value); }
        }
        #endregion

        #region Comands
        public ICommand LoginComand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #endregion

        #region Methos
        private async void Login()
        {
            IsValidate();
            if (response.Exito)
            {
                await PopUp.PushPopUp(PopUpKeys.Cargando, "Iniciando sesión");
                var response = await bl.Login(empleado);
                if (response.Exito)
                {
                    await Navigation.NavigateTo(PagesKeys.RootTabbed);
                    await PopUp.PopAllPopUps();
                }
                else
                {
                    await PopUp.PopAllPopUps();
                    await PopUp.PushPopUp(PopUpKeys.Mensaje, response.Mensaje);
                }

            }
            else
            {
                await PopUp.PushPopUp(PopUpKeys.Mensaje, response.Mensaje);
            }
            await PopUp.PushPopUp(PopUpKeys.Mensaje);
        }

        private Response IsValidate()
        {
            if (string.IsNullOrEmpty(Empleado.Email))
            {
                response.Mensaje = "Debe ingresar un usuario";
                return response;
            }
            if (string.IsNullOrEmpty(Empleado.Password))
            {
                response.Mensaje = "Debe ingresar una contraseña";
                return response;
            }
            response.Exito = true;
            return response;
        }

        #endregion
    }
}
