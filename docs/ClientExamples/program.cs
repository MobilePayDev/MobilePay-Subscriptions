using System;
using System.Net;
using ConnectClientExample.Configuration;
using ConnectClientExample.Helpers;
using IdentityModel.OidcClient;

namespace ConnectClientExample
{
    public static class Program
    {
        private const string RedirectUri = "http://127.0.0.1:7890/";

        public static void Main()
        {
            ConfigureSslProtocol();

            Console.WriteLine("+-----------------------+");
            Console.WriteLine("|  Sign in with OIDC    |");
            Console.WriteLine("+-----------------------+");
            Console.WriteLine("");
            Console.WriteLine("Press any key to sign in...");
            Console.ReadKey();

            HttpListenerHelpers.StartHttpListener(RedirectUri);

            var client = new OidcClient(OidcClientConfigurationFactory.CreateClientConfiguration(RedirectUri));
            client.StartConsentFlow();
            
            Console.ReadKey();
            HttpListenerHelpers.StopHttpListener();
        }
        
        private static void ConfigureSslProtocol()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }
    }
}
