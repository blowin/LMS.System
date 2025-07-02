using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LMS.System.Domain.Services.AccountManagers.Auth;

/// <summary>
/// Сервис для генерации и валидации JWT токенов.
/// </summary>
public class JwtService : IJwtService
{
    private readonly JwtSettings _settings;
    private readonly ISystemClock _systemClock;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtService"/> class.
    /// </summary>
    /// <param name="settings">Настройки JWT.</param>
    /// <param name="systemClock">Системные часы.</param>
    public JwtService(IOptions<JwtSettings> settings, ISystemClock systemClock)
    {
        _settings = settings.Value;
        _systemClock = systemClock;
    }

    /// <inheritdoc/>
    public string GenerateToken(GenerateTokenRequest request)
    {
        if (request?.User == null || request.Roles == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, request.User.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, request.User.Email),
            new(ClaimTypes.Name, $"{request.User.FirstName} {request.User.LastName}"),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        claims.AddRange(request.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var expirationTime = _systemClock.UtcNow.AddMinutes(_settings.ExpiryInMinutes);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: expirationTime.UtcDateTime,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
