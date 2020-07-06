namespace SMI.ViewModels
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.Helpers;
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
            await Navigation.NavigateTo(PagesKeys.RootTabbed);
            //await PopUp.PushPopUp(PopUpKeys.Mensaje);
        }
        #endregion
    }
}
