MobilePay  Example

In order to run this example, you need first need to have a Client that allows you to request scopes on behalf of merchants in MobilePay. This client will need to be configured with a whitelisted RedirectUri in your system. This is important because we will need the value to start the consent flow.

 **1. Prerequisites to going through the consent flow:**
- RedirectUri
- ClientId
- ClientSecret

 **2. Granting Consent** 
 
When you have your prerequisite values ready, go to the OidcClientConfigurationFactory in the Configuration folder.

Fill out the OICDClientOptions (Below is an example from our SandBox environment)

    {
      Authority = "https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect", 
      ClientId = "<Your-Client-Id>",
      ClientSecret = "<Your-Client-Secret>",
      Scope = "openid offline_access invoice subscriptions transactionreporting", 
    }
Then go to the Program.cs file. At the top you should paste the RedirectUri for your client. In this example we spawn a HTTPListener to listen fo the responses, and we have configured our client to allow our local address as a valid RedirectUri.

    private const string RedirectUri = "http://127.0.0.1:7890/"; 
    
Now you should be able to run the program and go through the MobilePay consent flow

**2.1) Optional: Vat number as part of request**
To grant consent to a specific merchant, you can optionally provide a vat number when starting the consent flow.
In the program.cs, modify the StartConsentFlow() call with the vatNumber parameter:

    client.StartConsentFlow("<vat-number>");
**3) Refreshing AccessTokens**
First you will need to go through the consent flow as described in 1 and 2. After successfully granting a consent, you should have been granted a tokenpair (access_token and refresh_token) written in your console output.

To use a refresh_token, copy the value and replace the line in the Program.cs file

    client.StartConsentFlow();
with

    client.UseRefreshToken("<refresh_token>");
Starting the program after doing this, should grant you a refreshed tokenpair in the console output.
