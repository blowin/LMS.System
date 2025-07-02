using System;
using System.Collections.Generic;
using LMS.System.Domain.Services.DBServices.Models;

namespace LMS.System.Domain.Services.AccountManagers.Auth
{
    /// <summary>
    /// Модель запроса для генерации JWT токена.
    /// </summary>
    public class GenerateTokenRequest
    {
        /// <summary>
        /// Пользователь, для которого генерируется токен.
        /// </summary>
        public required User User { get; set; }

        /// <summary>
        /// Роли пользователя, которые будут включены в токен.
        /// </summary>
        public required IList<string> Roles { get; set; }
    }

    /// <summary>
    /// Интерфейс сервиса для работы с JWT токенами.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Генерирует JWT токен (время жизни берется из конфигурации).
        /// </summary>
        /// <param name="request">Данные пользователя и его роли.</param>
        /// <returns>Сгенерированный токен в формате строки.</returns>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если запрос или обязательные параметры равны null.
        /// </exception>
        string GenerateToken(GenerateTokenRequest request);
    }
}
