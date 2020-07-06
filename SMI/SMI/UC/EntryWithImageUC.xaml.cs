namespace SMI.UC
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryWithImageUC : ContentView
    {
        public EntryWithImageUC()
        {
            InitializeComponent();
            this.Entry.TextChanged += (s, e) =>
            {
                this.Text = this.Entry.Text;
            };
        }

        /// <summary>
        /// Establece y obtiene el texto que se introduce en el Entry
        /// </summary>
        #region Atributo
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        /// <summary>
        /// Define el ícono que se usará
        /// </summary>
        public ImageSource Icono
        {
            get => (string)GetValue(IconoProperty);
            set => SetValue(IconoProperty, value);
        }
        /// <summary>
        /// Define el PlaceHolder del texto 
        /// </summary>
        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }
        /// <summary>
        /// Define si es password o no
        /// </summary>
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        /// <summary>
        /// Define el tipo de telcado a usar
        /// </summary>
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public Style Estilo
        {
            get => (Style)GetValue(EstilodProperty);
            set => SetValue(EstilodProperty, value);
        }
        #endregion

        #region Propiedad
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(EntryWithImageUC), default(string), defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entryWithImageUC = (EntryWithImageUC)bindable;
            entryWithImageUC.Entry.Text = (string)newValue;
        });

        public static readonly BindableProperty IconoProperty = BindableProperty.Create(nameof(Icono), typeof(ImageSource), typeof(EntryWithImageUC), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imagen = (EntryWithImageUC)bindable;
            imagen.Imagen.Source = (ImageSource)newValue;
        });

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(EntryWithImageUC), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryWithImageUC)bindable;
            entry.Entry.Placeholder = (string)newValue;
        });

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(EntryWithImageUC), default(bool),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryWithImageUC)bindable;
            entry.Entry.IsPassword = (bool)newValue;
        });

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(EntryWithImageUC), default(Keyboard),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryWithImageUC)bindable;
            entry.Entry.Keyboard = (Keyboard)newValue;
        });

        public static readonly BindableProperty EstilodProperty = BindableProperty.Create(nameof(Style), typeof(Style), typeof(EntryWithImageUC), default(Style),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryWithImageUC)bindable;
            entry.Entry.Style = (Style)newValue;
        });
    }
    #endregion
}
