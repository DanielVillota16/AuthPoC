using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace AuthPoC.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        ];

    public static IEnumerable<ApiResource> ApiResources =>
        [
            new ("myApi", "My API")
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ("myApi.read"),
            new ("myApi.write")
        ];

    public static IEnumerable<Client> Clients =>
        [
            new ()
            {
                ClientId = "auth-poc",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                // ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "openid", "profile", "myApi.write", "myApi.read" },
                RedirectUris = { "http://localhost:5050/callback" },
                PostLogoutRedirectUris = { "http://localhost:5050" },
                AllowedCorsOrigins = { "http://localhost:5050" },
                AllowAccessTokensViaBrowser = true,
                RequirePkce = true,
                AllowOfflineAccess = true,
                RequireClientSecret = false,
            }
        ];

    public static List<TestUser> Users =>
        [
            new ()
            {
                SubjectId = "1",
                Username = "user",
                Password = "password",
                Claims =
                [
                    new Claim("role", "admin")
                ]
            }
        ];
}