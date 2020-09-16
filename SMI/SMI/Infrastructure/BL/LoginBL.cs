namespace SMI.Infrastructure.BL
{
    using SMI.Infrastructure.Services;
    using SMI.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    public class LoginBL
    {
        private readonly LoginService service = new LoginService();

        public async Task<Response<Empleado>> Login(Empleado empleado)
        {
            Response<Empleado> response = new Response<Empleado>();
            try
            {
                var (status, data) = await service.Login(empleado);
                if(status == HttpStatusCode.OK)
                {
                    response =  data;
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
