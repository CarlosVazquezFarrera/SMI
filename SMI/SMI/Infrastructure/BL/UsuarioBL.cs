using SMI.Infrastructure.Services;
using SMI.Models;
using SMI.Models.Api;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SMI.Infrastructure.BL
{
    public class UsuarioBL
    {
        private readonly UsuarioService service = new UsuarioService();

        public async Task<Response<string>> CambiarPassword(Credenciales credenciales)
        {
            Response<string> response = new Response<string>();
            try
            {
                var (status, data) = await service.CambiarPassword(credenciales);
                if (status == HttpStatusCode.OK)
                {
                    response = data;
                }
                else if (status == HttpStatusCode.BadGateway)
                {
                    response.Mensaje = "Debe conectarse a internet";
                }
                else
                {
                    response.Mensaje = "Hubo un error al conectar";
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.ToString();
            }
            return response;
        }

    }
}
