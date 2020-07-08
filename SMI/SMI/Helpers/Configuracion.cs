namespace SMI.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    using Xamarin.Forms;

    public static class Configuracion
    {
        private static ISettings AppSettings => CrossSettings.Current;
        /*= new Image */
        //{
        //    Source = ImageSource.FromResource("base.png")
        //};
        /// Establece si se ha activado la opción de recordar sesión 
        /// </summary>

        public static bool MantenerSesion
        {
            get => AppSettings.GetValueOrDefault(nameof(MantenerSesion), false);
            set => AppSettings.AddOrUpdateValue(nameof(MantenerSesion), value);
        }

        public static string FotoDePerfil
        {
            get => AppSettings.GetValueOrDefault(nameof(FotoDePerfil), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(FotoDePerfil), value);
        }
    }
}
