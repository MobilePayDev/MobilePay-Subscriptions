
## <a name="error_handling"></a> Error Handling


Your MobilePay Subscriptions integration might have to deal with errors at some point when making API requests to MobilePay. MobilePay uses  [HTTP response status codes](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes) to indicate the success or failure of your API requests. These errors fall into a few major categories:

-   **Content errors occur**  because the content in the API request was invalid in some way. They return an HTTP response with a 4xx error code. For example, the API servers might return a  `401`  if an invalid API key was provided, or if access token is expired, or a  `400`  if a required parameter was missing. Integrations should correct the original request, and try again. Depending on the type of user error, it may be possible to handle the problem programmatically.
-   **Network errors**  errors occur because of intermittent communication problems between client and server. When intermittent problems occur, clients and MobilePay Merchants can be left in a state where they do not know whether the server received the request. For MobilePay Subscriptions, we do not track each request, but we track the state of a payment or agreement. For example: if a OneOff is captured, then the client will receive a callback and a 4xx response with error body.
-   **Server errors**  occur because of a problem on MobilePay’s servers. Server errors return an HTTP response with a  `5xx`  error code. MobilePay works to make these errors as rare as possible, but integrations should be able to handle them when they do arise. The result of a  `500`  request should be treated as indeterminate. The most likely time to observe one is during a production incident, and generally during such an incident’s remediation. When a production incident happens, you will receive an e-mail from MobilePay Operations team, assuming you have subscribed to the operational maillist. When this happens, MobilePay engineers will examine failed requests and try to appropriately reconcile the results of any mutations that resulted in  `500`

Your API integration should always check the HTTP response code to ensure correct handling of success and error conditions. ONLY an HTTP status of 200 means the request was successful. For non 200 responses, the predictable response body will give you details on why the request failed. 

We suggest logging any failure response body as best practice; the MobilePay Developer support team will need the full response body to assist with troubleshooting.
We recommend writing code that gracefully handles all possible API exceptions.

 
