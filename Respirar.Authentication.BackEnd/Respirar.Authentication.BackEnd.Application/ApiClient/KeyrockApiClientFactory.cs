using Microsoft.Extensions.Configuration;
using Respirar.Authentication.BackEnd.Application.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.ApiClient
{
    public static class KeyrockApiClientFactory
    {
        public static IKeyrockApiClient Create(HttpClient httpClient, IConfiguration configuration)
        {
            return new KeyrockApiClient(httpClient, configuration);
        }

        internal static void ConfigureHttpClient(
            HttpClient httpClient, string host, string clientCredentials)
        {
            ConfigureHttpClientCore(httpClient);
            httpClient.AddKeyrockSubjectHeaders(host, clientCredentials);
        }

        internal static void ConfigureHttpClientCore(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
        }
    }
}
