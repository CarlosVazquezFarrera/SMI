namespace SMI.UC
{
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Xamarin.Forms.Markup;

    public class LabelCommand : Label 
    {
        #region Atributos
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region Propiedades
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(LabelCommand), default(ICommand),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var labelCommand = (LabelCommand)bindable;
            var tap = new TapGestureRecognizer();
            tap.Command = (ICommand)newValue;
            labelCommand.GestureRecognizers.Add(tap);
        });
        #endregion
    }
}
