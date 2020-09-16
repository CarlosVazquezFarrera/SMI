namespace SMI.Infrastructure.Services
{
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class WebApiClient : HttpClient
    {
        #region Constructor
        public WebApiClient()
        {
            BaseAddress = new Uri(UrlBaseWebApi);
            InitHeaders();
        }
        public WebApiClient(string urlController)
        {
            UrlController = urlController;
            InitHeaders();
        }
        #endregion

        #region Properties
        public string UrlBaseWebApi { get; set; } = "http://192.168.0.15:45455/api/";

        string urlController;
        protected string UrlController
        {
            get => urlController;
            set
            {
                urlController = !value.EndsWith("/") ? value + "/" : value;
                UrlBaseWebApi += (!UrlBaseWebApi.EndsWith("/") ? "/" : string.Empty) + value;
                BaseAddress = new System.Uri(UrlBaseWebApi);
            }
        }
        #endregion


        #region Methods
        void InitHeaders()
        {
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
        }

        private (HttpStatusCode StatusCode, TResponse Content) ProcessResponse<TResponse>(HttpResponseMessage res)
        {
            if (res.IsSuccessStatusCode)
            {
                var s = res.Content.ReadAsStringAsync().Result;
                if (s != "")
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(s);
                    return (res.StatusCode, response);
                }
                else return (res.StatusCode, default(TResponse));

            }
            else return (res.StatusCode, default(TResponse));
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallGetAsync<TResponse>(string url)
        {
            try
            { 
                if (HayConexion())
                {
                    var res = await GetAsync(url).ConfigureAwait(false);
                    return ProcessResponse<TResponse>(res);
                }
                else
                {
                    return (HttpStatusCode.BadGateway, default(TResponse));
                }
            }
            catch (Exception)
            {
                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }
        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPostAsync<TRequest, TResponse>(string url, TRequest req)
        {
            try
            {
                if (HayConexion())
                {
                    var res = await PostAsync(url, new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json")).ConfigureAwait(false);
                    return ProcessResponse<TResponse>(res);
                }
                else
                {
                    return (HttpStatusCode.BadGateway, default(TResponse));
                }
            }
            catch (Exception)
            {
                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallDeleteAsync<TResponse>(string url)
        {
            try
            {
                if (HayConexion())
                {
                    var res = await DeleteAsync(url).ConfigureAwait(false);
                    return ProcessResponse<TResponse>(res);
                }
                else
                {
                    return (HttpStatusCode.BadGateway, default(TResponse));
                }
            }
            catch (Exception)
            {

                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPutAsync<TRequest, TResponse>(string url, TRequest req)
        {
            try
            {
                if (HayConexion())
                {
                    var res = await PutAsync(url, new StringContent(JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json")).ConfigureAwait(false);
                    return ProcessResponse<TResponse>(res);
                }
                else
                {
                    return (HttpStatusCode.BadGateway, default(TResponse));
                }
            }
            catch (Exception)
            {
                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }


        /// <summary>
        /// Subir archivo
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="contentName"></param>
        /// <param name="fileName"></param>
        /// <param name="mediaType"></param>
        /// <param name="extraContent"></param>
        /// <param name="extraName"></param>
        /// <returns></returns>
        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPostFileAsync<TResponse>(string url, byte[] file, string contentName, string fileName, string mediaType, System.Net.Http.HttpContent extraContent = null, string extraName = "")
        {
            //http://stackoverflow.com/questions/16416601/c-sharp-httpclient-4-5-multipart-form-data-upload
            var requestContent = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(file);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mediaType);
            requestContent.Add(imageContent, contentName, fileName);
            if (extraContent != null) requestContent.Add(extraContent, extraName);
            var res = await PostAsync(url, requestContent);
            return ProcessResponse<TResponse>(res);
        }

        /// <summary>
        /// Valida si hay conexion a internet
        /// </summary>
        /// <param name="huesped"></param>
        /// <returns></returns>
        public static bool HayConexion()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        #endregion
    }
}
