using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayPalCheckout
{
    public class AllowedPaymentMethodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (AllowedPaymentMethod)value;

            switch (messageTransportResponseStatus)
            {
                case AllowedPaymentMethod.INSTANT_FUNDING_SOURCE:
                    writer.WriteValue("INSTANT_FUNDING_SOURCE");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(AllowedPaymentMethod), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public class IntentConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (Intent)value;

            switch (messageTransportResponseStatus)
            {
                case Intent.SALE:
                    writer.WriteValue("sale");
                    break;
                case Intent.AUTHORIZE:
                    writer.WriteValue("authorize");
                    break;
                case Intent.ORDER:
                    writer.WriteValue("order");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(Intent), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public class PaymentMethodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (PaymentMethod)value;

            switch (messageTransportResponseStatus)
            {
                case PaymentMethod.PAYPAL:
                    writer.WriteValue("paypal");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(PaymentMethod), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public class PayPalCurrencyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (PayPalCurrency)value;

            switch (messageTransportResponseStatus)
            {
                case PayPalCurrency.AUD:
                    writer.WriteValue("AUD");
                    break;
                case PayPalCurrency.USD:
                    writer.WriteValue("USD");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(PayPalCurrency), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public class PayPalStateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (PayPalState)value;

            switch (messageTransportResponseStatus)
            {
                case PayPalState.APPROVED:
                    writer.WriteValue("approved");
                    break;
                case PayPalState.CREATED:
                    writer.WriteValue("created");
                    break;
                case PayPalState.FAILED:
                    writer.WriteValue("failed");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(PayPalState), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public class PayPalFailureReasonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (PayPalFailureReason)value;

            switch (messageTransportResponseStatus)
            {
                case PayPalFailureReason.UNABLE_TO_COMPLETE_TRANSACTION:
                    writer.WriteValue("UNABLE_TO_COMPLETE_TRANSACTION");
                    break;
                case PayPalFailureReason.INVALID_PAYMENT_METHOD:
                    writer.WriteValue("INVALID_PAYMENT_METHOD");
                    break;
                case PayPalFailureReason.PAYER_CANNOT_PAY:
                    writer.WriteValue("PAYER_CANNOT_PAY");
                    break;
                case PayPalFailureReason.CANNOT_PAY_THIS_PAYEE:
                    writer.WriteValue("CANNOT_PAY_THIS_PAYEE");
                    break;
                case PayPalFailureReason.REDIRECT_REQUIRED:
                    writer.WriteValue("REDIRECT_REQUIRED");
                    break;
                case PayPalFailureReason.PAYEE_FILTER_RESTRICTIONS:
                    writer.WriteValue("PAYEE_FILTER_RESTRICTIONS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(PayPalFailureReason), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

    public class PayPalLinkMethodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var messageTransportResponseStatus = (PayPalLinkMethod)value;

            switch (messageTransportResponseStatus)
            {
                case PayPalLinkMethod.GET:
                    writer.WriteValue("GET");
                    break;
                case PayPalLinkMethod.POST:
                    writer.WriteValue("POST");
                    break;
                case PayPalLinkMethod.PUT:
                    writer.WriteValue("PUT");
                    break;
                case PayPalLinkMethod.DELETE:
                    writer.WriteValue("DELETE");
                    break;
                case PayPalLinkMethod.HEAD:
                    writer.WriteValue("HEAD");
                    break;
                case PayPalLinkMethod.CONNECT:
                    writer.WriteValue("CONNECT");
                    break;
                case PayPalLinkMethod.OPTIONS:
                    writer.WriteValue("OPTIONS");
                    break;
                case PayPalLinkMethod.PATCH:
                    writer.WriteValue("PATCH");
                    break;
                case PayPalLinkMethod.REDIRECT:
                    writer.WriteValue("REDIRECT");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(PayPalLinkMethod), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
