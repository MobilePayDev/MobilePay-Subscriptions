## <a name="general-notes_authentication"></a>Authentication 


### Authorization

The MobilePay API Gateway is ensuring the authentication of all Subscriptions API requests. 


### <a name="openid-connect"></a>OpenID Connect
When the merchant is onboarded via https://admin.mobilepay.dk/, and has ordered Subscriptions, then you can continue with OIDC.  

[![](assets/images/OpenIdflowWithFIandAuthorize.png)](assets/images/OpenIdflowWithFIandAuthorize.png)

      
**The flow:**

In short - The flow is described in the following 5 steps:

[Step 1: Call /connect/authorize to initiate user login and consent](https://developer.mobilepay.dk/developersupport/openid/authorize/) 

The merchant must grant consent to Client_.   This consent is granted through mechanism in the [OpenID Connect](http://openid.net/connect/) protocol suite. <br /> The Client must initiate the [hybrid flow](http://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth) specified in OpenID connect. For __Subscriptions__ product the Client must request consent from the merchant using the `subscriptions` scope. You also need to specify `offline_access` scope, in order to get the refresh token.<br /> When user clicks on this button, merchant must do back-end call to  [`"/authorize"`](https://developer.mobilepay.dk/developersupport/openid/authorize/) endpoint for initiating  authentication flow. You need to wait for the response by listening on the redirect URI and get the Authorization Code. Our system will re-direct the merchant back to your system also using the redirect URL. 

[Step 2: Wait for the response by listening on the redirect URI and get the authorization code](https://developer.mobilepay.dk/developersupport/openid/getcode/) 

[Step 3: Exchange the authorization code for tokens using /connect/token](https://developer.mobilepay.dk/developersupport/openid/gettokens/) 

[Step 4: Keep the session alive by using the refresh token](https://developer.mobilepay.dk/developersupport/openid/getrefreshtokens/) 


[Step 5: Follow Best Practice](https://developer.mobilepay.dk/developersupport/openid/bestpractice/) 

 
An example of how to use OpenID connect in C# can be found [here](https://github.com/MobilePayDev/MobilePay-Invoice/tree/master/ClientExamples).


 

### OpenID configuration endpoints 
Find the configuration links below:

|Environment | Links |
|------------|-------|
|Sandbox    | Denmark <a href="https://sandprod-admin.mobilepay.dk/account/.well-known/openid-configuration">https://sandprod-admin.mobilepay.dk/account/.well-known/openid-configuration</a> <br> Finland <a href="https://sandprod-admin.mobilepay.fi/account/.well-known/openid-configuration">https://sandprod-admin.mobilepay.fi/account/.well-known/openid-configuration</a> |
|Production  | Denmark <a href="https://admin.mobilepay.dk/account/.well-known/openid-configuration">https://admin.mobilepay.dk/account/.well-known/openid-configuration</a> <br> Finland <a href="https://admin.mobilepay.fi/account/.well-known/openid-configuration">https://admin.mobilepay.fi/account/.well-known/openid-configuration</a>|


![](assets/images/OpenIdFlowWithFiandAuthorize.png)
      
### QuickStart: follow our QuickStart to start building your integration

- More information about integration steps are  [here](https://developer.mobilepay.dk/subscriptions-main)
- Pick an OpenID Connect library: we recommend <a href="https://github.com/IdentityModel/IdentityModel.OidcClient2">Certified C#/NetStandard OpenID Connect Client Library for native mobile/desktop Applications</a> 
- FAQ's for OpenID Connect <a href="https://developer.mobilepay.dk/faq/oidc">here</a>
- Integration is based on common standard OpenID Connect. You can find more [here](https://developer.mobilepay.dk/developersupport/openid/). 
- Video tutorial [here](https://developer.mobilepay.dk/developersupport/openid/tutorial)

### <a name="openid-connect-libraries"></a>Implementing OpenID Connect protocol
There are many OpenID Connect certified libraries for different platforms, so you just have to chose the one, that suits you best [from this list](http://openid.net/developers/certified/#RPLibs).
To be able to use and connect to the API there are few requirements. In order to authenticate to the API, all requests to the API must contain at least three authentication headers:
1. `x-ibm-client-id`
2. `x-ibm-client-secret`  
3. `Authorization` 

Creating an app in MobilePay Developer Portal will create a `x-ibm-client-id` and `x-ibm-client-secret` that should be used in all calls to the MobilePay Subscriptions API  


```console
$ curl --header "Authorization: Bearer <token>" --header 'x-ibm-client-id: client-id' --header 'x-ibm-client-secret: client-secret' --url https://<mobile-pay-root>/api/merchants/me/resource
```
### Communication Security

The MobilePay Subscriptions API uses TLS for communication security and data integrity (secure channel between the client and the 
backend). The API currently uses TLS 1.2. It is the integrator's responsibility to plan for an upgrade to TLS 1.3, when
TLS 1.2 is deprecated. 

### IP Address 

As an external party, you might need to modify your firewall rules to allow traffic from  212.93.32.0/19 and 185.218.228.0/22 . Otherwise our traffic may be blocked, and our services stop working.

[![](assets/images/Preview-MP-logo-and-type-horizontal-blue.png)](assets/images/Preview-MP-logo-and-type-horizontal-blue.png)
