using EducationSystem.Context;
using EducationSystem.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers._Dev;

[ApiController]
[Route("api/dev")]
public class DevController : ControllerBaseExtension
{
    private readonly EducationSystemDbContext _context;

    public DevController(EducationSystemDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    [Route("check/login/auth")]
    [SwaggerOperation(
        Summary = "Проверка авторизации с логином",
        Description = "Проверка авторизации с логином",
        OperationId = "Auth.Login",
        Tags = new[] { "Dev" }
    )]
    public async Task<IActionResult> LoginAuth()
    {
        return Ok();
    }
    
    [HttpGet]
    [AllowAnonymous]
    [Route("check/login/without-auth")]
    [SwaggerOperation(
        Summary = "Проверка авторизации без логина",
        Description = "Проверка авторизации без логина",
        OperationId = "Auth.Without.Login",
        Tags = new[] { "Dev" }
    )]
    public async Task<IActionResult> LoginWithoutAuth()
    {
        return Ok();
    }
}