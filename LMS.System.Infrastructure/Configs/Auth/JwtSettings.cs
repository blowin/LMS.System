using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Infrastructure.Configs.Auth;

/// <summary>
/// Настройки JWT-аутентификации.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Ключ для подписи JWT токенов.
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    /// Издатель токена.
    /// </summary>
    public required string Issuer { get; set; }

    /// <summary>
    /// Аудитория токена.
    /// </summary>
    public required string Audience { get; set; }

    /// <summary>
    /// Время жизни токена в минутах.
    /// </summary>
    public required int ExpiryInMinutes { get; set; }
}
