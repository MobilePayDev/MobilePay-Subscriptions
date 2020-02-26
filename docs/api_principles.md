
# <a name="api_principles"></a> Api principles

This is a preliminary list of architectural principles. The API documentation provides insight into the structure of the API and will help you determine the best approach for integration as well as provide details on typical use cases. Read through the reference to find information and examples for the calls  
 

## <a name="error_handling"></a> Error handling

Your MobilePay Subscriptions integration might have to deal with errors at some point when making API requests to MobilePay. MobilePay uses  [HTTP response status codes](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes) to indicate the success or failure of your API requests. These errors fall into a few major categories:

-   **Content errors occur**  because the content in the API request was invalid in some way. They return an HTTP response with a 4xx error code. For example, the API servers might return a  `401`  if an invalid API key was provided, or if access token is expired, or a  `400`  if a required parameter was missing. Integrations should correct the original request, and try again. Depending on the type of user error, it may be possible to handle the problem programmatically.
-   **Network errors**  errors occur because of intermittent communication problems between client and server. When intermittent problems occur, clients and MobilePay Merchants can be left in a state where they do not know whether the server received the request. For MobilePay Subscriptions, we do not track each request, but we track the state of a payment or agreement. For example: if a OneOff is captured, then the client will receive a callback and a 4xx response with error body.
-   **Server errors**  occur because of a problem on MobilePay’s servers. Server errors return an HTTP response with a  `5xx`  error code. MobilePay works to make these errors as rare as possible, but integrations should be able to handle them when they do arise. The result of a  `500`  request should be treated as indeterminate. The most likely time to observe one is during a production incident, and generally during such an incident’s remediation. When a production incident happens, you will receive an e-mail from MobilePay Operations team, assuming you have subscribed to the operational maillist. When this happens, MobilePay engineers will examine failed requests and try to appropriately reconcile the results of any mutations that resulted in  `500`

Your API integration should always check the HTTP response code to ensure correct handling of success and error conditions. ONLY an HTTP status of 200 means the request was successful. For non 200 responses, the predictable response body will give you details on why the request failed. 

We suggest logging any failure response body as best practice; the MobilePay Developer support team will need the full response body to assist with troubleshooting.
We recommend writing code that gracefully handles all possible API exceptions.



## <a name="apichange"></a>  API Change 

When we make backwards-incompatible changes to the API, we release new, dated versions.  If you’re running an older version of the API, upgrade to the latest version to take advantage of new functionality or to streamline responses so the API is faster for you. 

 - We will notify customers of API changes. You can sign up to receive emails of API changes, as well as other MobilePay Subscriptions news on our Developer Portal [here](https://developer.mobilepay.dk/news/all) 
 - Release Notes are publicly available  [here](https://mobilepaydev.github.io/MobilePay-Subscriptions/release_notes)
 
**Breaking changes**

The following types of changes qualify as breaking changes:

 - Removal of a field
 - Change of a field from non-mandatory to mandatory
 - Addition of new validation rules
 - Modification of the data type of a field (for example, array of IDs converted to array of objects)
 - Modification of throttling of requests
 - Reduction in the number of objects returned by responses
 
 ##  Handling payments that require additonal action

However, if you have specific design requirements for customizing emails’ trigger conditions, content, or other details, you are more than welcome to do that on your side. It could be beneficial to make customized system that automatically notifies your customers when a subscription payment fails. You know your customer, and you can further target the message.

## 2. grace_period_days

When a payment failed, we will automatically retry, if you have configured `grace_period_days` in the payment request. `grace_period_days` lets merchants to configure how many days MobilePay will try to complete unsuccessful payment. It is optional to use `grace_period_days`. We can try for maximum 3 days. On due date we process the payments starting from 02:00. If some payments weren't successfully completed, we will then try again approx. every 2 hours. When `grace_period_days` field is not set or is set to 1, we will keep retrying to complete the payment up until 23:59 of the same day. When `grace_period_days` is set to more than 1, we will be trying to complete the payment for specified number of days. 

## <a name="external_id"></a> External_id
When utilizing callbacks, it is important that you evaluate your usage of ``external_id``, as it will be included in the request body of the refund callback, as well in the reference number and bank statement. External_id's are not required to be unique however this is highly recommended. However, if the ``external_id`` in not unique the mapping could be more cluttered on merchant side. 
We recommend that the ``external_id`` for a payment should be associated with the specified ``orderId`` on merchant side. 
We recommend that the ``external_id`` for an Agreement should be associated with the specified customer number on merchant side. 

## <a name="capture_reservations"></a> Capture or cancellation of old reservations

All reservations should be captured or cancelled as soon as possible practically. If an error occurs that result in either cancellation or capture being impossible the client is responsible for persisting which payments should be captured at a later stage. We encourage you to capture as soon as a service is rendered or order shipped. It results in bad end-user experience, if the amount is reserved on the customer’s account for too long, as the customer can see the amount on their bank statement.

