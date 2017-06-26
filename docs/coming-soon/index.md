### Refunds

As of 1.2 version, you are able to initiate:

**Full refund** - 100% of the amount paid is returned to the payer.<br />
**Partial refund** - An amount up to the net (the amount the merchant received) will be returned to the payer. Multiple partial refunds can be made.

#### Request a Refund
Use the `POST /api/merchants/me/agreements/{agreementId}/payments/{paymentId}/refunds` endpoint to request a **Refund**.

```json
{
    "amount": 10.99,
    "status_callback_url" : "https://example.com"
}
```


#### Request parameters

|Parameter             |Type        |Required  |Description                                                      |Valid values|
|----------------------|------------|----------|-----------------------------------------------------------------|------------|
|**amount**            |number(0.01)| required |*The requested amount to be returned.*|>= 0.01, decimals separated with a dot.|
|**status_callback_url**  |string| required |*Link relation hyperlink reference.*|https://&lt;merchant's url&gt;|


The `POST /api/merchants/me/agreements/{agreementId}/payments/{paymentId}/refunds` service returns HTTP 202 and the response contains single value: a unique *id* of the newly created **Refund**.

##### HTTP 202 Response body example
```json
{
    "id": "263cfe92-9f8e-4829-8b96-14a5e53c9041"
}
```

#### Callbacks

When the **Refund's** status changes from *Requested* we will do a callback to the callback address provided in request parameter `status_callback_url`.

##### Refund callback body example
```json
[
    {
        "refund_id" : "4bb9b33a-f34a-42e7-9143-d6eabd9aae1d",
        "agreement_id" : "1b08e244-4aea-4988-99d6-1bd22c6a5b2c",
        "payment_id" : "c710b883-6ed6-4506-9599-490ead89525a",
        "amount" : "10.99",
        "currency" : "DKK",
        "status" : "Refunded",
        "status_text" : null,
        "status_code" : 0
    }
]
```
##### Refund callback response example
```json
[
    {
        "refund_id" : "4bb9b33a-f34a-42e7-9143-d6eabd9aae1d",
        "agreement_id" : "1b08e244-4aea-4988-99d6-1bd22c6a5b2c",
        "payment_id" : "c710b883-6ed6-4506-9599-490ead89525a",
        "status_code" : "3000",
        "status_text" : "Server is down.",
        "transaction_id" : "63679ab7-cc49-4f75-80a7-86217fc105ea"
    }
]
```

Refund screens within mobile application:

![](../assets/images/Refund_0162.PNG)
![](../assets/images/Refund_0163.PNG)

> Refunds in Sandbox environment will work for payments from 2017-06-26
