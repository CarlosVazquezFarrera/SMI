namespace SMI.Infrastructure.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
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

        #region Propiedades
        public string UrlBaseWebApi { get; set; } = "http://192.168.0.15:45457/api/";

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


        #region Metodos
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

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallGetAsync<TResponse>(string url)
        {
            try
            {
                    var res = await GetAsync(url).ConfigureAwait(false);
                    return ProcessResponse<TResponse>(res);
            }
            catch (Exception)
            {
                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPostAsync<TRequest, TResponse>(string url, TRequest req)
        {
            try
            {
                //Validar que haya conexion
                    var res = await PostAsync(url, new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(req), System.Text.Encoding.UTF8, "application/json")).ConfigureAwait(false);
                    return ProcessResponse<TResponse>(res);
            }
            catch (Exception)
            {
                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPutAsync<TRequest, TResponse>(string url, TRequest req)
        {
            try
            {
                var res = await PutAsync(url, new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json")).ConfigureAwait(false);
                return ProcessResponse<TResponse>(res);
            }
            catch (Exception)
            {
                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallDeleteAsync<TResponse>(string url)
        {
            try
            {
                var res = await DeleteAsync(url).ConfigureAwait(false);
                return ProcessResponse<TResponse>(res);
            }
            catch (Exception)
            {

                return (HttpStatusCode.BadRequest, default(TResponse));
            }
        }

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
        #endregion
        public static bool HayConexion(string huesped = "http://www.bing.com")
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(huesped))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
