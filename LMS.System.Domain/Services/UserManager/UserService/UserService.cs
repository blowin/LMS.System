using System.Threading.Tasks;
using BCrypt.Net;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Domain.Services.DBServices.Models;
using LMS.System.Domain.Services.UserManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;

namespace LMS.System.Domain.Services.UserManager
{
    /// <summary>
    /// Сервис для управления пользователями.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ApplicationContext _dbContext;
        private readonly ISystemClock _systemClock;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="dbContext">Контекст базы данных.</param>
        /// <param name="systemClock">Системные часы.</param>
        public UserService(ApplicationContext dbContext, ISystemClock systemClock)
        {
            _dbContext = dbContext;
            _systemClock = systemClock;
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <inheritdoc/>
        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _dbContext.Users
                .AnyAsync(u => u.Email == email);
        }

        /// <inheritdoc/>
        public async Task CreateUserAsync(User user)
        {
            user.CreatedAt = _systemClock.UtcNow.UtcDateTime;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
