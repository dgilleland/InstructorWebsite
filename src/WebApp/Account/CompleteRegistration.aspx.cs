using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Account.BLL;
using WebApp.Account.Model;

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

        protected void RegisterMe_Click(object sender, EventArgs e)
        {
            var userAccount = new UserAccount()
            {
                LoginName = LoginName.Text,
                FirstName = FirstName.Text,
                LastName = Surname.Text,
                Email = EMail.Text,
                GitHubUsername = GitHubUserName.Text
            };
            var course = CourseOffering.Create(CourseFullName.Text, CourseShortName.Text);
            new AccountManager().SelfRegistration(course, userAccount);
            Response.Redirect("~/Default.aspx");
        }
    }
}