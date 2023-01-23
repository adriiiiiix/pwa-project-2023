using Blazored.LocalStorage;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using PWA.Utilities;
using System.Net;
using System.Text;

namespace PWA.Services
{
    public sealed class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly ISnackbar _snackBar;

        public HttpService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ISnackbar snackbar, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _authStateProvider = authenticationStateProvider;
            _snackBar = snackbar;
            _localStorage = localStorageService;
        }

        public async Task<CustomResponse<T>> GetAsync<T>(string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative)
            };

            return await SendAsync<T>(message);
        }

        public async Task<CustomResponse<T>> PostAsync<T>(string uri, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var encoded = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = encoded
            };

            return await SendAsync<T>(message);
        }

        public async Task<CustomResponse<T>> PatchAsync<T>(string uri, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var encoded = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = encoded
            };

            return await SendAsync<T>(message);
        }

        public async Task<CustomResponse<T>> DeleteAsync<T>(string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri, UriKind.Relative)
            };

            return await SendAsync<T>(message);
        }

        public async Task<CustomResponse<T>> SendAsync<T>(HttpRequestMessage message)
        {
            CustomResponse<T> customResponse = new();
            HttpResponseMessage response;

            try
            {
                response = await _httpClient.SendAsync(message);
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("Failed to fetch"))
                { 
                    customResponse.Code = HttpStatusCode.ServiceUnavailable;
                    _snackBar.Add("Serverul nu poate fi accesat!", Severity.Error);
                }
                else
                {
                    _snackBar.Add($"{ex.Message}", Severity.Error);
                    customResponse.Code = HttpStatusCode.InternalServerError;
                    customResponse.Message = ex.Message;
                }
                return customResponse;
            }

            customResponse.Code = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                customResponse.IsSuccessful = true;
                string data = await response.Content.ReadAsStringAsync();
                customResponse.Data = JsonConvert.DeserializeObject<T>(data);
            }
            else
            {
                if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await _localStorage.RemoveItemAsync("token");
                    await _authStateProvider.GetAuthenticationStateAsync();
                }

                customResponse.IsSuccessful = false;
                customResponse.Message = await response.Content.ReadAsStringAsync();
            }

            return customResponse;
        }
    }

    public interface IHttpService
    {
        Task<CustomResponse<T>> GetAsync<T>(string uri);
        Task<CustomResponse<T>> PostAsync<T>(string uri, object data);
        Task<CustomResponse<T>> PatchAsync<T>(string uri, object data);
        Task<CustomResponse<T>> DeleteAsync<T>(string uri);

        Task<CustomResponse<T>> SendAsync<T>(HttpRequestMessage message);
    }
}
