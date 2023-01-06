using EducationSystem.Dto.Material.LaboratoryWork;
using EducationSystem.Entities.Base;
using EducationSystem.Enums;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Material.LaboratoryWork;
using MapsterMapper;

namespace EducationSystem.Services.Material.LaboratoryWork;

public class LaboratoryWorkService : ILaboratoryWorkService
{
    private readonly ILaboratoryWorkRepository _laboratoryWorkRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public LaboratoryWorkService(ILaboratoryWorkRepository laboratoryWorkRepository,
        ICourseRepository courseRepository, 
        IFileService fileService,
        IMapper mapper)
    {
        _laboratoryWorkRepository = laboratoryWorkRepository;
        _courseRepository = courseRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetLaboratoryWorkDto>> GetLaboratoryWorkByIdAsync(int laboratoryWorkId)
    {
        var response = new BaseResponse<GetLaboratoryWorkDto>();

        var laboratoryWork = await _laboratoryWorkRepository.GetByIdAsync(laboratoryWorkId);
        
        if (laboratoryWork == null)
        {
            response.IsError = true;
            response.Description = $"Лабораторная работа с id - {laboratoryWorkId} не найден";
            return response;
        }

        var mapLaboratoryWork = _mapper.Map<GetLaboratoryWorkDto>(laboratoryWork);

        response.Data = mapLaboratoryWork;
        return response;
    }

    public async Task<BaseResponse<List<GetLaboratoryWorkDto>>> GetLaboratoryWorkByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetLaboratoryWorkDto>>();

        var laboratoryWork = _laboratoryWorkRepository.Get(_ => true, request);

        if (!laboratoryWork.Any())
        {
            return response;
        }

        var mapLaboratoryWorks = _mapper.Map<List<GetLaboratoryWorkDto>>(laboratoryWork);

        response.Data = mapLaboratoryWorks;
        return response;
    }

    public async Task<BaseResponse<GetLaboratoryWorkDto>> CreateLaboratoryWorkAsync(CreateLaboratoryWorkDto request)
    {
        var response = new BaseResponse<GetLaboratoryWorkDto>();
        
        var checkName = _laboratoryWorkRepository.Get(l => l.Name == request.Name).FirstOrDefault();;

        if (checkName != null)
        {
            response.IsError = true;
            response.Description = $"Лабораторная работа с именем - '{request.Name}' уже есть";
            return response;
        }

        var course = await _courseRepository.GetByIdAsync(request.CourseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {request.CourseId} не найден";
            return response;
        }
        
        var newLaboratoryWork = _mapper.Map<Entities.DbModels.Material.LaboratoryWork.LaboratoryWork>(request);
        
        if (request.Material != null)
        {
            var filePath = await _fileService.SaveFile(request.Material, AppFileType.Material);
            newLaboratoryWork.MaterialUrl = filePath;
        }
        else
        {
            newLaboratoryWork.MaterialUrl = string.Empty;
        }
        
        await _laboratoryWorkRepository.CreateAsync(newLaboratoryWork);
        
        var mapTest = _mapper.Map<GetLaboratoryWorkDto>(newLaboratoryWork);
        
        response.Data = mapTest;
        return response;
    }

    public async Task<BaseResponse<GetLaboratoryWorkDto>> UpdateLaboratoryWorkByIdAsync(int laboratoryWorkId, UpdateLaboratoryWorkDto request)
    {
        var response = new BaseResponse<GetLaboratoryWorkDto>();
        
        var laboratoryWork = await _laboratoryWorkRepository.GetByIdAsync(laboratoryWorkId);

        if (laboratoryWork == null)
        {
            response.IsError = true;
            response.Description = $"Лабораторная работа с id - {laboratoryWorkId} не найден";
            return response;
        }
        
        if (!string.IsNullOrEmpty(request.Name) && request.Name != laboratoryWork.Name)
        {
            var checkName = _laboratoryWorkRepository.Get(l => l.Name == request.Name).FirstOrDefault();

            if (checkName != null)
            {
                response.IsError = true;
                response.Description = $"Лабораторная работа с именем - '{request.Name}' уже есть";
                return response;
            }
        }

        if (request.CourseId != laboratoryWork.CourseId)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            if (course == null)
            {
                response.IsError = true;
                response.Description = $"Курс с id - {request.CourseId} не найден";
                return response;
            }
            
            laboratoryWork.CourseId = request.CourseId;
        }

        if (request.Material != null)
        {
            _fileService.DeleteFile(laboratoryWork.MaterialUrl);
            var filePath = await _fileService.SaveFile(request.Material, AppFileType.Image);
            laboratoryWork.MaterialUrl = filePath;
        }

        if (request.IsActive != laboratoryWork.IsActive)
        {
            laboratoryWork.IsActive = request.IsActive;
        }

        laboratoryWork.UpdatedAt = DateTime.Now;
        await _laboratoryWorkRepository.UpdateAsync(laboratoryWork);
        
        var mapLaboratoryWork = _mapper.Map<GetLaboratoryWorkDto>(laboratoryWork);
        
        response.Data = mapLaboratoryWork;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteLaboratoryWorkByIdAsync(int laboratoryWorkId)
    {
        var response = new BaseResponse<string>();

        var laboratoryWork = await _laboratoryWorkRepository.GetByIdAsync(laboratoryWorkId);

        if (laboratoryWork == null)
        {
            response.IsError = true;
            response.Description = $"Лабораторная работа с id - {laboratoryWorkId} не найден";
            return response;
        }

        if (!string.IsNullOrEmpty(laboratoryWork.MaterialUrl))
        {
            _fileService.DeleteFile(laboratoryWork.MaterialUrl);
        }

        await _laboratoryWorkRepository.DeleteAsync(laboratoryWork);

        response.Data = "Удалено";
        return response;
    }
}