using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers._Dev;

[ApiController]
[Route("api/dev")]
public class DevController : ControllerBaseExtension
{
    private readonly EducationSystemDbContext _context;
    private readonly UserManager<User> _userManager;

    public DevController(EducationSystemDbContext context,
        UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("seed-db")]
    [SwaggerOperation(
        Summary = "Заполнить дб данными",
        Description = "Заполнить дб данными",
        OperationId = "Dev.Post.Db",
        Tags = new[] { "Dev" }
)]
    public async Task<IActionResult> PostSeedDb()
    {
        return Ok();
    }
}