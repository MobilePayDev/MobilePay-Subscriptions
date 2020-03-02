using System;
using IdentityModel.OidcClient;

namespace ConsoleClientExample.Helpers
{
    public class OidcClientHelpers
    {
        public static OidcClientOptions ConfigureOidcClient(string redirectUri)
        {
            var policy = new Policy { Discovery = { ValidateIssuerName = false, ValidateEndpoints = false } };

            return new OidcClientOptions
            {
                Authority = "https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect", // Sandbox oidc url
                ClientId = "<replace with your client id>", // TODO: Replace the ClientId with your specific ClientId
                ClientSecret = "<replace with your client secret>", // TODO: Replace the ClientSecret with your specific ClientSecret
                Scope = "openid invoice subscriptions",
                RedirectUri = redirectUri,
                Policy = policy,
                LoadProfile = false,
            };
        }

        public static void PrintLoginInformation(LoginResult result)
        {
            if (result.IsError)
            {
                Console.WriteLine("\n\nError:\n{0}", result.Error);
            }
            else
            {
                Console.WriteLine("\n\nClaims:");
                foreach (var claim in result.User.Claims)
                {
                    Console.WriteLine("{0}: {1}", claim.Type, claim.Value);
                }

                Console.WriteLine();
                Console.WriteLine("Access token:\n{0}", result.AccessToken);

                if (!string.IsNullOrWhiteSpace(result.RefreshToken))
                {
                    Console.WriteLine("Refresh token:\n{0}", result.RefreshToken);
                }
            }
        }
    }
}
