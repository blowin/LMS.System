using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// .
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// .
    /// </summary>
    public string Key { get; set; } = null!;

    /// <summary>
    /// .
    /// </summary>
    public string Issuer { get; set; } = null!;

    /// <summary>
    /// .
    /// </summary>
    public string Audience { get; set; } = null!;

    /// <summary>
    /// .
    /// </summary>
    public int ExpiryInMinutes { get; set; }
}
