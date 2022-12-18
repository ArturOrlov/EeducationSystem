using EducationSystem.Extension;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EducationSystem.Controllers.Identity;

[Authorize]
[ApiController]
[Route("api/claims")]
public class ClaimController : ControllerBaseExtension
{
    private readonly IClaimService _claimService;

    public ClaimController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    [HttpGet]
    [Route("")]
    [SwaggerOperation(
        Summary = "Получение списка всех имеющихся claims",
        Description = "Получение списка всех имеющихся claims",
        OperationId = "Claim.Get",
        Tags = new[] { "Claim.User" }
    )]
    public IActionResult GetListClaims()
    {
        var response = _claimService.GetListClaims();

        return Response(response);
    }
}