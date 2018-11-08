using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPalCheckout
{
    public enum AllowedPaymentMethod
    {
        INSTANT_FUNDING_SOURCE
    }

    public enum Intent
    {
        SALE
    }

    public enum PaymentMethod
    {
        PAYPAL
    }

    public enum PayPalCurrency
    {
        AUD,
        USD
    }
}
