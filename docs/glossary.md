
# Glossary of Terms

| Term | Description |
|------|-------------|
| Agreement| An agreement in which merchant can provide subscription service. |
| agreement_id         | Subscription payment ID on the MobilePay side. MobilePay generates the agreement_id. It does not change regardless of what happens to the agreement. agreement_id is the counterpart to the external_id on your side.|
| Client | Client is used interchangeably for the application that calls the MobilePay Subscriptions API. Client is often used when only discussing the software.|
| Customer        | The customer is the user who wants to pay for goods and services with MobilePay Subscriptions. |
| Capture          | Capture is the process by which payments are secured once the payment has been authorized, i.e. a reservation has been made. Merchant handles Capture & Reserve for OneOff payments. When Merchant or Integrator receives a callback about successfully reserved payment, then it’s time to capture the money. MobilePay handles Capture & Reserve for Subscription payments |
| external_id                |  Agreement ID on the merchant’s side. It is meant as a unique identifier, chosen by the merchant, which shouldn’t change. It should stay the same, so we can trace the full history of the agreement. It is included in the request body of the success and cancel callback. Two different agreements should not have the same external_id  |
| Merchant         | The merchant is the company that wants to receive payments for goods and services from MobliePay users.|
| Reservation     | A reservation is a pre-authorization which guarantees that the user has sufficient funds to pay for the given transaction. Uncaptured one-off payments expire after 14 days. |
| payment_id        |  Subscription payment ID on the MobilePay side. MobilePay generates the agreement_id. It is a GUID|
| Payment - Subscription        | A payment request from the merchant, which is used Merchant needs to charge periodic payment. The customer does not need to swipe to accept agreement. |
|Payment - OneOff| Customer action performed in order to initiate payment. The customer can create agreements with an initial OneOff payment, for example when the user wants to set up an agreement and you want to charge upfront. or request a OneOff payment on an existing agreement|
| payment_status_callback_url         | Once the payment or agreement changes state, a callback will be done to the callback address.  We cannot send callbacks to you, unless you have set the payment_status_callback. It does not need to be whitelisted at MobilePay side.|
| SubscriptionProviderId   | The SubscriptionsProvider ID is the actual service provider name under which they send subscriptions payments. Each subscriptions provider contains its own address information, homepage url and etc. For example, if a single merchant has several brands, each brand would be a subscription provider. Merchant can create new Subscriptions Provider on https://admin.mobilepay.dk/  | 
| Integrator    | The company that develops the client and calls the MobilePay Subscriptions API on behalf of the merchant. Sometimes the merchant acts as integrator.  |
| VAT-number   | In Denmark, this is the CVR-number. In Finland, this is the Y-tunnus. Both refer to the official business ID.| 



