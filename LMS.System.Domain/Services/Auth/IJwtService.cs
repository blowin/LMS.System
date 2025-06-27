using System;
using System.Collections.Generic;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// Request DTO for JWT token generation.
/// </summary>
public class GenerateTokenRequest
{
    /// <summary>
    /// User for whom to generate the token.
    /// </summary>
    public required User User { get; set; }

    /// <summary>
    /// Roles assigned to the user.
    /// </summary>
    public required IList<string> Roles { get; set; }
}

/// <summary>
/// Service interface for JWT token generation.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generates a JWT token for the specified request.
    /// </summary>
    /// <param name="request">Token generation request containing user and roles information.</param>
    /// <returns>Generated JWT token as a string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when request is null or contains null properties.</exception>
    string GenerateToken(GenerateTokenRequest request);

    /// <summary>
    /// Generates a JWT token with explicit expiration time.
    /// </summary>
    /// <param name="request">Token generation request containing user and roles information.</param>
    /// <param name="expirationTime">Absolute expiration time in UTC.</param>
    /// <returns>Generated JWT token as a string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when request is null or contains null properties.</exception>
    /// <exception cref="ArgumentException">Thrown when expirationTime is not in UTC format.</exception>
    string GenerateToken(GenerateTokenRequest request, DateTime expirationTime);
}
