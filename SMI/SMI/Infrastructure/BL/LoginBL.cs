﻿namespace SMI.Infrastructure.BL
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

        public async Task<Response> Login(Empleado empleado)
        {
            Response response = new Response();
            try
            {
                var (status, data) = await service.Login(empleado);
                if(status == HttpStatusCode.OK)
                {
                    response =  data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return response;
        }
    }
}
