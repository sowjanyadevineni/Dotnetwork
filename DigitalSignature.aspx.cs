using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;
using System.Net;

namespace Assignment4
{
    public partial class DigitalSignature : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string str = "Sunil";
            //byte[] bytes = new byte[str.Length * sizeof(char)];
            //System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

            //SHA1 mySha1 = new SHA1CryptoServiceProvider();
            //byte[] hash = mySha1.ComputeHash(bytes);

        }
        protected void btnReadFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileXMLUploader.HasFile)
                {
                    string filename = Path.GetFileName(fileXMLUploader.PostedFile.FileName);
                    string path = Server.MapPath("UploadFiles/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    fileXMLUploader.SaveAs(path + filename);
                    ViewState["FILE_PATH"] = path + filename;
                    RichTextBoxPlane.Text = File.ReadAllText(path + filename);
                }
            }
            catch (Exception)
            {
            }
        }
        protected void btnGetDigitalSignature_Click(object sender, EventArgs e)
        {
            try
            { // Create a new CspParameters object to specify 
                // a key container.
                CspParameters cspParams = new CspParameters();
                cspParams.KeyContainerName = "XML_DSIG_RSA_KEY";

                // Create a new RSA signing key and save it in the container. 
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                // Create a new XML document.
                XmlDocument xmlDoc = new XmlDocument();

                // Load an XML file into the XmlDocument object.
                xmlDoc.PreserveWhitespace = true;
                string path = Convert.ToString(ViewState["FILE_PATH"]);
                xmlDoc.Load(path);

                // Sign the XML document. 
                SignXml(xmlDoc, rsaKey);

                Console.WriteLine("XML file signed.");

                // Save the document.
                xmlDoc.Save(path);

                RichTextBoxConverted.Text = File.ReadAllText(path);

            }
            catch (Exception)
            {
            }
        }

        // Sign an XML file.  
        // This document cannot be verified unless the verifying  
        // code has the key with which it was signed. 
        public static void SignXml(XmlDocument xmlDoc, RSA Key)
        {
            // Check arguments. 
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            if (Key == null)
                throw new ArgumentException("Key");

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = Key;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save 
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

        }

        protected void btnValidateXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUploadValidate.HasFile)
                {
                    string filename = Path.GetFileName(fileUploadValidate.PostedFile.FileName);
                    string path = Server.MapPath("ConvertedFiles/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    fileUploadValidate.SaveAs(path + filename);
                    ViewState["FILE_PATH"] = path + filename;

                    // Create a new CspParameters object to specify 
                    // a key container.
                    CspParameters cspParams = new CspParameters();
                    cspParams.KeyContainerName = "XML_DSIG_RSA_KEY";

                    // Create a new RSA signing key and save it in the container. 
                    RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                    // Create a new XML document.
                    XmlDocument xmlDoc = new XmlDocument();

                    // Load an XML file into the XmlDocument object.
                    xmlDoc.PreserveWhitespace = true;

                    xmlDoc.Load(Convert.ToString(ViewState["FILE_PATH"]));

                    // Verify the signature of the signed XML.
                    Console.WriteLine("Verifying signature...");
                    bool result = VerifyXml(xmlDoc, rsaKey);

                    // Display the results of the signature verification to  
                    // the console. 
                    if (result)
                    {
                        Console.WriteLine("");
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The XML signature is valid.');", true);
                    }
                    else
                    {
                        Console.WriteLine("");
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The XML signature is not valid.');", true);
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('The file is not valid.');", true);
            }
        }

        // Verify the signature of an XML file against an asymmetric  
        // algorithm and return the result. 
        public static Boolean VerifyXml(XmlDocument Doc, RSA Key)
        {
            // Check arguments. 
            if (Doc == null)
                throw new ArgumentException("Doc");
            if (Key == null)
                throw new ArgumentException("Key");

            // Create a new SignedXml object and pass it 
            // the XML document class.
            SignedXml signedXml = new SignedXml(Doc);

            // Find the "Signature" node and create a new 
            // XmlNodeList object.
            XmlNodeList nodeList = Doc.GetElementsByTagName("Signature");

            // Throw an exception if no signature was found. 
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Verification failed: No Signature was found in the document.");
            }

            // This example only supports one signature for 
            // the entire XML document.  Throw an exception  
            // if more than one signature was found. 
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Verification failed: More that one signature was found for the document.");
            }

            // Load the first <signature> node.  
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result. 
            return signedXml.CheckSignature(Key);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Convert.ToString(ViewState["FILE_PATH"]);
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + "test.xml");
                byte[] data = req.DownloadData(path);
                response.BinaryWrite(data);
                response.End();

            }
            catch (Exception)
            {
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                RichTextBoxPlane.Text = RichTextBoxConverted.Text="";
                ViewState["FILE_PATH"] = "";
            }
            catch (Exception)
            {
            }
        }

    }
}