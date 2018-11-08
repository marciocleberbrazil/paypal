using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalTransaction
    {
        [JsonProperty(PropertyName = "item_list")]
        public PayPalItemList ItemList { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "invoice_number")]
        public string InvoiceNumber { get; set; }

        [JsonProperty(PropertyName = "payment_options")]
        public PayPalPaymentOption PaymentOptions { get; set; }

        public PayPalAmount Amount { get; set; }
        public PayPalTransaction(List<PayPalItem> items, PayPalShippingAddress shippingAddress, string invoiceNumber, string transactionDescription, AllowedPaymentMethod allowedPaymentMethod, PayPalCurrency currency, double shippingPrice)
        {
            ItemList = new PayPalItemList {Items = items, ShippingAddress = shippingAddress};
            InvoiceNumber = invoiceNumber;
            Description = transactionDescription;
            PaymentOptions = new PayPalPaymentOption {AllowedPaymentMethod = allowedPaymentMethod};

            double subTotal = 0;
            double taxes = 0;
            foreach (var item in items)
            {
                subTotal += item.Price * item.Quantity;
                taxes += item.Tax;
            }

            var total = subTotal + shippingPrice + taxes;

            var details = new PayPalAmountDetails
            {
                Subtotal = subTotal,
                Tax = taxes,
                Shipping = shippingPrice
            };

            Amount = new PayPalAmount
            {
                Total = total,
                Currency = currency,
                Details = details
            };
        }

        public PayPalTransaction()
        {
            
        }
    }
}
