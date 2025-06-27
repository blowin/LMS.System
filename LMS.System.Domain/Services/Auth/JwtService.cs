using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// Service for generating and validating JWT tokens.
/// </summary>
public class JwtService : IJwtService
{
    private readonly JwtSettings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtService"/> class.
    /// </summary>
    /// <param name="settings">JWT configuration settings.</param>
    public JwtService(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }

    /// <summary>
    /// Generates a JWT token with default expiration time.
    /// </summary>
    /// <param name="request">Token generation request.</param>
    /// <returns>Generated JWT token.</returns>
    public string GenerateToken(GenerateTokenRequest request)
    {
        return GenerateToken(request, DateTime.UtcNow.AddMinutes(_settings.ExpiryInMinutes));
    }

    /// <summary>
    /// Generates a JWT token with specific expiration time.
    /// </summary>
    /// <param name="request">Token generation request.</param>
    /// <param name="expirationTime">Token expiration time.</param>
    /// <returns>Generated JWT token.</returns>
    public string GenerateToken(GenerateTokenRequest request, DateTime expirationTime)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.User);
        ArgumentNullException.ThrowIfNull(request.Roles);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, request.User.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, request.User.Email),
            new(ClaimTypes.Name, $"{request.User.FirstName} {request.User.LastName}"),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        claims.AddRange(request.Roles.Select(role =>
            new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: expirationTime,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
