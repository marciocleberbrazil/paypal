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
        SALE,
        AUTHORIZE,
        ORDER
    }

    public enum PaymentMethod
    {
        CREDIT_CARD,
        PAYPAL,
        PAY_UPON_INVOICE,
        CARRIER,
        ALTERNATE_PAYMENT,
        BANK
    }

    public enum PayPalCurrency
    {
        AUD,
        USD
    }

    public enum PayPalState
    {
        CREATED,
        APPROVED,
        FAILED
    }

    public enum PayPalFailureReason
    {
        UNABLE_TO_COMPLETE_TRANSACTION,
        INVALID_PAYMENT_METHOD,
        PAYER_CANNOT_PAY,
        CANNOT_PAY_THIS_PAYEE,
        REDIRECT_REQUIRED,
        PAYEE_FILTER_RESTRICTIONS
    }

    public enum PayPalLinkMethod
    {
        GET,
        POST,
        PUT,
        DELETE,
        HEAD,
        CONNECT,
        OPTIONS,
        PATCH,
        REDIRECT
    }

    public enum PayPalStatus
    {
        VERIFIED,
        UNVERIFIED
    }
}
