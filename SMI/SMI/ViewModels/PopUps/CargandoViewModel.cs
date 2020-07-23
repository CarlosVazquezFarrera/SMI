namespace SMI.ViewModels.PopUps
{
    public class CargandoViewModel: BaseViewModel
    {
        #region Contructor
        private CargandoViewModel()
        {

        }
        #endregion

        #region Atributes
        public static CargandoViewModel viewModel { get; set; }

        private string mensaje;
        #endregion

        #region Properties
        public string Mensaje
        {
            get { return this.mensaje; }
            set { Set(ref this.mensaje, value); }
        }
        #endregion

        #region Methods
        public static CargandoViewModel GetInstance()
        {
            if (viewModel == null)
            {
                viewModel = new CargandoViewModel();
            }
            return viewModel;
        } 
        #endregion
    }
}
