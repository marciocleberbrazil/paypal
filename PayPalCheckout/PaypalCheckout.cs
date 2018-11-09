using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPalCheckout
{
    public class PayPalCheckout
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        private string PayPalURL { get; set; }

        /*public PayPalAccessTokenResponse GetAccessToken()
        {
            const string ENDPOINT = "/oauth2/token";

            
        }*/

        public PayPalCheckout()
        {
            var config = (PayPalCheckoutSection)ConfigurationManager.GetSection("payPalCheckout");
            ClientId = config.ClientId.Value;
            ClientSecret = config.ClientSecret.Value;
            PayPalURL = config.Live.Value ? "https://api.paypal.com/v1" : "https://api.sandbox.paypal.com/v1";
        }
    }
}
