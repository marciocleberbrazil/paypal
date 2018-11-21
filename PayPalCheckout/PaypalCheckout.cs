using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PayPalCheckout
{
    public class PayPalCheckout
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        private Uri BaseUrl { get; set; }

        public async Task<PayPalPaymentResponse> ExecuteApproved(string paymentId, string payerID)
        {
            try
            {
                var accessTokenResponse = await GetAccessToken();

                if (!string.IsNullOrEmpty(accessTokenResponse.Error))
                    throw new Exception("Error while request a PayPal token");

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessTokenResponse.AccessToken);
                    client.BaseAddress = BaseUrl;
                    var response = await client.PostAsJsonAsync($"payments/payment/{paymentId}/execute", new { payer_id = payerID });

                    if (response.StatusCode == HttpStatusCode.OK)
                        return await response.Content.ReadAsAsync<PayPalPaymentResponse>();

                    var error = await response.Content.ReadAsAsync<PayPalErrorResponse>();
                    return new PayPalPaymentResponse()
                    {
                        Error = error
                    };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PayPalPaymentResponse> CreatePayment(PaypalPayment paypalPayment)
        {
            try
            {
                var accessTokenResponse = await GetAccessToken();

                if(!string.IsNullOrEmpty(accessTokenResponse.Error))
                    throw new Exception(accessTokenResponse.Error);

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessTokenResponse.AccessToken);
                    client.BaseAddress = BaseUrl;
                    var response = await client.PostAsJsonAsync("payments/payment", paypalPayment);

                    if (response.StatusCode == HttpStatusCode.Created)
                        return await response.Content.ReadAsAsync<PayPalPaymentResponse>();
                    
                    var error = await response.Content.ReadAsAsync<PayPalErrorResponse>();
                    return new PayPalPaymentResponse()
                    {
                        Error = error
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PayPalAccessTokenResponse> GetAccessToken()
        {
            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (var client = new HttpClient())
                {
                    if(string.IsNullOrEmpty(ClientId)) return new PayPalAccessTokenResponse() { Error = "It is missing the the ClientId key" };

                    if (string.IsNullOrEmpty(ClientSecret)) return new PayPalAccessTokenResponse() { Error = "It is missing the the ClientSecret key" };

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));
                    var bytes = Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

                    var keyValues = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials")
                    };

                    client.BaseAddress = BaseUrl;

                    var responseMessage = await client.PostAsync("oauth2/token", new FormUrlEncodedContent(keyValues));
                    if(responseMessage.IsSuccessStatusCode)
                        return await responseMessage.Content.ReadAsAsync<PayPalAccessTokenResponse>();

                    return new PayPalAccessTokenResponse() { Error = "Error while getting the Access Token" }; ;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PayPalCheckout()
        {
            var config = (PayPalCheckoutSection)ConfigurationManager.GetSection("payPalCheckout");
            ClientId = config.ClientId.Value;
            ClientSecret = config.ClientSecret.Value;
            BaseUrl = new Uri(config.Live.Value ? "https://api.paypal.com/v1/" : "https://api.sandbox.paypal.com/v1/");
        }
    }
}
