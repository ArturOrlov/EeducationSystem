using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Identity;

[Authorize]
[ApiController]
[Route("api/claims/role")]
public class RoleClaimController : ControllerBaseExtension
{
    private readonly IRoleClaimService _roleClaimService;

    public RoleClaimController(IRoleClaimService roleClaimService)
    {
        _roleClaimService = roleClaimService;
    }

    [HttpGet]
    [Route("role/{id}/claims")]
    [SwaggerOperation(
        Summary = "Получение списка claims роли по его id",
        Description = "Получение списка claims роли по его id",
        OperationId = "Claim.Role.Get.List",
        Tags = new[] { "Claim.Role" }
    )]
    public async Task<IActionResult> GetListClaimByUserId([FromRoute] int id)
    {
        var response = await _roleClaimService.GetListClaimByRoleIdAsync(id);

        return Response(response);
    }

    [HttpPost]
    [Route("role/{id}/claims")]
    [SwaggerOperation(
        Summary = "Добавление claims Роли по её id",
        Description = "Добавление claims Роли по её id",
        OperationId = "Claim.Role.Get.ById",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> AddClaimsRole([FromRoute] int id, [FromBody] List<string> claims)
    {
        var response = await _roleClaimService.AddClaimsRoleAsync(id, claims);

        return Response(response);
    }

    [HttpDelete]
    [Route("role/{id}/claims")]
    [SwaggerOperation(
        Summary = "Удаление claim роли по её id",
        Description = "Удаление claim роли по её id",
        OperationId = "Claim.Role.Get.ById",
        Tags = new[] { "Role" }
    )]
    public async Task<IActionResult> DeleteClaimRole([FromRoute] int id, [FromQuery] string claimName)
    {
        var response = await _roleClaimService.DeleteClaimRoleAsync(id, claimName);

        return Response(response);
    }
}