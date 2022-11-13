using System.Reflection;
using Mapster;
using MapsterMapper;

namespace EducationSystem.Extension;

public static class MapsterExtension
{
    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        
        var mapperConfig = new Mapper(config);
        services.AddSingleton<IMapper>(mapperConfig);
        
        return services;
    }
}