# Subscriptions Integrator 1.1 Release Notes

<div class='post-date'>14 May 2019</div>

- New Agreement parameters introduced for Merchants:
  - Agreement **retention_period_hours**. Merchant can set for how long agreement can't be Cancelled after signing it.
  - Agreement **disable_notification_management** push notification. Merchant can set if user can manage push notifications for this agreement.
  - Agreement frequency. Merchant can set new frequency: *daily*, *weekly*, or *flexible*. [See more](agreement#request-parameters).
- Subscription payment 8 days rule validation on payment creation is changed to 1 day.
- One-off without confirmation. Merchant can send one-off payment which we will attempt to automatically reseve, without user's confirmation. Updated request can be found [here](oneoffs#request-one-off-payment-on-an-existing-agreement).

New functionality will be available for all users from APP version 4.12.0.

<div class='post-date'>16 January 2019</div>

Invoices are now available for Subscriptions payments. [Add invoice details to subscription payment.](invoice)

<div class='post-date'>31 October 2018</div>

<div class='post-date'>23 August 2018</div>

We are excited to announce **Subscriptions Integrator 1.1** that is already available in [Sandbox](https://sandbox-developer.mobilepay.dk/).

ETA in production is **December 2018**.