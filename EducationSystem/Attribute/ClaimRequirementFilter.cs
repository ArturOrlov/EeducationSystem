using System.Net;
using System.Security.Claims;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EducationSystem.Attribute;

public class ClaimRequirementFilter : Exception, IAsyncAuthorizationFilter
{
    private readonly Claim _claim;
    private readonly IUserService _userService;
        
    public ClaimRequirementFilter(Claim claims, IUserService userService)
    {
        _claim = claims;
        _userService = userService;
    }
        
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity != null)
        {
            var user = context.HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(user))
            {
                return;
            }
                
            var currentUser = await _userService.FindUser(user);
        
            if (!await _userService.AuthorizeClaimsAsync(currentUser.Data, _claim.Type))
            {
                context.Result = new ObjectResult(new BaseResponse<string>(true, "пошёл нахуй"))
                {
                    StatusCode = (int) HttpStatusCode.NotAcceptable,
                };
            }
        }
    }
}