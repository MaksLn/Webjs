using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Webjs.src;

namespace Webjs.Parser
{
    class HtmlLoader
    {
        readonly HttpClient httpClient;
        readonly string url;

        public HtmlLoader(ISettings settings)
        {
            httpClient = new HttpClient();
            url = $"{settings.ParseURL}/";
        }

        public async Task<string> GetSourseById(int id)
        {
            var curentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await httpClient.GetAsync(curentUrl);
            string source = null;

            if(response!=null&& response.StatusCode== System.Net.HttpStatusCode.OK)
            {
                source =await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
