using Microsoft.Extensions.Configuration;
using Respirar.Authentication.BackEnd.Application.Commands;
using Respirar.Authentication.BackEnd.Application.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace Respirar.Authentication.BackEnd.Application.ApiClient
{
    public class KeyrockApiClient : IKeyrockApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public KeyrockApiClient(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ValueResult<LoginResult>> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            ValueResult<LoginResult> result;

            var formData = new FormUrlEncodedContent(new[]
             {
                new KeyValuePair<string, string>("username", command.name),
                new KeyValuePair<string, string>("password", command.password),
                new KeyValuePair<string, string>("grant_type", "password"),
            });
            
            //var response = await _httpClient.PostAsJsonAsync<LoginCommand>("oauth2/token", command, cancellationToken);
            var response = await _httpClient.PostAsync("oauth2/token", formData, cancellationToken);

            if (response.IsSuccessStatusCode) {
                //var res = await response.Content.ReadFromJsonAsync<dynamic>();
                result = ValueResult<LoginResult>.Ok(await response.Content.ReadFromJsonAsync<LoginResult>());
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                result = ValueResult<LoginResult>.Error(errorResponse.error);
            }

            return result;
        }

        public async Task<ValueResult<UserRegisterResult>> UserRegister(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            ValueResult<UserRegisterResult> result;
            var token = await CreateToken();//"ddcfea33-76e3-4f34-ac78-b3cfdf280a66";
            _httpClient.DefaultRequestHeaders.Add("X-Auth-token", token.Result);
            var jsonContent = new StringContent(JsonSerializer.Serialize(new
            {
                user = new
                {
                    username = command.username,
                    email = command.username,
                    password = command.password
                }
            }), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("v1/users", jsonContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                result = ValueResult<UserRegisterResult>.Ok(await response.Content.ReadFromJsonAsync<UserRegisterResult>());
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                result = ValueResult<UserRegisterResult>.Error(errorResponse.error);
            }

            return result;                        
        }

        public async Task<ValueResult<String>>CreateToken()
        {
            ValueResult<String> result;

            var jsonContent = new StringContent(JsonSerializer.Serialize(new
            {
                name = _configuration["Keyrock:AdminUser"],
                password = _configuration["Keyrock:AdminPass"]

            }), System.Text.Encoding.UTF8, "application/json"); 

            var response = await _httpClient.PostAsync("v1/auth/tokens", jsonContent);

            if (response.IsSuccessStatusCode && response.Headers.TryGetValues("X-Subject-Token", out var headerValues))
            {
                result = ValueResult<String>.Ok(headerValues.FirstOrDefault());
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<dynamic>();
                result = ValueResult<String>.Error(errorResponse.Error);
            }

            return result;
        }
        public class ErrorResponse
        {
            public string error { get; set; }
        }
    }
}
