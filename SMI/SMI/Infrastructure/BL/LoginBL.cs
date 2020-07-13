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

        public async Task<List<WeatherForecast>> Login()
        {
            List<WeatherForecast> lista = new List<WeatherForecast>();
            try
            {
                var (status, data) = await service.Login();
                if(status == HttpStatusCode.OK)
                {
                    lista = (List<WeatherForecast>)data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return lista;
        }
    }
}
