
## <a name="general-notes_provider-list"></a>Getting a list of subscription providers

After getting an access token, you will be able to list subscription providers associated with that merchant by calling `GET /api/merchants/me`, which will return a list of all subscription providers, associated with that merchant. Before using MobilePay Subscriptions, the merchant must have at least one Subscriptions provider which can be created via MobilePay Portal Denmark or Finland. Each subscriptions provider contains its own address information, homepage url and etc. The merchant is the customer company and the Invoice Issuer is the actual service provider name under which they send subscriptions payments invoices

Providers represents your customer (which is a MobilePay Merchant). `providerId` represents a particular subscription provider. 

For example, if a single merchant has several brands, then each brand would be a subscription provider. Currently, a merchant grants you permission to all their subscription providers. 

##### <a name="subscription-payments_response-example"></a>HTTP 200 Response body example
```json
[
  {
    "Id": "a863d62e-d53b-4651-9b7b-c80792ee1343",
    "SubscriptionProviders": [
      {
        "SubscriptionProviderId": "b45afee5-703c-4136-8f60-162fc01709df",
        "Name": "Name of your subscription product",
        "HomepageUrl": "https://merchant.dk",
        "CustomerServiceEmail": "customerservice@merchant.dk",
        "SelfServicePortalUrl": "https://merchant.dk/self-service",
        "FaqUrl": "https://merchant.dk/faq",
        "Status": "Enabled" || "Pending",
        "Address": "Your address line",
        "ZipCode": "1234",
        "City": "City"
      }
    ]
  }
]
```

## <a name="general-notes_provider-update"></a>Updating subscription provider

Before requesting payments a status callback URL must be set by calling `PATCH /api/providers/{providerId}`:

#### Payment status callback URL
```json
[
    {
        "value": "https://merchant.dk/notifications_from_mobilepay/payments",
        "path": "/payment_status_callback_url",
        "op": "replace"
    }
]
```
