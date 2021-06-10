# Coming soon

## Payment attachments

The purpose of payment attachments is to replace existing invoice PDF functionality and to offer more flexibility for the merchant. With this new functionality you will be able to choose how attachment will be presented to the user:
- Your own link to the payment document
- Attachment details which will be visible in MobilePay payment receipt and payment confirmation screens
- PDF document generated from the attachment details

The old way how we create invoice PDF attachments will remain, but we will strongly recommend to use this new approach.


Payment attachments on top of the payment will be created with separate `PUT /api/providers/{providerId}/payments/{paymentId}/attachment` request. 

The preliminary request:
```json
{
    "external_attachment_url" : "https://example.com/link/to/e_g_invoice/12345/pdf",
    "attachment_details" : {
        ...
    },
    "generate_pdf" : false
}
```

You will be able to provide your own URL link to payment document by passing it as `external_attachment_url` value. If you want MobilePay to generate PDF for you, you simply set `generate_pdf` to __true__ in the request and fill `attachment_datails` with values which will be used to generate the PDF file. 
You can also provide `attachment_details` without generating PDF file, details will be visible in MobilePay payment receipt and confirmation screens.

`generate_pdf` cannot be set to __true__ when `external_attachment_url` is provided. 

Every subsequent request will overwrite the previous one.


We are also reducing the amount of mandatory fields in `attachment_datails`:

|Parameter                   |Sub Parameter            |Type        |Description                                                                  |Requirement      |
|----------------------------|-------------------------|------------|-----------------------------------------------------------------------------|-----------------|
| document_title             |                         | string     | Used as document title in PDF document. Up to 60 characters.                | Required        |
| hide_payment_point_address |                         | boolean    | Hides payment point address. Default is __false__.                          | Optional        |
| consumer_name              |                         | string     | Full name of the user.                                                      | Optional        |
| consumer_phone_number      |                         | string     | Mobile phone number of MobilePay user.                                      | Optional        |
| total_amount               |                         | decimal    | The requested amount to be paid.                                            | Required        |
| total_vat_amount           |                         | decimal    | ~~Required~~. Total VAT amount.                                             | Optional        |
| total_amount_ex_vat        |                         | decimal    | Total amount excluding VAT.                                                 | Optional        |
| issue_date                 |                         | date       | ~~Required~~. Issue date of the document.                                   | Optional        |
| invoice_number             |                         | string     | ~~Required~~. Invoice number for invoice documents.                         | Optional        |
| order_date                 |                         | date       | ~~Required~~. Order date.                                                   | Optional        |
| due_date                   |                         | date       | ~~Required~~. Payment due date.                                             | Optional        |
| consumer_address_lines     |                         | string[]   | Address of consumer receiving the document.                                 | Optional        |
| articles                   |                         | array      | __At least one array element is required.__                                 | Required        |
|                            | article_number          | string     | ~~Required~~. Article number, e.g.: 123456ABC.                              | Optional        |
|                            | article_description     | string     | Article description.                                                        | Required        |
|                            | vat_rate                | decimal    | ~~Required~~. VAT rate of an article.                                       | Optional        |
|                            | total_vat_amount        | decimal    | ~~Required~~. Total VAT amount of an article.                               | Optional        |
|                            | total_price_inc_vat     | decimal    | Total price of an article including VAT. Can be negative.                   | Required        |
|                            | unit                    | string     | ~~Required~~. Unit, e.g.: pcs, coli, kg, m.                                 | Optional        |
|                            | quantity                | decimal    | ~~Required~~. Quantity of an article.                                       | Optional        |
|                            | price_per_unit          | decimal    | ~~Required~~. Price per unit.                                               | Optional        |
| price_reduction            |                         | decimal    | Price reduction.                                                            | Optional        |
| price_discount             |                         | decimal    | Price discount.                                                             | Optional        |
| bonus                      |                         | decimal    | Bonus of an article.                                                        | Optional        |
| merchant_contact_name      |                         | string     | Contact name of the individual who issued the document.                     | Optional        |
| delivery_address_lines     |                         | string[]   | Delivery address.                                                           | Optional        |
| payment_reference          |                         | string(60) | Any extra reference to be presented in the generated PDF file.              | Optional        |
| delivery_date              |                         | date       | Delivery date of the document.                                              | Optional        |
| merchant_order_number      |                         | string     | The merchant order number for the document used internally by the merchant. | Optional        |
| buyer_order_number         |                         | string     | The buyer order number for the document used internally by the merchant.    | Optional        |
| comment                    |                         | string     | Additonal information for the consumer.                                     | Optional        |

`GET /api/providers/{providerId}/payments/{paymentId}/attachment` to get the details of the payment attachment.


`GET /api/providers/{providerId}/payments/{paymentId}/attachment/pdf` to download PDF attachment(if it was created).


`DELETE /api/providers/{providerId}/payments/{paymentId}/attachment` to delete payment attachment.

<div class="note">
    <strong>Note:</strong>
    <p>
        There might be some adjustmets to the documentation as we go live with this new functionality.
    </p>
</div>
