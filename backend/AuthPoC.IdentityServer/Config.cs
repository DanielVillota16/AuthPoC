// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;

namespace AuthPoC.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new("api1", "My API", ["role", "auth-poc.weather-forecast"])
        ];

    public static IEnumerable<Client> Clients =>
        [
            // JavaScript Client
            new()
            {
                ClientId = "auth-poc",
                ClientName = "Auth PoC Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,

                RedirectUris = { "http://localhost:5050/callback" },
                PostLogoutRedirectUris = { "http://localhost:5050/index" },
                AllowedCorsOrigins = { "http://localhost:5050" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                }
            }
        ];
}
