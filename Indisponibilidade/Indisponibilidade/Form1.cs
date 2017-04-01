using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indisponibilidade
{
    public partial class Form1 : Form
    {
        public X509Certificate2 selCertificado()
        {
            X509Certificate2 cert = null;
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
            //X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);               
            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(fcollection, "Certificado(s) digital(is) válido(s) disponivel(is) ", "Selecione o certificado digital", X509SelectionFlag.SingleSelection);

            if (scollection.Count > 0)
                cert = scollection[0];

            store.Close();

            return cert;
        }// fim do buscador de certificado

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cni.servClient serv = new cni.servClient();
            cni.auth auth = new cni.auth();
            auth.challenge = serv.challenge_generator().retorno.info.challenge;
            byte[] challenge = Convert.FromBase64String(auth.challenge);
            X509Certificate2 cert = selCertificado();

            RSACryptoServiceProvider rsaKey;
            rsaKey = (RSACryptoServiceProvider)cert.PrivateKey;

            byte[] encryptedData;
            if (cert.SignatureAlgorithm.FriendlyName.Equals("sha1RSA"))
            {
                encryptedData = rsaKey.SignData(challenge, CryptoConfig.MapNameToOID("SHA1"));
            }
            else if (cert.SignatureAlgorithm.FriendlyName.Equals("sha256RSA"))
            {
                RSACryptoServiceProvider rsaClear = new RSACryptoServiceProvider();
                rsaClear.ImportParameters(rsaKey.ExportParameters(true));
                encryptedData = rsaClear.SignData(challenge, CryptoConfig.CreateFromName("SHA256"));
            }
            else
            {
                throw new Exception("Certificado não suportado.");
            }

            auth.signature = Convert.ToBase64String(encryptedData);
            auth.certificate = Convert.ToBase64String(cert.Export(X509ContentType.Cert));
            //auth.token = "LilH4NDK9NY93d/zHbhdDikpJrK69ogL8/uJEQAud7NQMrSXjcHPp2pWhM6W+oQcnKSjoRE0j0YxWbGkT8bFwpEPLlMQrwczNdPYjJGCyMjzsoFhDYEq9jk/zst17A4gF780jwla2cYOvnLt4RPSrxxL5yCCSwtHLn2s4Ol9GbuIXtfFPpAHf7mCUnp7HP9a5BAvSgWGyohIjtqoIu+RcA==";
            //serv.Close();
            var retorno = serv.auth(auth).retorno;
            if (retorno.success)
            {
                serv.Close();
                string session_id = retorno.info.session_id;
            }
            else
            {
                textBox1.Text = retorno.info.faultMessage;
                serv.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cni.servClient serv = new cni.servClient();
            cni.auth auth = new cni.auth();
            auth.challenge = serv.challenge_generator().retorno.info.challenge;
            byte[] challenge = Convert.FromBase64String(auth.challenge);
            X509Certificate2 cert = selCertificado();

            RSACryptoServiceProvider rsaKey;
            rsaKey = (RSACryptoServiceProvider)cert.PrivateKey;

            byte[] encryptedData;
            if (cert.SignatureAlgorithm.FriendlyName.Equals("sha1RSA"))
            {
                encryptedData = rsaKey.SignData(challenge, CryptoConfig.MapNameToOID("SHA1"));
            }
            else if (cert.SignatureAlgorithm.FriendlyName.Equals("sha256RSA"))
            {
                RSACryptoServiceProvider rsaClear = new RSACryptoServiceProvider();
                rsaClear.ImportParameters(rsaKey.ExportParameters(true));
                encryptedData = rsaClear.SignData(challenge, CryptoConfig.CreateFromName("SHA256"));
            }
            else
            {
                throw new Exception("Certificado não suportado.");
            }

            auth.signature = Convert.ToBase64String(encryptedData);
            auth.certificate = Convert.ToBase64String(cert.Export(X509ContentType.Cert));
            //auth.token = "LilH4NDK9NY93d/zHbhdDikpJrK69ogL8/uJEQAud7NQMrSXjcHPp2pWhM6W+oQcnKSjoRE0j0YxWbGkT8bFwpEPLlMQrwczNdPYjJGCyMjzsoFhDYEq9jk/zst17A4gF780jwla2cYOvnLt4RPSrxxL5yCCSwtHLn2s4Ol9GbuIXtfFPpAHf7mCUnp7HP9a5BAvSgWGyohIjtqoIu+RcA==";
            //serv.Close();
            var retorno = serv.auth(auth).retorno;
            if (retorno.success)
            {
                serv.Close();
                string session_id = retorno.info.session_id;
            }
            else
            {
                textBox1.Text = retorno.info.faultMessage;
                serv.Close();
            }
        }

    }
}
