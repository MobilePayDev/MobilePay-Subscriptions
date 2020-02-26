


## <a name="getstarted"></a> Get started

 1. **Read API documentation**. You'll find it in the  [APIs menu](https://developer.mobilepay.dk/product). *The API documentation provides insight into the structure of the API and will help you determine the best approach for integration as well as provide details on typical use cases.*

 2. **Log-in** Go to  [Sandbox developer portal](https://sandbox-developer.mobilepay.dk/ ) and log in with your credentials.

 3. **Create app** - My Apps > Create new App to register a new application. IMPORTANT: _Please make a note of your Client Secret as you will only see this once! You need to supply the `x-ibm-client-id` and `x-ibm-client-secret` when calling the api. You should always store the `x-ibm-client-id` in a secure location, and never reveal it publicly. If you suspect that the secret key has been compromised, you may reset it immediately by clicking the link on the application details page._

 4. **Subscribe to APIs.**  To implement MobilePay Subscriptions, go to  [APIs](https://sandbox-developer.mobilepay.dk/product)  and subscribe to the following APIs:
-  Subscriptions
-  Subscriptions User Simulation

### Step 2 - Authentication

----------
Once you have 

 - [ ] 1. Received OIDC credentials via zip file. The zip file will be sent via e-mail. The zip file is locked with a password. DeveloperSupport will provide the password via text message, due to security reasons.
 - [ ] 2. Received testmerchant 
 - [ ] 3. Have a whitelisted `redirect_uri`   

 you can start implementing the OpenID Connect flow. Read more about OpenID Connect and the process [here](https://mobilepaydev.github.io/MobilePay-Subscriptions/authentication)
 
 If you have any questions, please write to developer@mobilepay.dk

### Step 3 - Test

----------

 - [ ]  1. [ Create a new Agreement](https://mobilepaydev.github.io/MobilePay-Subscriptions/agreement#requests)  
 - [ ] 2. Accept the Agreement*  
  - [ ] 3. [Request a payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/payments#requests)  
 - [ ] 3. Decline the pending Subscriptions payment  
 - [ ] 4. Request a new Subscriptions  payment and wait until due date for this to execute  
 - [ ] 5. Cancel the Agreement once the Subscriptions payment has been executed
 - [ ] 6. [Refund the Subscriptions Payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/refund#requests)  
 - [ ] 7. [Request OneOff payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/oneoffs#requests)  
 - [ ] 8. Cancel the reserved/requested OneOff payment  
 - [ ] 10. [Request a new OneOff payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/oneoffs#requests)  
 - [ ] 9. Accept the OneOff payment*  
 - [ ] 12. [Capture the OneOff payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/oneoffs#capture)  

You must also have a setup for handling cancelled orders, and cancel reserved payments

----------
