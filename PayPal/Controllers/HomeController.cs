using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PayPalCheckout;

namespace PayPal.Controllers
{
    public class HomeController : Controller
    {
        private List<PayPalItem> products;
        private PayPalCheckout.PayPalCheckout paypalCheckout;

        public HomeController()
        {
            products = new List<PayPalItem>
            {
                new PayPalItem()
                {
                    Name = "Product number 01",
                    Description = "That's my description of my product",
                    Price = 50,
                    Sku = "1001",
                    Currency = PayPalCurrency.AUD,
                    Tax = 3.44
                },
                new PayPalItem()
                {
                    Name = "Product number 02",
                    Description = "That's my description of my product",
                    Price = 40,
                    Sku = "1002",
                    Currency = PayPalCurrency.AUD
                },
                new PayPalItem()
                {
                    Name = "Product number 03",
                    Description = "That's my description of my product",
                    Price = 45,
                    Sku = "1003",
                    Currency = PayPalCurrency.AUD
                },
                new PayPalItem()
                {
                    Name = "Product number 04",
                    Description = "That's my description of my product",
                    Price = 30,
                    Sku = "1004",
                    Currency = PayPalCurrency.AUD
                },
                new PayPalItem()
                {
                    Name = "Product number 05",
                    Description = "That's my description of my product",
                    Price = 55,
                    Sku = "1005",
                    Currency = PayPalCurrency.AUD
                }
            };

            paypalCheckout = new PayPalCheckout.PayPalCheckout();
        }

        public async Task<ActionResult> FinishCheckout(string paymentId, string PayerID)
        {
            var executeApproved = await paypalCheckout.ExecuteApproved(paymentId, PayerID);

            if (executeApproved.Error == null && executeApproved.State == PayPalState.APPROVED)
            {
                ViewBag.Result = "Payment approved";
            }
            else
            {
                ViewBag.Result = $"Error while process your payment: {executeApproved.Error.Message}";
            }

            return View();
        }

        public ActionResult Index()
        {
            return View(products);
        }

        [HttpPost]
        public async Task<ActionResult> Index(FormCollection form)
        {
            if (form["selectedProducts"] == null) return View(products);
            var skuArray = form["selectedProducts"].Length > 0 ? form["selectedProducts"].Split(',') : new string[] { };
            var selectedProducts = skuArray.Select(item => products.FirstOrDefault(x => x.Sku == item)).Where(product => product != null).ToList();

            double shippingPrice = 10;
            double shippingDiscount = 10;

            //taking the quantities
            foreach (var item in selectedProducts)
            {
                var quantity = form[$"quantity_{item.Sku}"];
                item.Quantity = Convert.ToInt32(quantity);
            }

            var shippingAddress = new PayPalShippingAddress()
            {
                RecipientName = form["RecipientName"],
                Line1 = form["Line1"],
                Line2 = form["Line2"],
                City = form["City"],
                CountryCode = form["CountryCode"],
                PostalCode = form["PostalCode"],
                Phone = form["Phone"],
                State = form["State"]
            };

            var transaction = new PayPalTransaction(
                selectedProducts,
                shippingAddress,
                form["invoiceNumber"],
                "The payment transaction description.",
                AllowedPaymentMethod.INSTANT_FUNDING_SOURCE,
                PayPalCurrency.AUD,
                shippingPrice,
                shippingDiscount);


            var payment = new PaypalPayment(
                Intent.SALE,
                PaymentMethod.PAYPAL,
                "Contact us for any questions on your order.", 
                transaction);

            var createPayment = await paypalCheckout.CreatePayment(payment);

            if (createPayment.Error == null)
            {
                var redirectUrl = createPayment.Links.FirstOrDefault(x => x.Method == PayPalLinkMethod.REDIRECT)?.Href;
                Response.Redirect(redirectUrl, true);
            }
            else
            {
                ViewBag.Error = createPayment.Error.Message;
                ViewBag.ErrorDetails = createPayment.Error.Details;

                ViewBag.Output = JsonConvert.SerializeObject(payment);
            }

            return View(products);
        }
    }
}