using Microsoft.Extensions.DependencyInjection;
using Respirar.Authentication.BackEnd.Application.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddKeyrockApiClient(
        this IServiceCollection services,
        Action<HttpClient> configureClient) =>
            services.AddHttpClient<IKeyrockApiClient, KeyrockApiClient>((httpClient) =>
            {
                KeyrockApiClientFactory.ConfigureHttpClientCore(httpClient);
                configureClient(httpClient);
            });
    }
}
