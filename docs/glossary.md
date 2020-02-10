


# Glossary of Terms

| Term | Description |
|------|-------------|
| Agreement| An agreement in which merchant can provide subscription service to sell to Customers. |
| Agreement_id         | Subscription payment ID on the MobilePay side. MobilePay generates the agreement_id. It does not change regardless of what happens to the agreement. agreement_id is the counterpart to the external_id on your side.|
| API| Application Programming interface. |
| Callback | Once a payment status change happens, a callback will be done to the payment_status_callback_url |
| Client | Client is used interchangeably for the application that calls the MobilePay Subscriptions API. Client is often used when only discussing the software.|
| Customer        | The customer is the user who wants to pay for goods and services with MobilePay Subscriptions. |
| Capture          | Capture is the process by which payments are secured once the payment has been authorized, i.e. a reservation has been made. Merchant handles Capture for OneOff payments.  |
| CorrelationId          |  is an optional Guid heade value which can be used to link requests on your back-end system to MobilePay Subscriptions business transaction for a more convenient debugging |
| Description          | Additional information provided by the merchant to the user, that will be displayed on the Agreement screen. This is visible on the payment screen, so ensure that the information provided makes sense towards the Customer. |
| External_id (for agreement)                |  Agreement ID on the merchant’s side. It is meant as a unique identifier, chosen by the merchant, which shouldn’t change. Two different agreements should not have the same external_id It should stay the same, so we can trace the full history of the agreement. It is included in the request body of the success and cancel callback.   |
| External_id (for payment)                |  Payment ID on the merchant's side. The external_id will be included in the request body of the refund callback. If the merchant is using instant transfer, then the reference number will be the external_id for Subscription Payments and OneOff payments. The Customer can see the payment external_id  in the app.  |
| Integrator    | The company that develops the client and calls the MobilePay Subscriptions API on behalf of the merchant. Sometimes the merchant acts as integrator.  |
| JSON                |   JSON is the short form for Javascript Object Notation and is a text-based information format that follows Javascript object syntax.  |
| Merchant         | The merchant is the company that wants to receive payments for goods and services from MobliePay users.|
| MobilePay Admin Portal         | The merchant orders the product on the [https://admin.mobilepay.dk/](Portal) |
| Reservation     | A reservation is a pre-authorization which guarantees that the user has sufficient funds to pay for the given transaction. Uncaptured one-off payments expire after 14 days. |
| REST     |  It stands for "Representational State Transfer". |
| retention_period_hours     |  Merchant can set for how long agreement can’t be cancelled by the user, after the user accepted the agreement, for up to 24 hours. |
| Pagination_state        |  is a key, that indicates, how many pages have already been collected, and which pages are the next. With every request, you will receive a pagination_state, that you should use in the subsequent request.|
| Payment_id        |  Subscription payment ID on the MobilePay side. MobilePay generates the agreement_id. |
| Payment - Subscription        | A payment request from the merchant, which is used when the Merchant needs to charge for periodic payment. The customer does not need to swipe to accept the payment. |
|Payment - OneOff| Customer action performed in order to initiate payment. The customer can create agreements with an initial OneOff payment, for example when the user wants to set up an agreement and you want to charge upfront. or request a OneOff payment on an existing agreement|
| Payment_status_callback_url         | You need to configure the payment_status_callback_url before you start to send payment requests.Once the payment or agreement changes state, a callback will be done to the callback address.  You will not receive callbacks from MobilePay, unless you have set the payment_status_callback. It does not need to be whitelisted at MobilePay side.|
| SubscriptionProvider   | The SubscriptionsProvider is the actual service provider name. Each subscriptions provider contains its own address information, homepage url and etc. For example, if a single merchant has several brands, each brand would be a subscription provider. Merchant can create new Subscriptions Provider on https://admin.mobilepay.dk/  | 
| VAT-number   | In Denmark, this is the CVR-number. In Finland, this is the Y-tunnus. Both refer to the official business ID.| 



