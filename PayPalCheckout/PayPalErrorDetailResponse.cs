using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class PayPalErrorDetailResponse
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }
    }
}
