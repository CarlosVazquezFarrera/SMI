namespace SMI.PopUps
{
    using Rg.Plugins.Popup.Pages;
    using SMI.ViewModels.PopUps;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationPopUp : PopupPage
    {
        public ConfirmationPopUp()
        {
            InitializeComponent();
            BindingContext = ConfirmationViewModel.GetInstance();
        }
    }
}