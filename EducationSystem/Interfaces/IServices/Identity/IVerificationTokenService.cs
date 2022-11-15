namespace EducationSystem.Interfaces.IServices.Identity;

public interface IVerificationTokenService
{
    /// <summary>
    /// Сохранение данных в базу и создание токена
    /// </summary>
    /// <param name="token"></param>
    /// <param name="verifiedData">Данные, охраняемые токеном</param>
    /// <returns>строка токена</returns>
    Task<string> SaveDataAndCreateTokenAsync(string token, object verifiedData);
        
    /// <summary>
    /// Получить данные токена
    /// </summary>
    /// <param name="token">строка токена</param>
    /// <param name="data">данные токена</param>
    /// <returns>токен найден</returns>
    bool TryGetData<T>(string token, out T data);
        
    /// <summary>
    /// Удалить токен
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task DeleteTokenAsync(string token);

    /// <summary>
    /// Сгенерировать токен
    /// </summary>
    /// <returns></returns>
    string GenerateToken(int tokenLength = 128);
}