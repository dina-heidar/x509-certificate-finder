#! /bin/bash

if [ "$#" -ne 1 ]
then
  echo "Error: Invalid number of arguments"
  echo "Usage: ./file.sh [DOMAIN] [PASSPHRASE] [DAYS] [KEYSIZE]"
  exit 1
fi

DOMAIN=$1
PASSPHRASE=123

#list all the curves
#openssl ecparam -list_curves

#generating a CA
openssl ecparam -genkey -name prime256v1 -out ca.key

# self-sign the CA and generate a certificate file
openssl req -x509 \
-new -SHA384 \
-nodes \
-key ca.key \
-days 3650 \
-out ca.crt  \
-subj "//CN=${DOMAIN}/C=US/L=San Fransisco/" \
-passin pass:${PASSPHRASE}

# generate the private key for our server certificate
openssl ecparam -genkey -name prime256v1 -out server.key

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


# create a certificate signing request (CSR)
openssl req -new -SHA384 -key server.key -nodes -out server.csr -config csr.conf -passin pass:${PASSPHRASE} -passout pass:${PASSPHRASE}

# view the full details of the CSR 
#openssl req -in server.csr -noout -text


cat > cert.conf <<EOF

authorityKeyIdentifier=keyid,issuer
basicConstraints=CA:FALSE
keyUsage = digitalSignature, nonRepudiation, keyEncipherment, dataEncipherment
subjectAltName = @alt_names

[alt_names]
DNS.1 = ${DOMAIN}

EOF

echo "sign it"
# sign your certificate
openssl x509 -req \
 -SHA384 \
 -extfile cert.conf \
 -days 365 \
 -in server.csr \
 -CA ca.crt \
 -CAkey ca.key \
 -CAcreateserial \
 -out server.crt \
 -passin pass:${PASSPHRASE}

openssl pkcs12 -export \
-inkey server.key \
-in server.crt \
-out ${DOMAIN}_ecdsa.pfx \
-certfile ca.crt \
-passin pass:${PASSPHRASE} \
-passout pass:${PASSPHRASE}


$SHELL