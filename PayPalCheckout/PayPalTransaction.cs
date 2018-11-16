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

        [JsonProperty(PropertyName = "amount")]
        public PayPalAmount Amount { get; set; }

        [JsonProperty(PropertyName = "payee")]
        public PayPalPayee Payee { get; set; }


        public PayPalAmount CalcAmount(PayPalCurrency currency, List<PayPalItem> items, double shippingPrice)
        {
            try
            {
                double subTotal = 0;
                double taxes = 0;
                foreach (var item in items)
                {
                    //calc subtotal
                    subTotal += item.Price * item.Quantity;

                    //calc taxes
                    taxes += item.Tax * item.Quantity;
                }

                return new PayPalAmount
                {
                    Total = shippingPrice + subTotal + taxes,
                    Currency = currency,
                    Details = new PayPalAmountDetails()
                    {
                        Subtotal = subTotal,
                        Tax = taxes,
                        Shipping = shippingPrice
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PayPalTransaction(List<PayPalItem> items, PayPalShippingAddress shippingAddress, string invoiceNumber, string transactionDescription, AllowedPaymentMethod allowedPaymentMethod, PayPalCurrency currency, double shippingPrice)
        {
            ItemList = new PayPalItemList {Items = items, ShippingAddress = shippingAddress};
            InvoiceNumber = invoiceNumber;
            Description = transactionDescription;
            PaymentOptions = new PayPalPaymentOption {AllowedPaymentMethod = allowedPaymentMethod};
            Amount = CalcAmount(currency, items, shippingPrice);
        }

        public PayPalTransaction()
        {
            
        }
    }
}
