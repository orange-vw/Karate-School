using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.websites
{
    public partial class Instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User session validation
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
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
            var userID = from a in dbcon.NetUsers
                         where a.UserName == Page.User.Identity.Name
                         select a.UserID;

            // Get instructor's first and last name from InstructorID
            var name = from b in dbcon.Instructors
                       where b.InstructorID == userID.First()
                       select new { b.InstructorFirstName, b.InstructorLastName };

            // Update the lablel with the instructor's first and last name
            lblName.Text = name.First().InstructorFirstName + " " + name.First().InstructorLastName;

            // Check for null section
            var sectionRecord = dbcon.Sections.SingleOrDefault(x => x.Instructor_ID == userID.First());

            if (sectionRecord == null)
            {
                lblNoCurrentSections.Text = "You are not currently assigned any sections";
            }

            // Display the session information based on the logged in member
            var result = from c in dbcon.Sections
                          join d in dbcon.Members
                          on c.Member_ID equals d.Member_UserID
                          where userID.First() == c.Instructor_ID
                          select new { c.SectionName, d.MemberFirstName, d.MemberLastName };

            GridView1.DataSource = result;
            GridView1.DataBind();
        }
    }
}