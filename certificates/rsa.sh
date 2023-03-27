#! /bin/bash

if [ "$#" -ne 4 ]
then
  echo "Error: Invalid number of arguments"
  echo "Usage: ./file.sh [DOMAIN] [PASSPHRASE] [DAYS] [KEYSIZE]"
  exit 1
fi

DOMAIN=$1
PASSPHRASE=$2
DAYS=$3
KEYSIZE=$4

# Create root CA & Private key
openssl req -x509 \
            -sha256 -days ${DAYS} \
            -nodes \
            -newkey rsa:${KEYSIZE}  \
            -subj "//CN=${DOMAIN}/C=US/L=San Fransisco/" \
            -keyout rootCA.key -out rootCA.crt \
            -passin pass:${PASSPHRASE}

# Generate Private key 
openssl genrsa -out ${DOMAIN}.key ${KEYSIZE}  

# Create csf conf

cat > csr.conf <<EOF
[ req ]
default_bits = ${KEYSIZE} 
prompt = no
default_md = sha256
req_extensions = req_ext
distinguished_name = dn

[ dn ]
C = US
ST = California
L = San Fransisco
O = MLopsHub
OU = MlopsHub Dev
CN = ${DOMAIN}

[ req_ext ]
subjectAltName = @alt_names

[ alt_names ]
DNS.1 = ${DOMAIN}
DNS.2 = www.${DOMAIN}

EOF

# create CSR request using private key

openssl req -new -key ${DOMAIN}.key -out ${DOMAIN}.csr -config csr.conf -passin pass:${PASSPHRASE} -passout pass:${PASSPHRASE}

# Create a external config file for the certificate

cat > cert.conf <<EOF

authorityKeyIdentifier=keyid,issuer
basicConstraints=CA:FALSE
keyUsage = digitalSignature, nonRepudiation, keyEncipherment, dataEncipherment
subjectAltName = @alt_names

[alt_names]
DNS.1 = ${DOMAIN}

EOF

# Create SSl with self signed CA
echo "Test"
openssl x509 -req \
    -in ${DOMAIN}.csr \
    -CA rootCA.crt -CAkey rootCA.key \
    -CAcreateserial -out ${DOMAIN}.crt \
    -days ${DAYS} \
    -sha256 \
    -extfile cert.conf \
    -passin pass:${PASSPHRASE}

echo "pfx"
openssl pkcs12 -export \
    -out ${DOMAIN}_rsa.pfx \
    -inkey ${DOMAIN}.key \
    -in ${DOMAIN}.crt \
    -certfile rootCA.crt \
    -passin pass:${PASSPHRASE} \
    -passout pass:${PASSPHRASE}


 
$SHELL
