using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class Hash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btngenerateHash_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPlainText.Text.Trim()))
                {
                    txtGenerateHash.Text = PasswordHash.HashPassword(txtPlainText.Text.Trim());
                }
                //bool repass = PasswordHash.ValidatePassword("Sunil1", pass);
            }
            catch (Exception)
            {
            }
        }

        protected void btnValidateHash_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordHash.ValidatePassword(txtPlainTextAgain.Text, txtGenerateHash.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Hash validate succecsfully!!');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Hash validation fail!.');", true);
            }
            catch (Exception)
            {
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtPlainText.Text = txtGenerateHash.Text = txtPlainTextAgain.Text = "";
            }
            catch (Exception)
            {
            }
        }


    }
}