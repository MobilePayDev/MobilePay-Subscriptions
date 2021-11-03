


# <a name="getstarted"></a> Get started

 1. **Read API documentation**. You'll find it in the  [APIs menu](https://developer.mobilepay.dk/product). *The API documentation provides insight into the structure of the API and will help you determine the best approach for integration as well as provide details on typical use cases.*

 2. **Log-in** Go to  [Sandbox developer portal](https://sandbox-developer.mobilepay.dk/ ) and log in with your credentials.

 3. **Create app** - My Apps > Create new App to register a new application. IMPORTANT: _Please make a note of your Client Secret as you will only see this once! You need to supply the `x-ibm-client-id` and `x-ibm-client-secret` when calling the api. You should always store the `x-ibm-client-id` in a secure location, and never reveal it publicly. If you suspect that the secret key has been compromised, you may reset it immediately by clicking the link on the application details page._

 4. **Subscribe to APIs.**  To implement MobilePay Subscriptions, go to  [APIs](https://sandbox-developer.mobilepay.dk/product)  and subscribe to the following APIs:
-  Subscriptions
-  Subscriptions User Simulation

## Step 2 - Authentication

----------
Once you have 

 - [ ] 1. Have a whitelisted `redirect_uri`   (Send an e-mail to developer@mobilepay.dk with your `redirect_uri` and we will revert back to you, once it has been whitelisted. 
 - [ ] 2. Received OIDC credentials via zip file. The zip file will be sent via e-mail. The zip file is locked with a password. DeveloperSupport will provide the password via text message, due to security reasons.
 - [ ] 3. Received testmerchant 

 you can start implementing the OpenID Connect flow. Read more about OpenID Connect and the process [here](https://mobilepaydev.github.io/MobilePay-Subscriptions/authentication)
 
 If you have any questions, please write to developer@mobilepay.dk

### Step 3 - Test

----------

 - [ ]  1. [ Create a new Agreement](https://mobilepaydev.github.io/MobilePay-Subscriptions/agreement#requests)  
 - [ ] 2. Accept the Agreement*  
  - [ ] 3. [Request a payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/payments#requests)  
 - [ ] 4. Decline the pending Subscriptions payment  
 - [ ] 5. Request a new Subscriptions  payment and wait until due date for this to execute  
 - [ ] 6. Cancel the Agreement once the Subscriptions payment has been executed
 - [ ] 7. [Refund the Subscriptions Payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/refund#requests)  
 - [ ] 8. [Request OneOff payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/oneoffs#requests)  
 - [ ] 9. Cancel the reserved/requested OneOff payment  
 - [ ] 10. [Request a new OneOff payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/oneoffs#requests)  
 - [ ] 11. Accept the OneOff payment*  
 - [ ] 12. [Capture the OneOff payment](https://mobilepaydev.github.io/MobilePay-Subscriptions/oneoffs#capture)  
 - [ ] 13. You must also have a setup for handling cancelled orders, and cancel reserved payments

----------

### Step 3 - Avoid Integration pitfalls 
 - [ ]  14. The Merchant _must not_ rely on `user-redirect`. All proper data comunication and logging and monitoring should be done thorugh callbacks and GET calls. 
 - [ ]  15. The MobilePay branding must be according to the [MobilePay design guidelines](https://developer.mobilepay.dk/design)
 - [ ]  16. The Merchant must have a way for the user to manage and stop subscription if the merchant is using cancel-redirect. This should result in a timely update of the MobilePay Agreement.
 - [ ]  17. Follow the [external_id recommendations](https://mobilepaydev.github.io/MobilePay-Subscriptions/payments#externalid-payment)
 - [ ]  18. Correctly handle callbacks from MobilePay, both for successful and unsuccessful payments. 


Once you have followed the steps above, you are ready to do the self-certification. Click the "I'm ready" button [here](https://developer.mobilepay.dk/subscriptions-verification#verification)  
