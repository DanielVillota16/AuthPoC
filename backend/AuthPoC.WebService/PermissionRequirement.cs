using Microsoft.AspNetCore.Authorization;

namespace AuthPoC.WebService;

/// <summary>
/// Creates an instance with the information to use in the permission authorization handler.
/// </summary>
/// <param name="screenName">The sreen name trying to access.</param>
/// <param name="resource">The screen's resource trying to access.</param>
public class PermissionRequirement(string screenName, string resource, params string[] scopes) : IAuthorizationRequirement
{
    /// <summary>
    /// The sreen name trying to access.
    /// </summary>
    public string ScreenName { get; } = screenName;

    /// <summary>
    /// The screen's resource trying to access
    /// </summary>
    public string Resource { get; } = resource;
    /// <summary>
    /// 
    /// </summary>
    public string[] Scopes { get; } = scopes;
}