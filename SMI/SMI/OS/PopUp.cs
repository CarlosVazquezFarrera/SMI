namespace SMI.OS
{
    using Rg.Plugins.Popup.Pages;
    using Rg.Plugins.Popup.Services;
    using SMI.OS.Keys;
    using SMI.PopUps;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    public static class PopUp
    {
        /// <summary>
        /// Con base al PopUp especificado decide qué PopUp Mostrar
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static async Task PushPopUp(string page)
        {
            switch (page)
            {
                case PopUpKeys.Mensaje:
                    await IsPopUpInstanced(new MessagePopUp());
                    break;
                case PopUpKeys.CambiarFoto:
                    await IsPopUpInstanced(new CambiarFotoPopUp());
                    break;
            }
        }

        /// <summary>
        /// Desapila el o los PopUps que haya instanciados
        /// </summary>
        public static async Task PopAllPopUps()
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        /// <summary>
        /// Evita que un PopUp que ya está instaciado se apile en el Stack
        /// </summary>
        /// <param name="NuevoPopUp"></param>
        /// <returns></returns>
        private static async Task IsPopUpInstanced(PopupPage NuevoPopUp)
        {
            short PopUpSimilaresApilados = 0;
            if (PopupNavigation.Instance.PopupStack != null && PopupNavigation.Instance.PopupStack.Count > 0)
            {
                List<PopupPage> ListaDePopUps = PopupNavigation.Instance.PopupStack.ToList();
                PopUpSimilaresApilados = (short)ListaDePopUps.Where(p => p.GetType() == NuevoPopUp.GetType()).Count();
            }
            if (PopUpSimilaresApilados < 1)
                await PopupNavigation.Instance.PushAsync(NuevoPopUp, true);
        }
    }
}
