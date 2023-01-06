using EducationSystem.Enums;

namespace EducationSystem.Interfaces.IServices;

public interface IFileService
{
    /// <summary>
    /// Сохранение файлов
    /// </summary>
    /// <param name="file"></param>
    /// <param name="fileType"></param>
    /// <returns>Возвращает относительный путь файла</returns>
    Task<string> SaveFile(IFormFile file, AppFileType fileType);
    
    /// <summary>
    /// Удаление файлов
    /// </summary>
    /// <param name="pathName">путь к файлу (как привало это имя файла)</param>
    /// <returns></returns>
    void DeleteFile(string pathName);

    /// <summary>
    /// Удаление файлов
    /// </summary>
    /// <param name="pathName">путь к файлу (как привало это имя файла)</param>
    /// <returns></returns>
    void DeleteFileRange(List<string> pathName);
}