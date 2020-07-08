namespace SMI.Helpers.Funciones
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class Converter
    {
        public async static Task<string> ConvertStremToBase64(Stream stream)
        {
            Byte[] data = new Byte[stream.Length];
            await stream.ReadAsync(data, 0, (int)stream.Length);
            string base64 = Convert.ToBase64String(data);
            return base64;
        }
    }
}
