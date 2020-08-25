namespace SMI.Helpers.Funciones
{
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using SMI.Models;
    using System;
    using System.Threading.Tasks;

    public class Camara
    {
        readonly static Response<string> respuesta = new Response<string>();

        public async static Task<Response<string>> TomarFoto()
        {
            IsPossible();
            if (respuesta.Exito)
            {
                respuesta.Exito = false;
                try
                {
                    StoreCameraMediaOptions opcionesCamara = new StoreCameraMediaOptions
                    {
                        Directory = "SMI",
                        CompressionQuality = 50,
                        PhotoSize = PhotoSize.Full,
                        SaveToAlbum = true,
                        Name = $"{new Guid()}{DateTime.Now.ToString("HH:mm:ss")}.png"
                    };
                    var foto = await CrossMedia.Current.TakePhotoAsync(opcionesCamara);
                    if (foto != null)
                    {
                        respuesta.Data = await Converter.ConvertStremToBase64(foto.GetStream());
                        respuesta.Exito = true;
                    }
                }
                catch (Exception)
                {
                    respuesta.Mensaje = "Ocurrió un error al tomar la foto";
                }
            }
            return respuesta;
        }

        public async static Task<Response<string>> AbriGaleria()
        {
            IsPossible();
            if (respuesta.Exito)
            {
                respuesta.Exito = false;
                try
                {
                    PickMediaOptions opcionesCamara = new PickMediaOptions
                    {
                        CompressionQuality = 50,
                        PhotoSize = PhotoSize.Full
                    };
                    var foto = await CrossMedia.Current.PickPhotoAsync(opcionesCamara);
                    if (foto != null)
                    {
                        respuesta.Data = await Converter.ConvertStremToBase64(foto.GetStream());
                        respuesta.Exito = true;
                    }
                }
                catch (Exception)
                {
                    respuesta.Mensaje = "Ocurrió un error al tomar la foto";
                }
            }
            return respuesta;
        }
        private static Response<string> IsPossible()
        {
            if (!CrossMedia.Current.IsCameraAvailable)
            {
                respuesta.Mensaje = "La cámara no está disponible";
                return respuesta;
            }
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                respuesta.Mensaje = "No se pudo tomar la foto. Revise los permisos";
                return respuesta;
            }
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                respuesta.Mensaje = "No se pudo abrir la galería. Revise los permisos";
                return respuesta;
            }
            respuesta.Exito = true;
            return respuesta;
        }
    }
}
