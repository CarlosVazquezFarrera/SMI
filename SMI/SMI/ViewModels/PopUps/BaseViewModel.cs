namespace SMI.ViewModels.PopUps
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.OS;
    using System.Windows.Input;

    public class BaseViewModel : ViewModelBase
    {
        #region Comands
        public ICommand CerrarPopUpCommand
        {
            get
            {
                return new RelayCommand(CerrarPopUp);
            }
        }
        #endregion

        #region Methos
        private async void CerrarPopUp()
        {
            await PopUp.PopAllPopUps();
        } 
        #endregion

    }
}
