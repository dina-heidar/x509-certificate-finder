# X509 Certificate Locator

Find an ECDSA or RSA certificate from the certificate store. 

## Install

## Usage

```csharp
X509Certificate2 cert = X509.LocalMachine.My.FindByThumbprint
    .Find("2ace2bec462efa2f84eb97bdf260adb0ad925519",
     validOnly: true, hasPrivateKey: true, isEcdsa: false);
```
