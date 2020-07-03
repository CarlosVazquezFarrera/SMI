namespace SMI.ViewModels
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.OS;
    using System.Windows.Input;
    public class MainViewModel: ViewModelBase
    {
        #region Constructor
        public MainViewModel()
        {
            this.IsRunning = true;
        }
        #endregion

        #region Attributes
        private string message;
        private bool isRunning;
        #endregion

        #region Properties
        public bool IsRunning 
        {
            get { return this.isRunning; }
            set { Set(ref isRunning, value); } 
        }

        public string Message
        {
            get { return this.message; }
            set { Set(ref message, value); }
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
        private  void Login()
        {
            Message += "Hola";
            IsRunning = !IsRunning;
            //await Navigation.NavigateTo(PagesKeys.Inicio);
        }
        #endregion
    }
}
