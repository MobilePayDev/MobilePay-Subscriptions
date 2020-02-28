
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

# <a name="general-notes_errors"></a>Errors

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


## <a name="apichange"></a>  API Change 

When we make backwards-incompatible changes to the API, we release new, dated versions.  If you’re running an older version of the API, upgrade to the latest version to take advantage of new functionality or to streamline responses so the API is faster for you. 

 - We will notify Merchants of breaking API changes. You can sign up to receive emails of API changes, as well as other MobilePay Subscriptions news on our Developer Portal [here](https://developer.mobilepay.dk/news/all) 
 - Release Notes are publicly available  [here](https://mobilepaydev.github.io/MobilePay-Subscriptions/release_notes) and sorted by date, so you can easily see the newest updates. 
 
**Breaking changes**

Our services change continually as we add new features, but we do our best to create stability so that the applications our clients build on top of our API can adapt gracefully as well. MobilePay will establish an appropriate timeline and regular communication with the API consumers to ensure that merchants and integrators migrate to the new version.

The following types of changes qualify as breaking changes:

 - Removal of a field
 - Change of a field from non-mandatory to mandatory
 - Addition of new validation rules
 - Modification of the data type of a field (for example, array of IDs converted to array of objects)
 - Modification of throttling of requests
 - Reduction in the number of objects returned by responses
 - Changing a response code
 - Changing error types
 
**Examples of non-breaking changes**

The following types of changes do not qualify as breaking changes. Please note that this list is not exhaustive; these are just some examples of non-breaking changes.

 - Addition of a new non-mandatory field
 - Addition of a new service 
 - Deprecation of a field without removing it 
 - Change in order of fields in an object, objects in an array, and so on
 
 
## API Version Status

 -  **Active:** An active API version is the most current and fully supported API. It is the recommended version to use by everyone. 
 -  **Deprecated:** A deprecated API version has been superseded by a newer API version. It is supported (bug fixes) for six months from the deprecation date. New apps will be denied access to deprecated APIs. 
 -  **Retired:** A retired API version is no longer supported. It includes any API deprecated for more than six months. Any application using a retired API must migrate to an active API. 


## <a name="external_id"></a> External_id
When utilizing callbacks, it is important that you evaluate your usage of ``external_id``, as it will be included in the request body of the refund callback, as well in the reference number and bank statement. External_id's are not required to be unique however this is highly recommended. However, if the ``external_id`` in not unique the mapping could be more cluttered on merchant side. 
We recommend that the ``external_id`` for a payment should be associated with the specified ``orderId`` on merchant side. 
We recommend that the ``external_id`` for an Agreement should be associated with the specified customer number on merchant side. 

## <a name="capture_reservations"></a> Capture or cancellation of old reservations

All reservations should be captured or cancelled as soon as possible practically. If an error occurs that result in either cancellation or capture being impossible the client is responsible for persisting which payments should be captured at a later stage. We encourage you to capture as soon as a service is rendered or order shipped. It results in bad end-user experience, if the amount is reserved on the customer’s account for too long, as the customer can see the amount on their bank statement.

