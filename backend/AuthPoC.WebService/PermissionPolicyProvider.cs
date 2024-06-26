using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace AuthPoC.WebService;

public class PermissionPolicyProvider(IOptions<AuthorizationOptions> options, RequiredScopePolicy requiredScopePolicy) : IAuthorizationPolicyProvider
{
    private readonly AuthorizationPolicy defaultPolicy = requiredScopePolicy;

    private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; } = new DefaultAuthorizationPolicyProvider(options);

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => Task.FromResult(defaultPolicy);

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => Task.FromResult(defaultPolicy);

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        string[] policyNameSplitted = policyName.Split('|');

        if (policyName.StartsWith("HasPermissionPolicy"))
        {
            if (policyNameSplitted.Length == 3)
            {
                string screenName = policyNameSplitted[1];
                string resource = policyNameSplitted[2];

                var builder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);

                builder.AddRequirements(new PermissionRequirement(screenName, resource));

                return Task.FromResult(builder.Build());
            }
            else if (policyNameSplitted.Length > 3)
            {
                string screenName = policyNameSplitted[1];
                string resource = policyNameSplitted[2];
                string[] scopes = policyNameSplitted.Skip(3).ToArray();

                var builder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);

                builder.AddRequirements(new PermissionRequirement(screenName, resource, scopes));

                return Task.FromResult(builder.Build());
            }
        }

        return BackupPolicyProvider.GetPolicyAsync(policyName);
    }
}