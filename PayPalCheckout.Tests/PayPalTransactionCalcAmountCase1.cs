using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayPalCheckout.Tests
{
    [TestClass]
    public class PayPalTransactionCalcAmountCase1
    {
        private List<PayPalItem> items;
        private double shippingPrice;
        private PayPalTransaction paypalTransaction;

        [TestInitialize]
        public void TestInit()
        {
            paypalTransaction = new PayPalTransaction();

            shippingPrice = 10;

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
                }
            };
        }

        [TestMethod]
        public void Check_Total()
        {
            var expected = 201.3;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice);
            Assert.AreEqual(expected, amount.Total, "The value should be 201.3");
        }

        [TestMethod]
        public void Check_SubTotal()
        {
            var expected = 190;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice);
            Assert.AreEqual(expected, amount.Details.Subtotal, "The value should be 190");
        }

        [TestMethod]
        public void Check_Shipping()
        {
            var expected = 10;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice);
            Assert.AreEqual(expected, amount.Details.Shipping, "The value should be 10");
        }

        [TestMethod]
        public void Check_Tax()
        {
            var expected = 1.3;
            var amount = paypalTransaction.CalcAmount(PayPalCurrency.AUD, items, shippingPrice);
            Assert.AreEqual(expected, amount.Details.Tax, "The value should be 1.3");
        }
    }
}
