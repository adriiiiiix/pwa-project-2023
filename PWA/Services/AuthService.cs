using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PWA.Shared.DTOs;
using PWA.Utilities;

namespace PWA.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(IHttpService httpService, ILocalStorageService localStorageService, AuthenticationStateProvider authStateProvider)
        {
            _httpService = httpService;
            _localStorage = localStorageService;
            _authStateProvider = authStateProvider;
        }

        public async Task<CustomResponse<UserDto>> LoginAsync(LoginDto loginDto)
        {
            CustomResponse<UserDto> response = await _httpService.PostAsync<UserDto>("auth/login", loginDto);
            if (response.IsSuccessful)
            {
                await _localStorage.SetItemAsync<UserDto>("token", response.Data);
                await _authStateProvider.GetAuthenticationStateAsync();
            }

            return response;
        }

        public async Task<CustomResponse<bool>> RegisterAsync(RegisterDto registerDto)
        {
            return await _httpService.PostAsync<bool>("auth/register", registerDto);
        }

        public async Task<CustomResponse<bool>> ChangePaswordAsync(ChangePasswordDto changePasswordDto)
        {
            return await _httpService.PostAsync<bool>("auth/changePassword", changePasswordDto);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _authStateProvider.GetAuthenticationStateAsync();
        }

    }

    public interface IAuthService
    {
        Task<CustomResponse<UserDto>> LoginAsync(LoginDto loginDto);
        Task<CustomResponse<bool>> RegisterAsync(RegisterDto registerDto);
        Task<CustomResponse<bool>> ChangePaswordAsync(ChangePasswordDto changePasswordDto);

        Task Logout();
    }
}
