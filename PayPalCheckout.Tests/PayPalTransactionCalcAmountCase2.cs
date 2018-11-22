using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayPalCheckout.Tests
{
    [TestClass]
    public class PayPalTransactionCalcAmountCase2
    {
        private List<PayPalItem> items;
        private double shippingPrice;
        private double shippingDiscount;
        private PayPalTransaction paypalTransaction;

        [TestInitialize]
        public void TestInit()
        {
            paypalTransaction = new PayPalTransaction();

            shippingPrice = 10;
            shippingDiscount = 0;

            items = new List<PayPalItem>
            {
                new PayPalItem()
                {
                    Name = "Product number 01",
                    Description = "That's my description of my product",
                    Price = 50,
                    Sku = "1001",
                    Currency = PayPalCurrency.AUD,
                    Quantity = 3,
                    Tax = 0
                },
                new PayPalItem()
                {
                    Name = "Product number 02",
                    Description = "That's my description of my product",
                    Price = 40,
                    Sku = "1002",
                    Currency = PayPalCurrency.AUD,
                    Quantity = 1,
                    Tax = 1.3
                },
                new PayPalItem()
                {
                    Name = "Product number 023",
                    Description = "That's my description of my product",
                    Price = 60,
                    Sku = "10023",
                    Currency = PayPalCurrency.AUD,
                    Quantity = 2,
                    Tax = 3.4
                }
            };
        }

        [TestMethod]
        public void Check_Total()
        {
            var expected = 328.1;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice, shippingDiscount);
            Assert.AreEqual(expected, amount.Total, "The value should be 328.1");
        }

        [TestMethod]
        public void Check_SubTotal()
        {
            var expected = 310;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice, shippingDiscount);
            Assert.AreEqual(expected, amount.Details.Subtotal, "The value should be 310");
        }

        [TestMethod]
        public void Check_Shipping()
        {
            var expected = 10;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice, shippingDiscount);
            Assert.AreEqual(expected, amount.Details.Shipping, "The value should be 10");
        }

        [TestMethod]
        public void Check_Tax()
        {
            var expected = 8.1;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice, shippingDiscount);
            Assert.AreEqual(expected, amount.Details.Tax, "The value should be 8.1");
        }
    }
}
