namespace SMI.Helpers.Funciones
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class Converter
    {
        /// <summary>
        /// Convierte el steam obetendo de la cámara o galería y lo convierte en Base64
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public async static Task<string> ConvertStremToBase64(Stream stream)
        {
            Byte[] data = new Byte[stream.Length];
            await stream.ReadAsync(data, 0, (int)stream.Length);
            string base64 = Convert.ToBase64String(data);
            return base64;
        }

        public static ImageSource ConvertBase64ToImageSource(string base64)
        {
            return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64)));
        }
    }
}
