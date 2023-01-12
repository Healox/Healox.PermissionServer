using Duende.IdentityServer.Models;

namespace Healox.PermissionServer.Sample.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "Healox.PermissionServer.Sample.API, API"),
                //new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // ASP.NET Core Web App, an interactive client using code flow + pkce
                new Client
                {
                    ClientId = "web",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "api1" }
                },
            };
    }
}