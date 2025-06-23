using System.Collections.Generic;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.Auth;

/// <summary>
/// Service interface for JWT token generation.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generates a JWT token for the specified user with given roles.
    /// </summary>
    /// <param name="user">The user for whom to generate the token.</param>
    /// <param name="roles">List of roles assigned to the user.</param>
    /// <returns>Generated JWT token as a string.</returns>
    string GenerateToken(User user, IList<string> roles);
}
