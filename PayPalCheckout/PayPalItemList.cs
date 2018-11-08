using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalItemList
    {
        [JsonProperty(PropertyName = "items")]
        public List<PayPalItem> Items { get; set; }

        [JsonProperty(PropertyName = "shipping_address")]
        public PayPalShippingAddress ShippingAddress { get; set; }
    }
}
