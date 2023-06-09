using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.DependencyInjection
{
    public static class HttpClientExtensions
    {
        //Client credentials are constructed using ClientId:ClientSecret
        public static HttpClient AddKeyrockSubjectHeaders(
                this HttpClient httpClient, string host, string clientCredentials)
        {
            //string encodedClientCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("clientCredentials"));            
            var headers = httpClient.DefaultRequestHeaders;
            headers.Add("Host", new Uri(host).Host);
            headers.Add("Authorization", $"Basic {clientCredentials}");

            return httpClient;
        }
    }
}
