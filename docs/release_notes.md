# Subscriptions API Release Notes

<div class='post-date'>14 May 2019</div>

- New Agreement parameters introduced for Merchants:
 - Agreement **retention_period_hours**. Merchant can set for how long agreement can't be Cancelled by the user, after the user accepted the agreement, for up to 24 hours. This is an advantage in relation to street sales and when/if merchants offer cheaper prices, if the customer establishes a subscription agreement with the merchant. Before retention period has passed, then the cusomer will not be able to cancel an agreement	
    [![](assets/images/DeleteAgreement.png)](assets/images/DeleteAgreement.png)

  - Agreement **disable_notification_management** push notification. Merchant can set if their customer should be able to manage push notifications for an agreement or not. If the merchant choses so, then the push notification is not displayed when signing new agreement and when browsing agreement information. This parameter is not required, and the default value is 'false' [See more](https://github.com/MobilePayDev/MobilePay-Subscriptions/blob/master/docs/agreement.md#request-parameters).
  [![](assets/images/Disable_notification_management1.png)

  - Agreement frequency. We are now able to handle more agreement frequency parameters. Merchant can set new frequency: *daily*, *weekly*, or *flexible*. [See more](https://github.com/MobilePayDev/MobilePay-Subscriptions/blob/master/docs/agreement.md#request-parameters).
  
 # Payments 
- Subscription payment 8 days rule validation on payment creation is changed to 1 day.
- One-off without confirmation. Merchant can send one-off payment, which MobilePay will attempt to automatically reserve, without user's confirmation. Existing functionality of one-off with confirmation will still be available. Updated request can be found [here](oneoffs#request-one-off-payment-on-an-existing-agreement).


New functionality will be available for all users from APP version 4.12.0.

<div class='post-date'>16 January 2019</div>

Invoices are now available for Subscriptions payments. [Add invoice details to subscription payment.](invoice)
The merchant can link or attach a pdf to the customer. This makes it easy for the merchant to have the invoice available to the customer. 

<div class='post-date'>23 August 2018</div>

We are excited to announce **Subscriptions Integrator 1.1** that is already available in [Sandbox](https://sandbox-developer.mobilepay.dk/).

ETA in production is **December 2018**.
