using GalaSoft.MvvmLight.Command;
using SMI.Helpers.Funciones;
using SMI.OS;
using System.Windows.Input;
using Xamarin.Forms;

namespace SMI.ViewModels.PopUps
{
    public class CambiarFotoViewModel: BaseViewModel
    {
        private ImageSource Foto;

        #region Commands
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
        /// <summary>
        /// Quita la foto de perfil
        /// </summary>
        public ICommand QuitarImagenCommand
        {
            get
            {
                return new RelayCommand(QuitarImagen);
            }
        }
        #endregion

        #region Methods
        private async void TomarFoto()
        {
            var response = await Camara.TomarFoto();
            if (response.Exito)
            {
                string dataFoto = response.Data.ToString();
                Foto = Converter.ConvertBase64ToImageSource(dataFoto);
                EnviarImagen();
                await PopUp.PopAllPopUps();
            }
        }
        private async void AbriGaleria()
        {
            var response = await Camara.AbriGaleria();

            if (response.Exito)
            {
                string dataFoto = response.Data.ToString();
                Foto = Converter.ConvertBase64ToImageSource(dataFoto);
                EnviarImagen();
                await PopUp.PopAllPopUps();
            }
        }
        private async void QuitarImagen()
        {
            // if (!string.IsNullOrEmpty(Configuracion.FotoDePerfil))
            //{
            Foto = "fotoBase.png";
            EnviarImagen();
            //Igualar la foto de configuraciones a string en blanco
            //}
            await PopUp.PopAllPopUps();
        } 

        private void EnviarImagen()
        {
            MessagingCenter.Send<ImageSource>(Foto, "enviarFoto");
        }
        #endregion
    }
}
