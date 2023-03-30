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
    public class X509StoreName
    {
        private readonly StoreLocation storeLocation;
        private readonly StoreName storeName;
        /// <summary>
        /// Initializes a new instance of the <see cref="X509StoreName"/> class.
        /// </summary>
        /// <param name="storeLocation">The store location.</param>
        /// <param name="storeName">Name of the store.</param>
        public X509StoreName(StoreLocation storeLocation, StoreName storeName)
        {
            this.storeLocation = storeLocation;
            this.storeName = storeName;
        }

        /// <summary>
        /// Searches by the application policy value.
        /// </summary>
        /// <value>
        /// The find by application policy.
        /// </value>
        public X509FindByType FindByApplicationPolicy => new X509FindByType(storeLocation, storeName, X509FindType.FindByApplicationPolicy);
        /// <summary>
        /// Searches by the certificate policy value.
        /// </summary>
        /// <value>
        /// The find by certificate policy.
        /// </value>
        public X509FindByType FindByCertificatePolicy => new X509FindByType(storeLocation, storeName, X509FindType.FindByCertificatePolicy);
        /// <summary>
        /// Searches by the extension value.
        /// </summary>
        /// <value>
        /// The find by extension.
        /// </value>
        public X509FindByType FindByExtension => new X509FindByType(storeLocation, storeName, X509FindType.FindByExtension);
        /// <summary>
        /// Searches by the issuer distinguished value.
        /// </summary>
        /// <value>
        /// The name of the find by issuer distinguished.
        /// </value>
        public X509FindByType FindByIssuerDistinguishedName => new X509FindByType(storeLocation, storeName, X509FindType.FindByIssuerDistinguishedName);
        /// <summary>
        /// Searches by the issuer value.
        /// </summary>
        /// <value>
        /// The name of the find by issuer.
        /// </value>
        public X509FindByType FindByIssuerName => new X509FindByType(storeLocation, storeName, X509FindType.FindByIssuerName);
        /// <summary>
        /// Searches by the key usage value.
        /// </summary>
        /// <value>
        /// The find by key usage.
        /// </value>
        public X509FindByType FindByKeyUsage => new X509FindByType(storeLocation, storeName, X509FindType.FindByKeyUsage);
        /// <summary>
        /// Searches by the serial number value.
        /// </summary>
        /// <value>
        /// The find by serial number.
        /// </value>
        public X509FindByType FindBySerialNumber => new X509FindByType(storeLocation, storeName, X509FindType.FindBySerialNumber);
        /// <summary>
        /// Searches by the subject distinguished value.
        /// </summary>
        /// <value>
        /// The name of the find by subject distinguished.
        /// </value>
        public X509FindByType FindBySubjectDistinguishedName => new X509FindByType(storeLocation, storeName, X509FindType.FindBySubjectDistinguishedName);
        /// <summary>
        /// Searches by the subject key identifier value.
        /// </summary>
        /// <value>
        /// The find by subject key identifier.
        /// </value>
        public X509FindByType FindBySubjectKeyIdentifier => new X509FindByType(storeLocation, storeName, X509FindType.FindBySubjectKeyIdentifier);
        /// <summary>
        /// Searches by the subject value.
        /// </summary>
        /// <value>
        /// The name of the find by subject.
        /// </value>
        public X509FindByType FindBySubjectName => new X509FindByType(storeLocation, storeName, X509FindType.FindBySubjectName);
        /// <summary>
        /// Searches by the template value.
        /// </summary>
        /// <value>
        /// The name of the find by template.
        /// </value>
        public X509FindByType FindByTemplateName => new X509FindByType(storeLocation, storeName, X509FindType.FindByTemplateName);
        /// <summary>
        /// Searches by the thumbprint value.
        /// </summary>
        /// <value>
        /// The find by thumbprint.
        /// </value>
        public X509FindByType FindByThumbprint => new X509FindByType(storeLocation, storeName, X509FindType.FindByThumbprint);
        /// <summary>
        /// Searches by the time expired value.
        /// </summary>
        /// <value>
        /// The find by time expired.
        /// </value>
        public X509FindByType FindByTimeExpired => new X509FindByType(storeLocation, storeName, X509FindType.FindByTimeExpired);
        /// <summary>
        /// Searches by the time not yet valid value.
        /// </summary>
        /// <value>
        /// The find by time not yet valid.
        /// </value>
        public X509FindByType FindByTimeNotYetValid => new X509FindByType(storeLocation, storeName, X509FindType.FindByTimeNotYetValid);
        /// <summary>
        /// Searches by the time valid value.
        /// </summary>
        /// <value>
        /// The find by time valid.
        /// </value>
        public X509FindByType FindByTimeValid => new X509FindByType(storeLocation, storeName, X509FindType.FindByTimeValid);
    }
}
