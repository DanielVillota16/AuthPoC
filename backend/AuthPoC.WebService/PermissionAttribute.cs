using Microsoft.AspNetCore.Authorization;

namespace AuthPoC.WebService;

public class PermissionAttribute : AuthorizeAttribute
{
    /// <summary>
    /// Initializes the PermissionAttribute instance.
    /// </summary>
    /// <param name="screenName">The sreen name trying to access.</param>
    /// <param name="resource">The screen's resource trying to access.</param>
    public PermissionAttribute(string screenName, string resource)
    {
        Policy = $"HasPermissionPolicy|{screenName}|{resource}";
    }

    /// <summary>
    /// Initializes the PermissionAttribute instance.
    /// </summary>
    /// <param name="screenName">The sreen name trying to access.</param>
    /// <param name="resource">The screen's resource trying to access.</param>
    /// <param name="scopes">The scopes trying to access.</param>
    public PermissionAttribute(string screenName, string resource, params string[] scopes)
    {
        Scopes = scopes;
        Policy = $"HasPermissionPolicy|{screenName}|{resource}|{ string.Join("|", scopes)}";   
    }

    public string[]? Scopes { get; private set; } = null;
}