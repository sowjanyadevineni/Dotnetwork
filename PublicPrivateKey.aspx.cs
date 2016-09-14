using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security.Policy;
using System.IO;
using System.Text;


namespace Assignment4
{
    public partial class PublicPrivateKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPublicPrivate_Click(object sender, EventArgs e)
        {
            try
            {
                ////Generate a public/private key pair.
                //RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                ////Save the public key information to an RSAParameters structure.
                //RSAParameters RSAKeyInfo = RSA.ExportParameters(true);

                ////public key 
                //string publickey = Convert.ToBase64String(RSAKeyInfo.D);
                //txtPublicKey.Text = publickey;
                //// pravite key 
                //string privateKay = Convert.ToBase64String(RSAKeyInfo.Exponent);
                //txtPrivateKey.Text = privateKay;



                // Variables
                CspParameters cspParams = null;
                RSACryptoServiceProvider rsaProvider = null;
                StreamWriter publicKeyFile = null;
                StreamWriter privateKeyFile = null;
                string publicKey = "";
                string privateKey = "";

                try
                {
                    if (!string.IsNullOrEmpty(txtPlainText.Text.Trim()))
                    {
                        // Create a new key pair on target CSP
                        cspParams = new CspParameters();
                        cspParams.ProviderType = 1; // PROV_RSA_FULL 
                        //cspParams.ProviderName; // CSP name
                        cspParams.Flags = CspProviderFlags.UseArchivableKey;
                        cspParams.KeyNumber = (int)KeyNumber.Exchange;
                        rsaProvider = new RSACryptoServiceProvider(cspParams);

                        // Export public key
                        publicKey = rsaProvider.ToXmlString(false);
                        txtPublicKey.Text = publicKey;

                        // Write public key to file
                        publicKeyFile = File.CreateText("ddd");
                        publicKeyFile.Write(publicKey);

                        // Export private/public key pair 
                        privateKey = rsaProvider.ToXmlString(true);

                        txtPrivateKey.Text = privateKey;
                    }
                    //// Write private/public key pair to file
                    //privateKeyFile = File.CreateText("dd");
                    //privateKeyFile.Write(privateKey);
                }
                catch (Exception ex)
                {
                    // Any errors? Show them
                    Console.WriteLine("Exception generating a new key pair! More info:");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Do some clean up if needed
                    if (publicKeyFile != null)
                    {
                        publicKeyFile.Close();
                    }
                    if (privateKeyFile != null)
                    {
                        privateKeyFile.Close();
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        protected void btnEncryptPublicKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPublicKey.Text.Trim()))
                {
                    string public_key = txtPublicKey.Text;
                    //Encrypting the text using the public key
                    RSACryptoServiceProvider cipher = null;
                    cipher = new RSACryptoServiceProvider();
                    cipher.FromXmlString(public_key);
                    byte[] data = Encoding.UTF8.GetBytes(txtPlainText.Text);
                    byte[] cipherText = cipher.Encrypt(data, false);
                    txtChiperTextUsingPublicKey.Text = Convert.ToBase64String(cipherText);

                }
                // Encrypt(txtPublicKey.Text, txtPlainText.Text, txtChiperTextUsingPublicKey);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnDecryptUsingPrivateKey_Click(object sender, EventArgs e)
        {
            try
            {
                //txtPlainTextDecryPrivate

                //This is the private and public key.
                if (!string.IsNullOrEmpty(txtPrivateKey.Text.Trim()))
                {
                    String private_key = txtPrivateKey.Text;

                    RSACryptoServiceProvider cipher = null;
                    cipher = new RSACryptoServiceProvider();
                    cipher.FromXmlString(private_key);

                    byte[] ciphterText = Convert.FromBase64String(txtChiperTextUsingPublicKey.Text);
                    byte[] plainText = cipher.Decrypt(ciphterText, false);

                    txtPlainTextDecryPrivate.Text = Encoding.UTF8.GetString(plainText); //Convert.ToBase64String(plainText);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtChiperTextUsingPublicKey .Text = txtPlainText.Text = txtPlainTextDecryPrivate.Text = txtPrivateKey.Text =txtPublicKey.Text="";
            }
            catch (Exception)
            {
            }
        }



        // Encryption using public key
        static void Encrypt(string publicKey, string plaintext, TextBox txtChiperTextUsingPublicKey)
        {
            // Variables
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamReader publicKeyFile = null;
            StreamReader plainFile = null;
            FileStream encryptedFile = null;
            string publicKeyText = "";
            string plainText = "";
            byte[] plainBytes = null;
            byte[] encryptedBytes = null;

            try
            {
                // Select target CSP
                cspParams = new CspParameters();
                cspParams.ProviderType = 1; // PROV_RSA_FULL 
                //cspParams.ProviderName; // CSP name
                rsaProvider = new RSACryptoServiceProvider(cspParams);

                //// Read public key from file
                //publicKeyFile = File.OpenText(publicKeyFileName);
                //publicKeyText = publicKeyFile.ReadToEnd();

                // Import public key
                rsaProvider.FromXmlString(publicKey);

                //// Read plain text from file
                //plainFile = File.OpenText(plainFileName);
                //plainText = plainFile.ReadToEnd();

                // Encrypt plain text
                plainBytes = Encoding.Unicode.GetBytes(plaintext);
                encryptedBytes = rsaProvider.Encrypt(plainBytes, false);


                txtChiperTextUsingPublicKey.Text = Convert.ToBase64String(encryptedBytes);

                //// Write encrypted text to file
                //encryptedFile = File.Create(encryptedFileName);
                //encryptedFile.Write(encryptedBytes, 0, encryptedBytes.Length);
            }
            catch (Exception ex)
            {
                // Any errors? Show them
                Console.WriteLine("Exception encrypting file! More info:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Do some clean up if needed
                if (publicKeyFile != null)
                {
                    publicKeyFile.Close();
                }
                if (plainFile != null)
                {
                    plainFile.Close();
                }
                if (encryptedFile != null)
                {
                    encryptedFile.Close();
                }
            }

        }




    }
}