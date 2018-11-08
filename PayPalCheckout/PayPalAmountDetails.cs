using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalAmountDetails
    {
        [JsonProperty("subtotal")]
        public double Subtotal { get; set; }

        [JsonProperty("tax")]
        public double Tax { get; set; }

        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        [JsonProperty("handling_fee")]
        public double HandlingFee { get; set; }

        [JsonProperty("shipping_discount")]
        public double ShippingDiscount { get; set; }

        [JsonProperty("insurance")]
        public double Insurance { get; set; }
    }
}
