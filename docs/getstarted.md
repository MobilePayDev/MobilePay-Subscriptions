

## Get started

 - [ ] **1. Log-in** Go to  [sandbox-developer.mobilepay.dk](https://sandbox-developer.mobilepay.dk/ "Sandbox developer portal") and log in with your credentials.

 - [ ] **2. Create app** - My Apps > Create new App to register a new application. IMPORTANT: _Please make a note of your Client Secret as you will only see this once! You need to supply the `x-ibm-client-id` and `x-ibm-client-secret` when calling the api. You should always store the `x-ibm-client-id` in a secure location, and never reveal it publicly. If you suspect that the secret key has been compromised, you may reset it immediately by clicking the link on the application details page._

 - [ ] **3. Subscribe to APIs.**  To implement MobilePay Subscriptions, go to  [APIs](https://sandbox-developer.mobilepay.dk/product)  and subscribe to the following APIs:

-  Subscriptions
-  Subscriptions User Simulation

### Step 3 - Authentication

----------

Once you have obtained credentials via zip file, set a redirect URI and received test data, you can start implementing the OpenID Connect flow. Read more about OpenID Connect and the process
