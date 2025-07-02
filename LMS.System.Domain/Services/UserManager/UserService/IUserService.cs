using System.Threading.Tasks;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.UserManager
{
    /// <summary>
    /// Интерфейс сервиса для управления пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получает пользователя по email.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <returns>Найденный пользователь или null.</returns>
        Task<User?> GetUserByEmailAsync(string email);

        /// <summary>
        /// Проверяет, занят ли email.
        /// </summary>
        /// <param name="email">Email для проверки.</param>
        /// <returns>True если email занят, иначе False.</returns>
        Task<bool> IsEmailTakenAsync(string email);

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="user">Данные пользователя.</param>
        /// <returns>Task.</returns>
        Task CreateUserAsync(User user);

        /// <summary>
        /// Проверяет валидность учетных данных.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>True если учетные данные верны, иначе False.</returns>
        Task<bool> ValidateCredentialsAsync(string email, string password);
    }
}
