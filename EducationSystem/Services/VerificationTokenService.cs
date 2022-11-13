using System.Security.Cryptography;
using System.Text.Json;
using EducationSystem.Constants;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IServices;

namespace EducationSystem.Services;

public class VerificationTokenService : IVerificationTokenService
{
    private readonly IVerificationTokenRepository _verificationTokenRepository;
    private readonly int _maxHoursLife = 1;

    public VerificationTokenService(IVerificationTokenRepository verificationTokenRepository,
        ISettingService settings)
    {
        _verificationTokenRepository = verificationTokenRepository;
        _maxHoursLife = settings.GetInt(EducationSystemSettings.VERIFICATION_TOKEN_LIFE).Result;
    }

    public async Task<string> SaveDataAndCreateTokenAsync(string token, object verifiedData)
    {
        var json = JsonSerializer.Serialize(verifiedData);
        var newVerificationToken = new VerificationToken(token, json);
        await _verificationTokenRepository.CreateAsync(newVerificationToken);
        return token;
    }

    public bool TryGetData<T>(string token, out T data)
    {
        data = default;
        
        var existedToken = _verificationTokenRepository.FindByTokenAsync(token, _maxHoursLife);
        
        if (existedToken == null)
        {
            return false;
        }
        
        data = JsonSerializer.Deserialize<T>(existedToken.Data);
        return true;
    }

    public async Task DeleteTokenAsync(string token)
    {
        var existedToken = _verificationTokenRepository.FindByTokenAsync(token, _maxHoursLife);
        
        if (existedToken != null)
        {
            await _verificationTokenRepository.DeleteAsync(existedToken);
        }
    }
        
    public string GenerateToken(int tokenLength = 128)
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var r = new Random((int) DateTime.Now.Ticks);
        string token = "";
        for (int i = 0; i < tokenLength; i++)
        {
            token += r.Next(0, 10).ToString();
        }

        var verificationToken = _verificationTokenRepository.FindByTokenAsync(token, _maxHoursLife);
        
        // В базе токены должны быть уникальными
        if (verificationToken != null)
        {
            return GenerateToken(tokenLength);
        }
                
        return token;
    }
}