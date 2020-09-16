using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SMI.ViewModels.PopUps
{
    public class ConfirmationViewModel: BaseViewModel
    {
        #region Constructor
        private ConfirmationViewModel() {}
        #endregion

        #region Atributes
        private string mensaje;

        private static TaskCompletionSource<object> Process;
        #endregion

        #region Properties
        public string Mensaje
        {
            get { return this.mensaje; }
            set { Set(ref this.mensaje, value); }
        } 
        #endregion

        #region Atributes
        public static ConfirmationViewModel viewModel { get; set; }
        #endregion

        #region Commands
        /// <summary>
        /// Aceptar
        /// </summary>
        public ICommand AceptarCommand
        {
            get
            {
                return new RelayCommand(Aceptar);
            }
        }
        /// <summary>
        /// Negar
        /// </summary>
        public ICommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }
        #endregion

        #region Methods
        public static ConfirmationViewModel GetInstance()
        {
            if (viewModel == null)
            {
                viewModel = new ConfirmationViewModel();
            }
            Process = new TaskCompletionSource<object>();
            return viewModel;
        } 
        public virtual Task<object> GetResult()
        {
            return Process.Task;
        }
        private void Aceptar()
        {
            Process.SetResult(true);
            CerrarPopUp();
        }
        private void Cancelar()
        {
            Process.SetResult(false);
            CerrarPopUp();
        }
        #endregion
    }
}
