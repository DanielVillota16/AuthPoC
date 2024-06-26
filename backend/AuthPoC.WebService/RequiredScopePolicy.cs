using Microsoft.AspNetCore.Authorization;

namespace AuthPoC.WebService;
public class RequiredScopePolicy(IEnumerable<IAuthorizationRequirement> requirements, IEnumerable<string> authenticationSchemes)
    : AuthorizationPolicy(requirements, authenticationSchemes) { }