using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pages= Page.Page.ToString();
            if (!IsPostBack)
            {
                liSymmetric.Attributes.Remove("class");
                liPublicPrivateKey.Attributes.Remove("class");
                liHash.Attributes.Remove("class");
                liDigitalSignature.Attributes.Remove("class");

                switch (pages)
                {
                    case "ASP.hash_aspx": liHash.Attributes.Add("class", "active"); break;
                    case "ASP.symmetric_aspx": liSymmetric.Attributes.Add("class", "active"); break;
                    case "ASP.publicprivatekey_aspx": liPublicPrivateKey.Attributes.Add("class", "active"); break;
                    case "ASP.digitalsignature_aspx": liDigitalSignature.Attributes.Add("class", "active"); break;
                }
                

            }
        }
    }
}