// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using X509StoreFinder;

X509Certificate2 cert = X509.LocalMachine.My.FindByThumbprint
    .Find("2ace2bec462efa2f84eb97bdf260adb0ad925519",
     validOnly: true, hasPrivateKey: true, isEcdsa: false);

Console.WriteLine("Raw Cert Data!");
Console.WriteLine(cert.GetRawCertDataString());
Console.ReadLine();
