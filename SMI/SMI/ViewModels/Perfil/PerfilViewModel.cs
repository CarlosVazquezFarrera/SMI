namespace SMI.ViewModels.Perfil
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.Helpers;
    using SMI.Helpers.Funciones;
    using SMI.OS;
    using SMI.OS.Keys;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PerfilViewModel: ViewModelBase
    {
        #region Constructor
        public PerfilViewModel()
        {
            //Mover a holpers despues
            Foto = string.IsNullOrEmpty(Configuracion.FotoDePerfil) ? "fotoBase.png" : Converter.ConvertBase64ToImageSource(Configuracion.FotoDePerfil);
            MessagingCenter.Subscribe<ImageSource>(this, "enviarFoto", (imagen) =>
            {
                Foto = imagen;
            });
        }
        #endregion

        #region Atributo
        private ImageSource foto;
        public ImageSource Foto
        {
            get { return this.foto; }
            set { Set(ref this.foto, value); }
        }
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
        #endregion

        #region Methods
        private async void CambiarPassword()
        {
            await Navigation.NavigateTo(PagesKeys.CambiasPassword);
        }

        private async void CerrarSesion()
        {
            bool respuesta = await PopUp.PushConfirmationPopUp(PopUpKeys.Confirmacion, "¿Seguro que desea cerrar su sesión?");
            if (respuesta)
            {
                Configuracion.MantenerSesion = false;
                await Navigation.NavigateTo(PagesKeys.Login);
            }
            //await Navigation.NavigateTo(PagesKeys.Login);
        }
        private async void CambiarFoto()
        {
            await PopUp.PushPopUp(PopUpKeys.CambiarFoto);
        }
        #endregion
    }
}
