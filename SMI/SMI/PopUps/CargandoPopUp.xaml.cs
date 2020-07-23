

namespace SMI.PopUps
{
    using Rg.Plugins.Popup.Pages;
    using SMI.ViewModels.PopUps;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CargandoPopUp : PopupPage
    {
        public CargandoPopUp()
        {
            InitializeComponent();
            BindingContext = CargandoViewModel.GetInstance();
        }
    }
}