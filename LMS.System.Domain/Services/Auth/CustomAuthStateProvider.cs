using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// Provides authentication state using JWT tokens stored in protected browser storage
/// </summary>
public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedLocalStorage _localStorage;
    private const string TokenKey = "authToken";

    public CustomAuthStateProvider(ProtectedLocalStorage localStorage)
    {
        _localStorage = localStorage;
    }

    /// <summary>
    /// Gets the current authentication state
    /// </summary>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var tokenResult = await _localStorage.GetAsync<string>(TokenKey);
            if (tokenResult.Success && !string.IsNullOrEmpty(tokenResult.Value))
            {
                return CreateAuthenticationState(tokenResult.Value);
            }
        }
        catch
        {
            // Ignore storage access errors
        }

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    /// <summary>
    /// Marks user as authenticated and stores the token
    /// </summary>
    public async Task MarkUserAsAuthenticatedAsync(string token)
    {
        await _localStorage.SetAsync(TokenKey, token);
        NotifyAuthenticationStateChanged(
            Task.FromResult(CreateAuthenticationState(token)));
    }

    /// <summary>
    /// Marks user as logged out and removes the token
    /// </summary>
    public async Task MarkUserAsLoggedOutAsync()
    {
        await _localStorage.DeleteAsync(TokenKey);
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
    }

    private AuthenticationState CreateAuthenticationState(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
