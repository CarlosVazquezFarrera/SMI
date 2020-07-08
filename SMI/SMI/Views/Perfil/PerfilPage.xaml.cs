using SMI.ViewModels.Perfil;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SMI.Views.Perfil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage()
        {
            InitializeComponent();
            BindingContext = PerfilViewModel.GetInstance();
        }
    }
}