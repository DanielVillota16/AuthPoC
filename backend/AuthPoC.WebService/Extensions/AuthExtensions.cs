using AuthPoC.WebService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Microsoft.Extensions.DependencyInjection;

public static class AuthExtensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        var defaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "api1")
            .Build();

        var requiredScopePolicy = new RequiredScopePolicy(defaultPolicy.Requirements, defaultPolicy.AuthenticationSchemes);

        services.AddSingleton(requiredScopePolicy);

        // Register authorization handlers and providers.
        services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

        return services;
    }

}