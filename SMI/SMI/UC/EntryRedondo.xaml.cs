using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SMI.UC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryRedondo : ContentView
    {
        public EntryRedondo()
        {
            InitializeComponent();
            this.Text = this.Entry.Text;
        }

        /// <summary>
        /// Estilo que utilizará el control
        /// </summary>
        public Style Estilo
        {
            get => (Style)GetValue(EstilodProperty);
            set => SetValue(EstilodProperty, value);
        }

        /// <summary>
        /// Icono que se utiliza en el control personaizado (La imagen de la izquerda)
        /// </summary>
        public ImageSource Icono
        {
            get => (string)GetValue(IconoProperty);
            set => SetValue(IconoProperty, value);
        }
        public static readonly BindableProperty IconoProperty = BindableProperty.Create(nameof(Icono), typeof(ImageSource), typeof(EntryRedondo), default(string), defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imagen = (EntryRedondo)bindable;
            imagen.Icon.Source = (ImageSource)newValue;
        });

        /// <summary>
        /// El texto que se introduce en el Entry
        /// </summary>

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(EntryRedondo), default(string), defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryRedondo)bindable;
            entry.Entry.Text = (string)newValue;
        });

        /// <summary>
        /// PlaceHolder del entry
        /// </summary>
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(EntryRedondo), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryRedondo)bindable;
            entry.Entry.Placeholder = (string)newValue;
        });
        /// <summary>
        /// Define si el entry es Pasword o no
        /// </summary>
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(EntryRedondo), default(bool),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryRedondo)bindable;
            entry.Entry.IsPassword = (bool)newValue;
        });
        /// <summary>
        /// Define el tipo de teclado del control
        /// </summary>
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(EntryRedondo), default(Keyboard),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (EntryRedondo)bindable;
            entry.Entry.Keyboard = (Keyboard)newValue;
        });

        public static readonly BindableProperty EstilodProperty = BindableProperty.Create(nameof(Style), typeof(Style), typeof(EntryWithImageUC), default(Style),
       propertyChanged: (bindable, oldValue, newValue) =>
       {
           var entry = (EntryRedondo)bindable;
           entry.Entry.Style = (Style)newValue;
       });
    }
}