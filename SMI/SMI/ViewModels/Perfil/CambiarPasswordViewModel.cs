namespace SMI.ViewModels.Perfil
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.Models;
    using SMI.OS;
    using SMI.OS.Keys;
    using System.Windows.Input;

    public class CambiarPasswordViewModel: ViewModelBase
    {
        #region Properties
        private readonly Response<string> response = new Response<string>();
        /// <summary>
        /// Contraseña acual del usuario que ha iniciado sesión
        /// </summary>
        private string passwordActual;
        public string PasswordActual
        {
            get { return this.passwordActual; }
            set { Set(ref this.passwordActual, value); }
        }

        /// <summary>
        /// Nueva contraseña a ingresa
        /// </summary>
        private string passwordNueva;
        public string PasswordNueva
        {
            get { return this.passwordNueva; }
            set { Set(ref this.passwordNueva, value); }
        }

        /// <summary>
        /// Confirmación de la nueva contraseña
        /// </summary>
        private string passwordNuevaConfirmacion;
        public string PasswordNuevaConfirmacion
        {
            get { return this.passwordNuevaConfirmacion; }
            set { Set(ref this.passwordNuevaConfirmacion, value); }
        } 
        #endregion

        #region Commands
        /// <summary>
        /// Comando para regresar a la página anterior
        /// </summary>
        public ICommand AtrasCommand
        {
            get
            {
                return new RelayCommand(Atras);
            }
        }

        /// <summary>
        /// Comando para gatillar el cambio de Password
        /// </summary>
        public ICommand CambiarPasswordCommand
        {
            get
            {
                return new RelayCommand(CambiarPassword);
            }
        }
       

        #endregion

        #region Methods
        private async void Atras()
        {
            await Navigation.GoBack();
        }

        private async void CambiarPassword()
        {
            Validar();
            if (response.Exito)
            {

            }
            else
            {
                await PopUp.PushPopUp(PopUpKeys.Mensaje, response.Mensaje);
            }

        }

        private Response<string> Validar()
        {
            response.Exito = false;
            if (string.IsNullOrEmpty(PasswordActual))
            {
                response.Mensaje = "Ingrese la contraseña actual";
                return response;
            }
            if (string.IsNullOrEmpty(PasswordNueva))
            {
                response.Mensaje = "Ingrese una nueva contraseña";
                return response;
            }
            if (string.IsNullOrEmpty(PasswordNuevaConfirmacion))
            {
                response.Mensaje = "Ingrese la confirmación de la contraseña";
                return response;
            }
            if (!PasswordNueva.Equals(passwordNuevaConfirmacion))
            {
                response.Mensaje = "Las contraseñas no coinciden";
                PasswordNueva = string.Empty;
                PasswordNuevaConfirmacion = string.Empty;
                return response;
            }
            if (PasswordActual.Equals(PasswordNueva))
            {
                response.Mensaje = "La nueva contraseña no debe ser igual a la anterior";
                PasswordNueva = string.Empty;
                PasswordNuevaConfirmacion = string.Empty;
                return response;
            }
            response.Exito = true;
            return response;
        }
        #endregion

    }
}
