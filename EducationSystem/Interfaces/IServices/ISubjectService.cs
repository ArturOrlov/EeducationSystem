﻿using EducationSystem.Dto.Subject;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices;

public interface ISubjectService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="subjectId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetSubjectDto>> GetSubjectByIdAsync(int subjectId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="subjectId"></param>
    /// <returns></returns>
    Task<BaseResponse<SubjectWithCourseDto>> GetSubjectWithCourseAsync(int subjectId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetSubjectDto>>> GetSubjectByPaginationAsync(BasePagination request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetSubjectDto>> CreateSubjectAsync(CreateSubjectDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="subjectId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetSubjectDto>> UpdateSubjectByIdAsync(int subjectId, UpdateSubjectDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="subjectId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteSubjectByIdAsync(int subjectId);
}