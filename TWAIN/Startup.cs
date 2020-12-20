using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;

namespace TWAIN
{
    public static class Startup
    {
        public static HttpSelfHostConfiguration ConfigureHttpSelfHost()
        {
            var config = new HttpSelfHostConfiguration(Properties.Settings.Default.BaseURL);

            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{action}");

            return config;
        }
    }
}
