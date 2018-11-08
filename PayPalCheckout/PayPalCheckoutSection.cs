using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PayPalCheckout
{
    internal class PayPalCheckoutSection : ConfigurationSection
    {
        [ConfigurationProperty("clientId")]
        public ClientIdElement ClientId
        {
            get
            {
                return (ClientIdElement)this["clientId"];
            }
            set
            { this["clientId"] = value; }
        }

        [ConfigurationProperty("clientSecret")]
        public ClientSecretElement ClientSecret
        {
            get
            {
                return (ClientSecretElement)this["clientSecret"];
            }
            set
            { this["clientSecret"] = value; }
        }

        [ConfigurationProperty("returnUrl")]
        public ReturnUrlElement ReturnUrl
        {
            get
            {
                return (ReturnUrlElement)this["returnUrl"];
            }
            set
            { this["returnUrl"] = value; }
        }

        [ConfigurationProperty("cancelUrl")]
        public CancelUrlElement CancelUrl
        {
            get
            {
                return (CancelUrlElement)this["cancelUrl"];
            }
            set
            { this["cancelUrl"] = value; }
        }
    }

    internal class ClientIdElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    internal class ClientSecretElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    internal class ReturnUrlElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    internal class CancelUrlElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }
}
