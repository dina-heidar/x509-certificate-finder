// Copyright (c) 2023 Dina Heidar
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
//
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM
//
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System.Security.Cryptography.X509Certificates;

namespace X509StoreFinder
{
    public class X509FindByType
    {
        private readonly StoreLocation storeLocation;
        private readonly StoreName storeName;
        private readonly X509FindType x509FindType;

        /// <summary>
        /// Initializes a new instance of the <see cref="X509FindByType"/> class.
        /// </summary>
        /// <param name="storeLocation">The store location.</param>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="x509FindType">Type of the X509 find.</param>
        public X509FindByType(StoreLocation storeLocation, StoreName storeName, X509FindType x509FindType)
        {
            this.storeLocation = storeLocation;
            this.storeName = storeName;
            this.x509FindType = x509FindType;
        }

        /// <summary>
        /// Finds the specified value.
        /// </summary>
        /// <param name="value">The value of the identitfier.</param>
        /// <param name="validOnly">valid certificates, if set to <c>true</c> [valid only].</param>
        /// <param name="hasPrivateKey">certificate has private key, if set to <c>true</c> [has private key].</param>
        /// <param name="isEcdsa">certificate is an ECDSA, if set to <c>true</c> [is ecdsa].</param>
        /// <returns></returns>
        /// <exception cref="X509StoreFinder.X509FinderExceptions">
        /// The certificate could not be found.
        /// or
        /// Multiple certificates were found, must only provide one.
        /// or
        /// The RSA certificate has no private key.
        /// or
        /// The ECDSA certificate has no private key.
        /// </exception>        
        public X509Certificate2 Find(string value,
            bool validOnly = true,
            bool hasPrivateKey = true,
            bool isEcdsa = false)
        {
            using (var store = new X509Store(storeName, storeLocation))
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection collection = store.Certificates.Find(x509FindType, value, validOnly);
                store.Close();

                if (collection.Count == 0)
                {
                    throw new X509FinderExceptions("The certificate could not be found.");
                }
                if (collection.Count > 1)
                {
                    throw new X509FinderExceptions("Multiple certificates were found, must only provide one.");
                }

                var x509Cert = collection[0] as X509Certificate2;

                if (!isEcdsa) //rsa certificate
                {
                    if (x509Cert.GetRSAPrivateKey() == null && hasPrivateKey)
                    {
                        throw new X509FinderExceptions("The RSA certificate has no private key.");
                    }
                }
                else //ecdsa certificate
                {
                    //maker sure machine/user has access to the private key
                    if (x509Cert.GetECDsaPrivateKey() == null && hasPrivateKey)
                    {
                        throw new X509FinderExceptions("The ECDSA certificate has no private key.");
                    }
                }
                return x509Cert;
            }
        }
    }
}

