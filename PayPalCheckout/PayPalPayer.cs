using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalPayer
    {
        [JsonProperty("payment_method")]
        [JsonConverter(typeof(PaymentMethodConverter))]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(PayPalStatusConverter))]
        public PayPalStatus Status { get; set; }

        [JsonProperty("payer_info")]
        public PayPalPayerInfo PayerInfo { get; set; }
    }
}
