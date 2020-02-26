
# <a name="api_principles"></a> Api principles

This is a preliminary list of architectural principles. The API documentation provides insight into the structure of the API and will help you determine the best approach for integration as well as provide details on typical use cases. Read through the reference to find information and examples for the calls  

## <a name="general-notes"></a> General notes 

MobilePay Subscriptions is a full-fledged HTTPS REST api using JSON as request/response communication media.

All dates and time-stamps use the ISO 8601 format: date format - `YYYY-MM-DD`, date-time format - `YYYY-MM-DDTHH:mm:ssZ`.

Amounts are enquoted with double quotation marks using `0.00` format, decimals separated with a dot.

When doing `POST`, `PATCH` or `PUT` requests, `Content-Type: application/json` HTTP header must be provided.

```console 
$ curl --request POST --header 'Content-Type: application/json' --url https://<mobile-pay-root>/resource --data '{}'
```

## <a name="error_handling"></a> Error handling

Your MobilePay Subscriptions integration might have to deal with errors at some point when making API requests to MobilePay. MobilePay uses  [HTTP response status codes](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes) to indicate the success or failure of your API requests. These errors fall into a few major categories:

-   **Content errors occur**  because the content in the API request was invalid in some way. They return an HTTP response with a 4xx error code. For example, the API servers might return a  `401`  if an invalid API key was provided, or if access token is expired, or a  `400`  if a required parameter was missing. Integrations should correct the original request, and try again. Depending on the type of user error, it may be possible to handle the problem programmatically.
-   **Network errors**  errors occur because of intermittent communication problems between client and server. When intermittent problems occur, clients and MobilePay Merchants can be left in a state where they do not know whether the server received the request. For MobilePay Subscriptions, we do not track each request, but we track the state of a payment or agreement. For example: if a OneOff is captured, then the client will receive a callback and a 4xx response with error body.
-   **Server errors**  occur because of a problem on MobilePay’s servers. Server errors return an HTTP response with a  `5xx`  error code. MobilePay works to make these errors as rare as possible, but integrations should be able to handle them when they do arise. The result of a  `500`  request should be treated as indeterminate. The most likely time to observe one is during a production incident, and generally during such an incident’s remediation. When a production incident happens, you will receive an e-mail from MobilePay Operations team, assuming you have subscribed to the operational maillist. When this happens, MobilePay engineers will examine failed requests and try to appropriately reconcile the results of any mutations that resulted in  `500`

Your API integration should always check the HTTP response code to ensure correct handling of success and error conditions. ONLY an HTTP status of 200 means the request was successful. For non 200 responses, the predictable response body will give you details on why the request failed. 

We suggest logging any failure response body as best practice; the MobilePay Developer support team will need the full response body to assist with troubleshooting.
We recommend writing code that gracefully handles all possible API exceptions.


#### <a name="general-notes_errors"></a>Errors

You might encounter the following HTTP errors:

1. `400 - Bad Request` , if request data is invalid.
>    
    ```json
    {
        "error": "BadRequest",
        "error_description": {
            "message": "request.Name is required",
            "error_type": "InputError",
            "correlation_id": "f4b02597-32cc-420f-a468-942307e89a97"
        }
    }
    ```
2. `404 - Not Found` with no response body, if the resource (agreement or payment) is not found.

3. `412 - Precondition Failed` , if business validation rule was violated.
>    
    ```json
    {
        "error": "PreconditionFailed",
        "error_description": {
            "message": "Duplicate payment.",
            "error_type": "PreconditionError",
            "correlation_id": "f4b02597-32cc-420f-a468-942307e89a97"
        }
    }
    ```
4. `500 - Internal Server Error` , if something really bad has happened.
>    
    ```json
    {
        "error": "InternalServerError",
        "error_description": {
            "message": "An error occurred, please try again or contact the administrator.",
            "error_type": "ServerError",
            "correlation_id": "f4b02597-32cc-420f-a468-942307e89a97"
        }
    }
    ```

#### <a name="general-notes_correlation"></a>REST request correlation

