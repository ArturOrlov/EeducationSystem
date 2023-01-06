using EducationSystem.Constants;
using EducationSystem.Enums;
using EducationSystem.Interfaces.IServices;

namespace EducationSystem.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webEnv;

    public FileService(IWebHostEnvironment webEnv)
    {
        _webEnv = webEnv;
    }

    public async Task<string> SaveFile(IFormFile file, AppFileType fileType)
    {
        // Определение директории сохранения файла
        string fileDirectory = fileType switch
        {
            AppFileType.Image => FileSettings.IMAGE_DIRECTORY,
            AppFileType.Material => FileSettings.MATERIAL_DIRECTORY,
            _ => FileSettings.IMAGE_DIRECTORY
        };

        // Генерируем имя файлу
        string newFileName = GenerateFilename() + Path.GetExtension(file.FileName);
        string savePath = Path.Combine(_webEnv.WebRootPath, fileDirectory);
        string filePath = Path.Combine(savePath, newFileName);

        // Если директория не существует, создать директорию.  
        if (Directory.Exists(savePath) == false)
        {
            Directory.CreateDirectory(savePath);
        }
            
        // Сохранить файл
        await using (var ms = new MemoryStream())
        {
            await file.CopyToAsync(ms);
            await File.WriteAllBytesAsync(filePath, ms.GetBuffer());
        }

        // Вернуть полный адрес файла.
        return Path.Combine(fileDirectory, newFileName);
    }

    public void DeleteFile(string pathName)
    {
        if (string.IsNullOrEmpty(pathName))
        {
            return;
        }
            
        var fullFilePath = Path.Combine(_webEnv.WebRootPath, pathName);
                    
        if (File.Exists(fullFilePath)) 
        {
            File.Delete(fullFilePath);
        }
    }

    public void DeleteFileRange(List<string> pathName)
    {
        foreach (var name in pathName)
        {
            if (string.IsNullOrEmpty(name))
            {
                continue;
            }
            
            var fullFilePath = Path.Combine(_webEnv.WebRootPath, name);
                    
            if (File.Exists(fullFilePath)) 
            {
                File.Delete(fullFilePath);
            }
        }
    }

    private string GenerateFilename()
    {
        var r = new Random(DateTime.Now.Millisecond);
        return DateTime.Now.Ticks.ToString() + r.Next(10000).ToString();
    }
}