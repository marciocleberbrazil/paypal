using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalPaymentOption
    {
        [JsonProperty(PropertyName = "allowed_payment_method")]
        [JsonConverter(typeof(AllowedPaymentMethodConverter))]
        public AllowedPaymentMethod AllowedPaymentMethod { get; set; }
    }
}
