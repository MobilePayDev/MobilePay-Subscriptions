
## <a name="overview"></a> Overview 

Billing your customers has never been easier before. This document explains how to make a technical integration to the MobilePay Subscription API. The audience for this document is either technical integrators acting on behalf of merchants or merchants themselves. You can find more information on our <a href="https://developer.mobilepay.dk/subscriptions-main">Developer Portal</a>.

Our MobilePay Subscriptions REST api enables you to:

1. Establish and manage **Agreements** between you, the **Merchant**, and MobilePay **Users**.
2. Create **Subscription Payments** in relation to an established **Agreement** and get notified about the status via REST callbacks. **Subscription Payments** are requested 1 day before the actual booking date - no manual user confirmation required!

This document does not include detailed specification of the endpoints, responses and response codes. This information can be found in the API section of the Developer Portal.

### <a name="overview_onboarding"></a>Merchant onboarding

You enroll to the Subscriptions Production via <a href="https://mobilepay.dk/da-dk/Pages/mobilepay.aspx">www.MobilePay.dk</a> or the MobilePay  Administration portal. Then you get access to the MobilePay Sandbox environment, where you can test the API. The Sandbox environment is located on <a href="https://sandbox-developer.mobilepay.dk/">The Sandbox Developer Portal </a> 
You can use the Subscriptions API in test mode, which does not affect your live data or interact with the banking networks. 
- Read the FAQ's for Subscriptions <a href="https://developer.mobilepay.dk/faq/subscriptions">here</a>
- Billing your customers with MobilePay Subscriptions is easy using our [API](https://developer.mobilepay.dk/product).

Once you sign-up you'll receive a welcome email containing everything you need to  get going right away. While we encourage you to start exploring our API right away, we highly recommend getting in touch with us at developer@mobilepay.dk before you go too far down your integration path. MobilePay has dedicated technical resources available to help you plan and build the right integration, avoid pitfalls, and get live as quickly as possible.

## The MobilePay Developer Portal
The MobilePay Developer Portal is a site where you will be able to find information about the products and available APIs and their documentations.
It exposes live documentation that can be used for development. How to get access to the Developer Portal is described [here](https://developer.mobilepay.dk/subscriptions-getting-started).

The MobilePay Developer Portal is available at the following addresses:

| Environment  | Endpoint |
|--------------|-------------|
| Sandbox/Test | [https://sandbox-developer.mobilepay.dk](https://sandbox-developer.mobilepay.dk)     |
| Production   | [https://developer.mobilepay.dk](https://developer.mobilepay.dk)     |

[![](assets/images/Preview-MP-logo-and-type-horizontal-blue.png)](assets/images/Preview-MP-logo-and-type-horizontal-blue.png)


