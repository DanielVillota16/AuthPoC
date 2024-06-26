using Microsoft.AspNetCore.Authorization;

namespace AuthPoC.WebService;
public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    /// <summary>
    /// Authorice access if user has the screen and resource claims or  scope claims.
    /// </summary>   
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User.HasClaim(requirement.ScreenName, requirement.Resource) ||
            context.User.HasClaim(c => c.Type == "scope" && requirement.Scopes.Any(s => c.Value.Contains(s))))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}