_CorrelationId_ is an optional _[Guid](https://en.wikipedia.org/wiki/Globally_unique_identifier)_ header value which can be used to link requests on your back-end system to MobilePay Subscriptions business transaction for a more convenient debugging.

```console
$ curl --header 'CorrelationId: 37b8450b-579b-489d-8698-c7800c65934c' --url https://<mobile-pay-root>/api/merchants/me/agreements
```

#### <a name="general-notes_callback-authentication"></a>REST callback authentication

Use one of these endpoints to set REST callback authentication scheme and credentials:
* `PUT /api/providers/{providerId}/auth/oauth2` - set OAuth2 scheme which conforms to RFC 6749 [section 4.4.](https://tools.ietf.org/html/rfc6749#section-4.4).
* `PUT /api/providers/{providerId}/auth/basic` - set Basic auth scheme using username and password.
* `PUT /api/providers/{providerId}/auth/apikey` - set a value which will be set to the _Authorization_ header. API key must conform to the token68 specification as defined in RFC 7235 [section2.1.](https://tools.ietf.org/html/rfc7235#section-2.1).

#### <a name="general-notes_callback-retries"></a>REST callback retries

Once the payment or agreement changes state, a callback will be done to the callback address, which is configurable via `PATCH /api/providers/{providerId}` with path value `/payment_status_callback_url`.

In case the REST callback failed, 8 retries will be made using the [exponential back-off algorithm](https://en.wikipedia.org/wiki/Exponential_backoff), where N - next retry time, c - retry attempt number, R - second retry time in seconds (1st retry is an exception and is done after 5 seconds):

![](assets/images/RecurringPayments_ExponentialBackoff.gif)

* 1st retry – 5 seconds
* 2nd retry – 10 minutes after 1st retry
* 3rd retry – 30 minutes after 2nd retry
* 4th retry – 1h 10 minutes after 3rd retry
* 5th retry – 2h 30 minutes after 4th retry
* 6th retry – 5h 10 minutes after 5th retry
* 7th retry – 10h 30 minutes after 6th retry
* 8th retry – 21h 10 minutes after 7th retry

* * *


##  Handling payments that require additonal action

Sometimes, when a customer’s subscription comes due, the payment fails. The customer might have canceled their card, the card might have expired, or the payment might be declined by the card issuer for some other reason. Suddenly, life is less good.

Fortunately, MobilePay Subscriptions helps the merchant in this situation. We send push notifications to customers smartphone. When a payment requires additional steps, such as customer authentication or exchange of card, the customer will be notified via push notifications. Upon receiving the push notification, the customer is pushed to complete the required action. For details on which push notifications, the customer might receive, read more here.

However, if you have specific design requirements for customizing emails’ trigger conditions, content, or other details, you are more than welcome to do that on your side. It could be beneficial to make customized system that automatically notifies your customers when a subscription payment fails. You know your customer, and you can further target the message.

## 2. grace_period_days

When a payment failed, we will automatically retry, if you have configured `grace_period_days` in the payment request. `grace_period_days` lets merchants to configure how many days MobilePay will try to complete unsuccessful payment. It is optional to use `grace_period_days`. We can try for maximum 3 days. On due date we process the payments starting from 02:00. If some payments weren't successfully completed, we will then try again approx. every 2 hours. When `grace_period_days` field is not set or is set to 1, we will keep retrying to complete the payment up until 23:59 of the same day. When `grace_period_days` is set to more than 1, we will be trying to complete the payment for specified number of days. 

## <a name="external_id"></a> External_id
When utilizing callbacks, it is important that you evaluate your usage of ``external_id``, as it will be included in the request body of the refund callback, as well in the reference number and bank statement. External_id's are not required to be unique however this is highly recommended. However, if the ``external_id`` in not unique the mapping could be more cluttered on merchant side. 
We recommend that the ``external_id`` for a payment should be associated with the specified ``orderId`` on merchant side. 
We recommend that the ``external_id`` for an Agreement should be associated with the specified customer number on merchant side. 

## <a name="capture_reservations"></a> Capture or cancellation of old reservations

All reservations should be captured or cancelled as soon as possible practically. If an error occurs that result in either cancellation or capture being impossible the client is responsible for persisting which payments should be captured at a later stage. We encourage you to capture as soon as a service is rendered or order shipped. It results in bad end-user experience, if the amount is reserved on the customer’s account for too long, as the customer can see the amount on their bank statement.


## <a name="apichange"></a> Subscriptions API Change Info

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
