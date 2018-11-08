# PayPal Web.config Settings

```sh
<configuration>
  <configSections>
    <section name="payPalCheckout" type="PayPalCheckout.PayPalCheckoutSection" allowLocation="true" allowDefinition="Everywhere" />
  </configSections>
  <payPalCheckout>
    <clientId value="__client_id__" />
    <clientSecret value="__client_secret__" />
    <returnUrl value="__return_url__" />
    <cancelUrl value="__cancel_url__" />
  </payPalCheckout>
</configuration>
```