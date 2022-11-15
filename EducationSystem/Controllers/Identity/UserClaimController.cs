using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Identity;

[Authorize]
[ApiController]
[Route("api/claims/user")]
public class UserClaimController : ControllerBaseExtension
{
    private readonly IUserClaimService _userClaimService;

    public UserClaimController(IUserClaimService userClaimService)
    {
        _userClaimService = userClaimService;
    }

    [HttpGet]
    [Route("user/{id}/claims")]
    [SwaggerOperation(
        Summary = "Получение списка claims пользователя по его id",
        Description = "Получение списка claims пользователя по его id",
        OperationId = "Claim.User.Get.List",
        Tags = new[] { "Claim.User" }
    )]
    public async Task<IActionResult> GetListClaimByUserId([FromRoute] int id)
    {
        var response = await _userClaimService.GetListClaimByUserIdAsync(id);

        return Response(response);
    }

    [HttpPost]
    [Route("user/{id}/claims")]
    [SwaggerOperation(
        Summary = "Добавление Claims Пользователю по его id",
        Description = "Добавление Claims Пользователю по его id",
        OperationId = "Claim.User.Create",
        Tags = new[] { "Claim.User" }
    )]
    public async Task<IActionResult> AddClaimsUser([FromRoute] int id, [FromBody] List<string> claims)
    {
        var response = await _userClaimService.AddClaimsUserAsync(id, claims);

        return Response(response);
    }

    [HttpDelete]
    [Route("user/{id}/claims")]
    [SwaggerOperation(
        Summary = "Удаление claim по id пользователя",
        Description = "Удаление claim по id пользователя",
        OperationId = "Claim.User.Delete.ById",
        Tags = new[] { "Claim.User" }
    )]
    public async Task<IActionResult> DeleteClaimUser([FromRoute] int id, [FromQuery] string claimName)
    {
        var response = await _userClaimService.DeleteClaimUserAsync(id, claimName);

        return Response(response);
    }
}