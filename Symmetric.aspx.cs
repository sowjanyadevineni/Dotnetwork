using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security.Policy;
using System.IO;


namespace Assignment4
{
    public partial class Symmetric : System.Web.UI.Page
    {
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] buffer;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region : : SYMMETRIC KEY GENERATION

        protected void btnGenerateSymKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPlainText.Text.Trim()))
                {
                    des.GenerateIV();
                    des.GenerateKey();
                    txtSymKey.Text = Convert.ToBase64String(des.Key);// System.Text.Encoding.Default.GetString(des.Key) + " " + System.Text.Encoding.UTF8.GetString(des.Key);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnEncryptSym_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPlainText.Text.Trim()))
                {
                    buffer = Encrypt(txtPlainText.Text, des);
                    txtCiphertext.Text = Convert.ToBase64String(buffer);
                    Session["Cipher"] = buffer;

                    ViewState["DECRYPTED_TEXT"] = Decrypt(buffer, des);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnDecryptSym_Click(object sender, EventArgs e)
        {
            try
            {
                txtCipherToPlain.Text = Convert.ToString(ViewState["DECRYPTED_TEXT"]);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static byte[] Encrypt(string strText, SymmetricAlgorithm key)
        {
            // Create a memory stream.
            MemoryStream ms = new MemoryStream();

            // Create a CryptoStream using the memory stream and the
            // CSP(cryptoserviceprovider) DES key.
            CryptoStream crypstream = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

            // Create a StreamWriter to write a string to the stream.
            StreamWriter sw = new StreamWriter(crypstream);

            // Write the strText to the stream.
            sw.WriteLine(strText);

            // Close the StreamWriter and CryptoStream.
            sw.Close();
            crypstream.Close();

            // Get an array of bytes that represents the memory stream.
            byte[] buffer = ms.ToArray();

            // Close the memory stream.
            ms.Close();

            // Return the encrypted byte array.
            return buffer;
        }

        public static string Decrypt(byte[] encryptText, SymmetricAlgorithm key)
        {
            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(encryptText);
            // Create a CryptoStream using  memory stream and CSP DES key.
            CryptoStream crypstream = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

            // Create a StreamReader for reading the stream.
            StreamReader sr = new StreamReader(crypstream);

            // Read the stream as a string.
            string val = sr.ReadLine();

            // Close the streams.
            sr.Close();
            crypstream.Close();
            ms.Close();

            return val;
        }

        #endregion

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtCiphertext.Text = txtSymKey.Text = txtPlainText.Text = txtCipherToPlain.Text = "";
            }
            catch (Exception)
            {
            }
        }



     



        //protected void btngenerateHash_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtGenerateHash.Text = PasswordHash.HashPassword(txtPlainText.Text.Trim());

        //        //bool repass = PasswordHash.ValidatePassword("Sunil1", pass);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //protected void btnValidateHash_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (PasswordHash.ValidatePassword(txtPlainTextAgain.Text, txtHashToValidate.Text))
        //        {
        //            lblMsg.Text = "Hash validation success!";
        //        }
        //        else
        //            lblMsg.Text = "Hash validation fail!";
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}





        //private static string GetRandomSalt()
        //{
        //    return BCrypt.GenerateSalt(12);
        //}

        //public static string HashPassword(string password)
        //{
        //    return BCrypt.HashPassword(password, GetRandomSalt());
        //}

        //public static bool ValidatePassword(string password, string correctHash)
        //{
        //    return BCrypt.Verify(password, correctHash);
        //}
    }





    public class PasswordHash
    {
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash
        public const int PBKDF2_ITERATIONS = 1000;
        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        public static string HashPassword(string password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            cryptoProvider.GetBytes(salt);

            var hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = Int32.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}