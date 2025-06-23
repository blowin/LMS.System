using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.System.Domain.Services.DBServices.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// Service for generating JWT tokens.
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
    /// Generates JWT token for specified user with roles.
    /// </summary>
    /// <param name="user">User for whom to generate token.</param>
    /// <param name="roles">Roles assigned to the user.</param>
    /// <returns>Generated JWT token as string.</returns>
    public string GenerateToken(User user, IList<string> roles)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (roles == null)
        {
            throw new ArgumentNullException(nameof(roles));
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"), // Используем FirstName+LastName вместо UserName
        };

        foreach (var role in roles)
        {
            claims.Add(new(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
