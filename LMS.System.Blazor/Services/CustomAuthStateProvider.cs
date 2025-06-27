using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// Provides authentication state management for Blazor Server applications using JWT tokens.
/// </summary>
public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedLocalStorage _localStorage;
    private readonly IJwtService _jwtService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomAuthStateProvider"/> class.
    /// </summary>
    /// <param name="localStorage">The protected browser storage for token persistence.</param>
    /// <param name="jwtService">The JWT service for token operations.</param>
    public CustomAuthStateProvider(
        ProtectedLocalStorage localStorage,
        IJwtService jwtService)
    {
        _localStorage = localStorage;
        _jwtService = jwtService;
    }

    /// <summary>
    /// Gets the current authentication state by checking for a stored JWT token.
    /// </summary>
    /// <returns>The current authentication state.</returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var tokenResult = await _localStorage.GetAsync<string>("authToken");
            if (tokenResult.Success && !string.IsNullOrEmpty(tokenResult.Value))
            {
                return CreateAuthenticationState(tokenResult.Value);
            }
        }
        catch
        {
            // Ignore errors during token retrieval
        }

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    /// <summary>
    /// Marks the user as authenticated by storing the JWT token.
    /// </summary>
    /// <param name="token">The JWT token to store.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task MarkUserAsAuthenticatedAsync(string token)
    {
        await _localStorage.SetAsync("authToken", token);
        NotifyAuthenticationStateChanged(
            Task.FromResult(CreateAuthenticationState(token)));
    }

    /// <summary>
    /// Marks the user as logged out by removing the stored JWT token.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task MarkUserAsLoggedOutAsync()
    {
        await _localStorage.DeleteAsync("authToken");
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
    }

    /// <summary>
    /// Creates an authentication state from a JWT token.
    /// </summary>
    /// <param name="token">The JWT token to parse.</param>
    /// <returns>The created authentication state.</returns>
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
