[![Build](https://github.com/dina-heidar/x509-certificate-locator/actions/workflows/build.yml/badge.svg)](https://github.com/dina-heidar/x509-certificate-locator/actions/workflows/build.yml) [![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/dina-heidar/x509-certificate-locator/blob/main/LICENSE) [![Release](https://img.shields.io/github/release/dina-heidar/x509-certificate-locator.svg)](https://github.com/dina-heidar/x509-certificate-locator/releases/latest)


# X509 Certificate Locator

Find an ECDSA or RSA certificate from the certificate store. 

## Install

## Usage

```csharp
X509Certificate2 cert = X509.LocalMachine.My.FindByThumbprint
    .Find("2ace2bec462efa2f84eb97bdf260adb0ad925519",
     validOnly: true, hasPrivateKey: true, isEcdsa: false);
```
