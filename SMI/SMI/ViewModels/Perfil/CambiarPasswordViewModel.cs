namespace SMI.ViewModels.Perfil
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using SMI.OS;
    using System.Windows.Input;

    public class CambiarPasswordViewModel: ViewModelBase
    {

        public ICommand AtrasCommand
        {
            get
            {
                return new RelayCommand(Atras);
            }
        }
        private async void Atras()
        {
            await Navigation.GoBack();
        }

    }
}
