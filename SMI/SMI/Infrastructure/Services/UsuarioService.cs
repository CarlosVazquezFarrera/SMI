namespace SMI.Infrastructure.Services
{
    using SMI.Models;
    using SMI.Models.Api;
    using System.Net;
    using System.Threading.Tasks;
    public class UsuarioService: WebApiClient
    {
        #region Constructor
        public UsuarioService() : base("Usuario/") { }
        #endregion

        #region Methods
        public async Task<(HttpStatusCode StatusCode, Response<string> respuesta)> CambiarPassword(Credenciales credenciales)
        {
            return await CallPutAsync<Credenciales, Response<string>>($"CambiarPassword", credenciales);
        } 
        #endregion
    }
}
