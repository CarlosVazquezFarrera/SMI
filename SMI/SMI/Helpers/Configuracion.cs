namespace SMI.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    public static class Configuracion
    {
        private static ISettings AppSettings => CrossSettings.Current;

        /// <summary>
        /// Establece si se ha activado la opción de recordar sesión 
        /// </summary>
        
        public static bool MantenerSesion
        {
            get => AppSettings.GetValueOrDefault(nameof(MantenerSesion), false);
            set => AppSettings.AddOrUpdateValue(nameof(MantenerSesion), value);
        }
    }
}
