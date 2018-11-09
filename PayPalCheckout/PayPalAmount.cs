using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalAmount
    {
        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("currency")]
        [JsonConverter(typeof(PayPalCurrencyConverter))]
        public PayPalCurrency Currency { get; set; }

        [JsonProperty("details")]
        public PayPalAmountDetails Details { get; set; }
    }
}
