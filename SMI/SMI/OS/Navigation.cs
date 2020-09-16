namespace SMI.OS
{
    using SMI.Views;
    using SMI.Views.Inicio;
    using SMI.Views.Perfil;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public static class Navigation
    {
        /// <summary>
        /// Con base a la página especificada decide qué página instancias
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task NavigateTo(string page)
        {
            switch (page)
            {   
                case PagesKeys.RootTabbed:
                    App.Current.MainPage = new NavigationPage(new RootTabbed());
                    break;
                case PagesKeys.Login:
                    App.Current.MainPage = new MainPage();
                    break;
                case PagesKeys.CambiasPassword:
                    await IsInstanced(new CambiarPasswordPage());
                    break;
            }
        }

        /// <summary>
        /// Evita que una página que ya está instanciada se apile en el stack
        /// </summary>
        /// <param name="NuevaPagina"></param>
        /// <returns></returns>
        private static async Task IsInstanced(Page NuevaPagina)
        {
            List<Page> ListaDePaginas = App.Current.MainPage.Navigation.NavigationStack.ToList();
            short PaginasSimilaresApiladas = (short)ListaDePaginas.Where(p => p.GetType() == NuevaPagina.GetType()).Count();
            if (PaginasSimilaresApiladas < 1)
                await App.Current.MainPage.Navigation.PushAsync(NuevaPagina, true);

        }

        /// <summary>
        /// Desapila la página actual
        /// </summary>
        public async static Task GoBack()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// Desapila todas las páginas y regresa a la principal
        /// </summary>
        public async static Task PopToRoot()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
