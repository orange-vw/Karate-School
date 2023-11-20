using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.websites
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User session validation
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx", true);
                }
            }

            // Database connection
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mitch\\source\\repos\\orange-vw\\Karate-School\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
            KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn);

            // Get UserID from login user name
            var userID = from N in dbcon.NetUsers
                         where N.UserName == Page.User.Identity.Name
                         select N.UserID;

            // Get member's first and last name from Member_UserID
            var name = from M in dbcon.Members
                       where M.Member_UserID == userID.First()
                       select new { M.MemberFirstName, M.MemberLastName };

            // Update the lablel with the member's first and last name
            lblName.Text = name.First().MemberFirstName + " " + name.First().MemberLastName;

            // Check for null section
            var sectionRecord = dbcon.Sections.SingleOrDefault(x => x.Member_ID == userID.First());

            if (sectionRecord == null)
            {
                lblNoCurrentSections.Text = "You are not currently enrolled in any sections";
            }

            // Display the session information based on the logged in member
            var result = from c in dbcon.Sections
                         join d in dbcon.Instructors
                         on c.Instructor_ID equals d.InstructorID
                         where userID.First() == c.Member_ID
                         select new { c.SectionName, d.InstructorFirstName, d.InstructorLastName, PaymentDate = c.SectionStartDate };

            GridView1.DataSource = result;
            GridView1.DataBind();
        }
    }
}