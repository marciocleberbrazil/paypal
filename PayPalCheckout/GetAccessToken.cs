using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPalCheckout
{
    public class GetAccessToken
    {
        public string AccessToken { get; set; }

        public GetAccessToken()
        {
            var config = (PayPalCheckoutSection)ConfigurationManager.GetSection("payPalCheckout");

            AccessToken = config.ClientId.Value;
        }
    }
}
