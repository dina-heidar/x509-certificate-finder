
# X509 Certificate Finder

Find an ECDSA or RSA certificate from the certificate store. 

## Install

```csharp
dotnet add package X509StoreFinder
```

## Usage

```csharp
X509Certificate2 cert = X509.LocalMachine.My.FindByThumbprint
    .Find("2ace2bec462efa2f84eb97bdf260adb0ad925519",
     validOnly: true, hasPrivateKey: true, isEcdsa: false);
```
