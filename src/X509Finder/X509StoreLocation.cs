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

namespace X509Finder
{
    public class X509StoreLocation
    {
        private readonly StoreLocation storeLocation;

        public X509StoreLocation(StoreLocation storeLocation)
        {
            this.storeLocation = storeLocation;
        }
        /// <summary>
        /// Searches the address book.
        /// </summary>
        /// <value>
        /// The address book.
        /// </value>
        public X509StoreName AddressBook => new X509StoreName(storeLocation, StoreName.AddressBook);
        /// <summary>
        /// Searches the authentication root.
        /// </summary>
        /// <value>
        /// The authentication root.
        /// </value>
        public X509StoreName AuthRoot => new X509StoreName(storeLocation, StoreName.AuthRoot);
        /// <summary>
        /// Searches the certificate authority.
        /// </summary>
        /// <value>
        /// The certificate authority.
        /// </value>
        public X509StoreName CertificateAuthority => new X509StoreName(storeLocation, StoreName.CertificateAuthority);
        /// <summary>
        /// Searches the disallowed.
        /// </summary>
        /// <value>
        /// The disallowed.
        /// </value>
        public X509StoreName Disallowed => new X509StoreName(storeLocation, StoreName.Disallowed);
        /// <summary>
        /// Searches the personal.
        /// </summary>
        /// <value>
        /// My.
        /// </value>
        public X509StoreName My => new X509StoreName(storeLocation, StoreName.My);
        /// <summary>
        /// Searches the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public X509StoreName Root => new X509StoreName(storeLocation, StoreName.Root);
        /// <summary>
        /// Searches the trusted people.
        /// </summary>
        /// <value>
        /// The trusted people.
        /// </value>
        public X509StoreName TrustedPeople => new X509StoreName(storeLocation, StoreName.TrustedPeople);
        /// <summary>
        /// Searches the trusted publisher.
        /// </summary>
        /// <value>
        /// The trusted publisher.
        /// </value>
        public X509StoreName TrustedPublisher => new X509StoreName(storeLocation, StoreName.TrustedPublisher);
    }
}
