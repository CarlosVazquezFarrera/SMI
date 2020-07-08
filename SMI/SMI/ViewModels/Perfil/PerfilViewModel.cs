namespace SMI.ViewModels.Perfil
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.Helpers.Funciones;
    using SMI.OS;
    using SMI.OS.Keys;
    using System.Windows.Input;

    public class PerfilViewModel: ViewModelBase
    {
        #region Constructor
        private PerfilViewModel()
        {

        }
        #endregion

        #region Atributo
        private static PerfilViewModel instancia; 
        #endregion

        #region Commands
        /// <summary>
        /// Cambia la contraseña del usuario
        /// </summary>
        public ICommand CambiarPasswordCommand
        {
            get
            {
                return new RelayCommand(CambiarPassword);
            }
        }
        /// <summary>
        /// Cierra la sesión actual del usuario
        /// </summary>
        public ICommand CerrarSesionCommand
        {
            get
            {
                return new RelayCommand(CerrarSesion);
            }
        }
        /// <summary>
        /// Cambia la foto de perfil del usuario
        /// </summary>
        public ICommand CambiarFotoCommand
        {
            get
            {
                return new RelayCommand(CambiarFoto);
            }
        }
       /// <summary>
       /// Toma la foto de la cámara
       /// </summary>
        public ICommand TomarFotoCommand
        {
            get
            {
                return new RelayCommand(TomarFoto);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Patron singleton
        /// </summary>
        /// <returns></returns>
        public static PerfilViewModel GetInstance()
        {
            if (instancia == null)
            {
                instancia = new PerfilViewModel();
            }
            return instancia;
        }
        private async void CambiarPassword()
        {
            await Navigation.NavigateTo(PagesKeys.CambiasPassword);
        }

        private async void CerrarSesion()
        {
            await Navigation.NavigateTo(PagesKeys.Login);
        }
        private async void CambiarFoto()
        {
            await PopUp.PushPopUp(PopUpKeys.CambiarFoto);
        }
        private async void TomarFoto()
        {
            var response = await Camara.TomarFoto();
            var foto = response.Data;
            await PopUp.PopAllPopUps();
        }

        #endregion
    }
}
