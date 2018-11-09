using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PaypalPayment
    {
        [JsonProperty("intent")]
        [JsonConverter(typeof(IntentConverter))]
        public Intent Intent { get; set; }

        [JsonProperty("payer")]
        public PayPalPaymentMethod Payer { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public List<PayPalTransaction> Transactions { get; set; }

        [JsonProperty(PropertyName = "note_to_payer")]
        public string NoteToPayer { get; set; }

        [JsonProperty(PropertyName = "redirect_urls")]
        public PayPalRedirects RedirectUrls { get; set; }

        public PaypalPayment(Intent intent, PaymentMethod paymentMethod, string noteToPayer, PayPalTransaction transaction)
        {
            Intent = intent;
            Payer = new PayPalPaymentMethod(){ PaymentMethod = paymentMethod };
            NoteToPayer = noteToPayer;
            Transactions = new List<PayPalTransaction> {transaction};


            var config = (PayPalCheckoutSection)ConfigurationManager.GetSection("payPalCheckout");

            RedirectUrls = new PayPalRedirects()
            {
                ReturnUrl = config.ReturnUrl.Value,
                CancelUrl = config.CancelUrl.Value
            };
        }

        public PaypalPayment()
        {
            
        }
    }
}
