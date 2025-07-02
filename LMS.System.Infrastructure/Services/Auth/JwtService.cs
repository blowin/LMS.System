using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.System.Domain.Services.AccountManagers.Auth;
using LMS.System.Domain.Services.DBServices.Models;
using LMS.System.Infrastructure.Configs.Auth;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LMS.System.Infrastructure.Services.Auth;

/// <summary>
/// Сервис для генерации JWT токенов.
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

    /// <summary>
    /// Генерирует JWT токен для пользователя.
    /// </summary>
    /// <param name="request">Запрос на генерацию токена.</param>
    /// <returns>Сгенерированный токен.</returns>
    public string GenerateToken(GenerateTokenRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.User == null)
        {
            throw new ArgumentNullException(nameof(request.User));
        }

        if (request.Roles == null)
        {
            throw new ArgumentNullException(nameof(request.Roles));
        }

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.User.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, request.User.Email),
            new Claim(ClaimTypes.Name, $"{request.User.FirstName} {request.User.LastName}"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        claims.AddRange(request.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: _systemClock.UtcNow.AddMinutes(_settings.ExpiryInMinutes).UtcDateTime,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
