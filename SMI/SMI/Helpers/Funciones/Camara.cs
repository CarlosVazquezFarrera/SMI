namespace SMI.Helpers.Funciones
{
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using SMI.Models;
    using System;
    using System.Threading.Tasks;

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
                        respuesta.Data = await Converter.ConvertStremToBase64(foto.GetStream());
                        respuesta.Result = true;
                    }
                }
                catch (Exception)
                {
                    respuesta.Data = "Ocurrió un error al tomar la foto";
                }
            }
            return respuesta;
        }

        public async static Task<Response> AbriGaleria()
        {
            IsPossible();
            if (respuesta.Result)
            {
                respuesta.Result = false;
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
                        respuesta.Result = true;
                    }
                }
                catch (Exception)
                {
                    respuesta.Data = "Ocurrió un error al tomar la foto";
                }
            }
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
