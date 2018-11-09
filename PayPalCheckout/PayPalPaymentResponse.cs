using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalPaymentResponse : PaypalPayment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(PayPalStateConverter))]
        public PayPalState State { get; set; }

        [JsonProperty("failure_reason")]
        [JsonConverter(typeof(PayPalFailureReasonConverter))]
        public PayPalFailureReason FailureReason { get; set; }

        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        [JsonProperty(PropertyName = "links")]
        public List<PayPalLinkDescription> Links { get; set; }

        public PayPalPaymentResponse()
        {
            Links = new List<PayPalLinkDescription>();
        }
    }
}
