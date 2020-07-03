namespace SMI.OS
{
    using SMI.Views.Inicio;
    using System.Threading.Tasks;

    public static class Navigation
    {
        public static async Task NavigateTo(string page)
        {
            switch (page)
            {
                case "Inicio":
                    await App.Current.MainPage.Navigation.PushAsync(new InicioPage());
                    break;
            }
        }
    }
}
