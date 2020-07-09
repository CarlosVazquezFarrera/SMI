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
        private PerfilViewModel()
        {
            Foto = string.IsNullOrEmpty(Configuracion.FotoDePerfil) ? "fotoBase.png" : Converter.ConvertBase64ToImageSource(Configuracion.FotoDePerfil);   
        }
        #endregion

        #region Atributo
        private static PerfilViewModel instancia;

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
        /// <summary>
        ///  Abre la galería para seleccionar una foto
        /// </summary>
        public ICommand AbriGaleriaCommand
        {
            get
            {
                return new RelayCommand(AbriGaleria);
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
            if (response.Result)
            {
                string dataFoto = response.Data.ToString();
                Foto = Converter.ConvertBase64ToImageSource(dataFoto);
                await PopUp.PopAllPopUps();
            }
        }
        private async void AbriGaleria()
        {
            var response = await Camara.AbriGaleria();

            if (response.Result)
            {
                string dataFoto = response.Data.ToString();
                Foto = Converter.ConvertBase64ToImageSource(dataFoto);
                await PopUp.PopAllPopUps();
            }
        }

        #endregion
    }
}
