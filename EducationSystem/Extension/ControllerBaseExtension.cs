using EducationSystem.Entities.Base;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Extension;

public class ControllerBaseExtension : ControllerBase
{
    protected new ObjectResult Response<T>(BaseResponse<T> response) where T : class
    {
        if (response.IsError)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}