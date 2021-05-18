# Coming soon

## Payment invoice attachments

We will be refactoring how invoice attachments are created. This will add more flexibility for the merchant. The old way how we create PDF attachments will remain, but we will strongly recommend to use this new approach.


Invoice attachments on top of the payment will be created with separate `PUT /api/providers/{providerId}/paymentrequests/{paymentId}/invoice` request. 

The preliminary request:
```json
{
    "external_invoice_url" : "https://example.com/link/to/invoice/12345",
    "generate_pdf" : false,
    "invoice_details" : {
        ...
    }
}
```

You will be able to provide your own link to PDF by passing it as `external_invoice_url` value. If you want MobilePay to generate invoice for you, you simply set `generate_pdf` as __true__ in the request and fill `invoice_datails` with values which will be used to generate the PDF file. 
`generate_pdf` cannot be set to __true__ when `external_invoice_url` is provided. Every subsequent request will overwrite the previous one.


`GET /api/providers/{providerId}/paymentrequests/{paymentId}/invoice` to get the details of the invoice attachment.


`GET /api/providers/{providerId}/paymentrequests/{paymentId}/invoice/pdf` to download PDF attachment.


`DELETE /api/providers/{providerId}/paymentrequests/{paymentId}/invoice` to delete the invoice attachment.

<div class="note">
    <strong>Note:</strong>
    <p>
        There might be some adjustmets to the documentation as we go live with this new functionality.
    </p>
</div>
