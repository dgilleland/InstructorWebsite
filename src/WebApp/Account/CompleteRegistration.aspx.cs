using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Account
{
    public partial class CompleteRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FirstName.Text = Session["fn"].ToString();
                LoginName.Text = Session["ln"].ToString();
                Surname.Text = Session["sn"].ToString();
                EMail.Text = Session["em"].ToString();
                CourseFullName.Text = Session["c_fn"].ToString();
                CourseShortName.Text = Session["c_sn"].ToString();
                SelfRegistrationPanel.Visible = !(MessageLabel.Visible = false);
            }
            catch
            {
                MessageLabel.Text = "Consult your instructor for details on how to complete your self-registration";
            }
        }
    }
}