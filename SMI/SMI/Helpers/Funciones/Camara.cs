namespace SMI.Helpers.Funciones
{
    using FFImageLoading;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using SMI.Models;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class Camara
    {
        readonly static Response respuesta = new Response();

        public async static Task<Response> TomarFoto()
        {
            IsPossible();
            if (respuesta.Result)
            {
                respuesta.Result = false;
                try
                {
                    StoreCameraMediaOptions opcionesCamara = new StoreCameraMediaOptions
                    {
                        CompressionQuality = 50,
                        PhotoSize = PhotoSize.Full,
                        SaveToAlbum = true,
                        Name = $"{new Guid()}{DateTime.Now.ToString("HH:mm:ss")}.png"
                    };
                    var foto = await CrossMedia.Current.TakePhotoAsync(opcionesCamara);
                    if (foto != null)
                    {
                        Stream stream = foto.GetStream();
                        Byte[] data = new Byte[stream.Length];
                        await stream.ReadAsync(data, 0, (int)stream.Length);
                        string base64 = Convert.ToBase64String(data);
                        respuesta.Data = base64;
                    }
                }
                catch (Exception)
                {
                    respuesta.Data = "Ocurrió un error al tomar la foto";
                }
            }
            respuesta.Result = true;
            return respuesta;
        }

        private static Response IsPossible()
        {
            if (!CrossMedia.Current.IsCameraAvailable)
            {
                respuesta.Data = "La cámara no está disponible";
                return respuesta;
            }
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                respuesta.Data = "No se pudo tomar la foto. Revise los permisos";
                return respuesta;
            }
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                respuesta.Data = "No se pudo abrir la galería. Revise los permisos";
                return respuesta;
            }
            respuesta.Result = true;
            return respuesta;
        }
    }
}
