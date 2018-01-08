using System;

namespace WebApp.Account
{
    public partial class FromMoodle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                foreach (string key in Request.QueryString.AllKeys)
                {
                    Session[key] = Request.QueryString[key];
                }
                Response.Redirect("CompleteRegistration.aspx");
            }
        }
    }
}