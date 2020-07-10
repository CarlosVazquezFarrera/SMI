using Xamarin.Forms;

namespace SMI.ViewModels.PopUps
{
    public class MessageViewModel: BaseViewModel
    {
        #region Constructor
        private MessageViewModel()
        {
        }
        #endregion

        #region Atributo
        /// <summary>
        /// Instancia del ViewModel para el patron singleton
        /// </summary>
        private static MessageViewModel viewModel;
        /// <summary>
        /// Mensaje que se va a mostrar en la vista
        /// </summary>
        private string mensaje;
        #endregion

        #region Propiedad
        public string Mensaje
        {
            get { return this.mensaje; }
            set { Set(ref this.mensaje, value); }
        }
        #endregion

        #region Methods
        public static MessageViewModel GetInstance()
        {
            if (viewModel == null)
            {
                viewModel = new MessageViewModel();
            }
            return viewModel;
        } 
        #endregion
    }
}
