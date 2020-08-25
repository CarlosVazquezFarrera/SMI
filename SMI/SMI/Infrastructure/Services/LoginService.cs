namespace SMI.Infrastructure.Services
{
    using SMI.Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    public class LoginService: WebApiClient
    {
        public LoginService(): base("Login/")
        {
        }
        /// <summary>
        /// Obtiene la data de prueba
        /// </summary>
        /// <returns></returns>
        public async Task<(HttpStatusCode StatusCode, Response<Empleado> respuesta)> Login(Empleado empleado)
        { 
            return await CallGetAsync<Response<Empleado>>($"login?Email={empleado.Email}&Password={empleado.Password}"); 
        }

        //public async Task<HttpStatusCode StatusCode, Response>
    }
}
