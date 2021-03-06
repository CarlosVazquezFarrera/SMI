﻿namespace SMI.OS
{
    using Rg.Plugins.Popup.Pages;
    using Rg.Plugins.Popup.Services;
    using SMI.OS.Keys;
    using SMI.PopUps;
    using SMI.ViewModels.PopUps;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

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
                case PopUpKeys.CambiarFoto:
                    await IsPopUpInstanced(new CambiarFotoPopUp());
                    break;
            }
        }
        public static async Task PushPopUp(string page, params object[] param)
        {
            switch (page)
            {
                case PopUpKeys.Mensaje:
                    MessageViewModel.GetInstance().Mensaje = param[0].ToString();
                    await IsPopUpInstanced(new MessagePopUp());
                    break;
                case PopUpKeys.Cargando:
                    CargandoViewModel.GetInstance().Mensaje = param[0].ToString();
                    await IsPopUpInstanced(new CargandoPopUp());
                    break;
            }
        }
        /// <summary>
        /// PopUp para confirmacion
        /// </summary>
        /// <param name="page"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static async Task<bool> PushConfirmationPopUp(string page, params object[] param)
        {
            bool response = false;
            switch (page)
            {
                case PopUpKeys.Confirmacion:
                    ConfirmationViewModel.GetInstance().Mensaje = param[0].ToString();
                    await IsPopUpInstanced(new ConfirmationPopUp());
                    response = (bool) await ConfirmationViewModel.GetInstance().GetResult();
                    break;
            }
            
            return response;
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
