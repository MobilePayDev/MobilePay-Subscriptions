using System;
using System.Collections.Generic;
using IdentityModel.OidcClient;

namespace ConnectClientExample.Helpers
{
    public static class OidcClientExtensions
    {
        public static async void StartConsentFlow(this OidcClient client, string vatNumber = null)
        {
            var extraParameters = CreateVatNumberExtraParameters(vatNumber);
            var state = await client.PrepareLoginAsync(extraParameters);

            BrowserHelper.OpenBrowser(state.StartUrl);

            var context = await HttpListenerHelpers.HttpListener.GetContextAsync();
            var formData = HttpListenerHelpers.GetRequestPostData(context.Request);
            
            var result = await client.ProcessResponseAsync(formData, state);
            await HttpListenerHelpers.SendHttpResponseToBrowser(context);
            
            ConsoleHelpers.BringConsoleToFront();
            ConsoleHelpers.PrintLoginInformation(result);
        }

        public static async void UseRefreshToken(this OidcClient client, string refreshToken)
        {
            var token = await client.RefreshTokenAsync(refreshToken);
            Console.WriteLine($"Access Token: {token.AccessToken}");
            Console.WriteLine($"Refresh Token: {token.RefreshToken}");
            Console.ReadLine();
        }
        
        private static Dictionary<string,string> CreateVatNumberExtraParameters(string vatNumber)
        {
            if (string.IsNullOrEmpty(vatNumber))
                return null;
            
            return new Dictionary<string, string>
            {
                {"merchant_vat", vatNumber}
            };
        }
    }
}
