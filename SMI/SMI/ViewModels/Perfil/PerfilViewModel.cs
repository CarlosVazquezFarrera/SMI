namespace SMI.ViewModels.Perfil
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.OS;
    using SMI.OS.Keys;
    using System.Windows.Input;

    public class PerfilViewModel: ViewModelBase
    {

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
        #endregion

        #region Methods

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
        #endregion
    }
}
