using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4.websites
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mitch\\source\\repos\\orange-vw\\Karate-School\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(conn);

            // Get UserID from login user name
            var userID = from N in dbcon.NetUsers
                         where N.UserName == Page.User.Identity.Name
                         select N.UserID;

            // Get member's first and last name from Member_UserID
            var name = from I in dbcon.Instructors
                       where I.InstructorID == userID.First()
                       select new { I.InstructorFirstName, I.InstructorLastName };

            // Update the lablel with the member's first and last name
            lblName.Text = name.First().InstructorFirstName + " " + name.First().InstructorLastName;

            // Load the GridViewMember
            var result = from M in dbcon.Members
                            select new { M.MemberFirstName, M.MemberLastName, M.MemberPhoneNumber, M.MemberDateJoined };
            GridViewMember.DataSource = result;
            GridViewMember.DataBind();

            // Load the GridViewInstructor
            var result2 = from I in dbcon.Instructors
                            select new { I.InstructorFirstName, I.InstructorLastName };
            GridViewInstructor.DataSource = result2;
            GridViewInstructor.DataBind();

            // Load the drpSectionAssign
            var result3 = (from S in dbcon.Sections
                            select S.SectionName).Distinct();

            drpSectionAssign.DataSource = result3;
            drpSectionAssign.DataBind();

            // Load the drpTimeAssign
            var result4 = (from S in dbcon.Sections
                            select S.SectionStartDate).Distinct();

            drpTimeAssign.DataSource = result4;
            drpTimeAssign.DataBind();

            // Load the drpInstructorAssign
            var result5 = (from I in dbcon.Instructors
                            select I.InstructorFirstName).Distinct();

            drpInstructorAssign.DataSource = result5;
            drpInstructorAssign.DataBind();
        }

        protected void btnMemberAdd_Click(object sender, EventArgs e)
        {
            if(!(txtFirstNameMember.Text == ""))
            {
                if (!(txtLastNameMember.Text == ""))
                {
                    if (!(txtDateJoined.Text == ""))
                    {
                        if (!(txtPhoneNumberMember.Text == ""))
                        {
                            if (!(txtEmail.Text == ""))
                            {
                                dbcon = new KarateSchoolDataContext(conn);

                                // New User row
                                Assignment4.NetUser newUser = new Assignment4.NetUser();

                                // Add data to newUser
                                newUser.UserName = txtFirstNameMember.Text;
                                newUser.UserPassword = txtLastNameMember.Text;
                                newUser.UserType = "Member";
                                // Add row to table
                                dbcon.NetUsers.InsertOnSubmit(newUser);
                                dbcon.SubmitChanges();

                                // New Member row
                                Assignment4.Member newMember = new Assignment4.Member();

                                // Get Correct Member ID
                                var MemberID = from a in dbcon.NetUsers
                                               where a.UserName == txtFirstNameMember.Text where a.UserPassword == txtLastNameMember.Text
                                               select a.UserID;

                                // Add data to newMember
                                newMember.Member_UserID = Convert.ToInt32(MemberID.First());
                                newMember.MemberFirstName = txtFirstNameMember.Text;
                                newMember.MemberLastName = txtLastNameMember.Text;
                                newMember.MemberDateJoined = Convert.ToDateTime(txtDateJoined.Text);
                                newMember.MemberPhoneNumber = txtPhoneNumberMember.Text;
                                newMember.MemberEmail = txtEmail.Text;
                                // Add row to table
                                dbcon.Members.InsertOnSubmit(newMember);
                                dbcon.SubmitChanges();

                                // Refresh GridViewMember
                                var result = from M in dbcon.Members
                                             select new { M.MemberFirstName, M.MemberLastName, M.MemberPhoneNumber, M.MemberDateJoined };
                                GridViewMember.DataSource = result;
                                GridViewMember.DataBind();

                                //Show confirmation
                                lblMemberAddErrorBlank.Text = "Add succsesfull!";

                                // Clear text boxes
                                txtFirstNameInstructor.Text = string.Empty;
                                txtLastNameMember.Text = string.Empty;
                                txtDateJoined.Text = string.Empty;
                                txtPhoneNumberMember.Text = string.Empty;
                                txtEmail.Text = string.Empty;
                            }
                            else
                            {
                                lblMemberAddErrorBlank.Text = "Email text box is blank!";
                            }
                        }
                        else
                        {
                            lblMemberAddErrorBlank.Text = "PhoneNumber text box is blank!";
                        }
                    }
                    else
                    {
                        lblMemberAddErrorBlank.Text = "Date Joined text box is blank!";
                    }
                }
                else
                {
                    lblMemberAddErrorBlank.Text = "Last Name text box is blank!";
                }
            }
            else
            {
                lblMemberAddErrorBlank.Text = "First Name text box is blank!";
            }
        }

        protected void btnInstructorAdd_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (!(txtFirstNameInstructor.Text == ""))
                {
                    if (!(txtLastNameInstructor.Text == ""))
                    {
                        if (!(txtPhoneNumberInstructor.Text == ""))
                        {
                            dbcon = new KarateSchoolDataContext(conn);

                            // New User row
                            Assignment4.NetUser newUser = new Assignment4.NetUser();

                            // Add data to newUser
                            newUser.UserName = txtFirstNameInstructor.Text;
                            newUser.UserPassword = txtLastNameInstructor.Text;
                            newUser.UserType = "Instructor";
                            //Add row to table
                            dbcon.NetUsers.InsertOnSubmit(newUser);
                            dbcon.SubmitChanges();

                            // New Member row
                            Assignment4.Instructor newInstructor = new Assignment4.Instructor();

                            // Get Correct Instructor ID
                            var InstructorID = from a in dbcon.NetUsers
                                               where a.UserName == txtFirstNameInstructor.Text
                                               select a.UserID;

                            // Add data to newInstructor
                            newInstructor.InstructorID = Convert.ToInt32(InstructorID.First());
                            newInstructor.InstructorFirstName = txtFirstNameInstructor.Text;
                            newInstructor.InstructorLastName = txtLastNameInstructor.Text;
                            newInstructor.InstructorPhoneNumber = txtPhoneNumberInstructor.Text;

                            // Add row to table
                            dbcon.Instructors.InsertOnSubmit(newInstructor);
                            dbcon.SubmitChanges();

                            // Refresh GridViewInstructor
                            var result = from I in dbcon.Instructors
                                         select new { I.InstructorFirstName, I.InstructorLastName };
                            GridViewInstructor.DataSource = result;
                            GridViewInstructor.DataBind();

                            //Show confirmation
                            lblInstructorAddError.Text = "Add succsesfull!";

                            // Clear text boxes
                            txtFirstNameInstructor.Text = string.Empty;
                            txtLastNameInstructor.Text = string.Empty;
                            txtPhoneNumberInstructor.Text = string.Empty;
                        }
                        else
                        {
                            lblMemberAddErrorBlank.Text = "Date Joined text box is blank!";
                        }
                    }
                    else
                    {
                        lblMemberAddErrorBlank.Text = "Last Name text box is blank!";
                    }
                }
                else
                {
                    lblMemberAddErrorBlank.Text = "First Name text box is blank!";
                }
            }
            catch (Exception ex)
            {
                
                lblInstructorAddError.Text = ex.Message;
            }
        }

        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dbcon = new KarateSchoolDataContext(conn))
                {
                    // Collect the records to delete
                    var memberRecord = dbcon.Members.SingleOrDefault(x => x.Member_UserID == Convert.ToInt32(lblMemberUserID.Text));
                    var userRecord = dbcon.NetUsers.SingleOrDefault(x => x.UserID == Convert.ToInt32(lblMemberUserID.Text));
                    var sectionRecord = dbcon.Sections.SingleOrDefault(x => x.Member_ID == Convert.ToInt32(lblMemberUserID.Text));

                    if (sectionRecord != null)
                    {
                        // Delete the Section record
                        dbcon.Sections.DeleteOnSubmit(sectionRecord);
                        dbcon.SubmitChanges();
                    }
                    else
                    {
                        lblMemberDeleteError.Text = "No Section record found, Attempting to delete";
                    }
                    dbcon.Connection.Close();

                    if (memberRecord != null)
                    {
                        //Delete the  Member Record
                        dbcon.Members.DeleteOnSubmit(memberRecord);
                        dbcon.SubmitChanges();
                    }
                    else
                    {
                        lblMemberDeleteError.Text = "There was an error while atampting to delete the Member Record";
                    }

                    if (userRecord != null)
                    {
                        //Delete the NetUser record
                        dbcon.NetUsers.DeleteOnSubmit(userRecord);
                        dbcon.SubmitChanges();
                    }
                    else
                    {
                        lblMemberDeleteError.Text = "There was an error while atampting to delete the NetUser Record";
                    }

                    // Show confirmation
                    lblIMemberDeleteConfirmation.Text = "Delete succsessful!";

                    // Clear labels
                    lblSelectedMemberFName.Text = string.Empty;
                    lblSelectedMemberFName1.Text = string.Empty;
                    lblSelectedMemberLName.Text = string.Empty;
                    lblSelectedMemberLName1.Text = string.Empty;
                    lblMemberUserID.Text = string.Empty;
                    lblMemberAssignError.Text = string.Empty;
                    lblMemberSectionID.Text = string.Empty;
                }
            } 
            catch (Exception ex)
            {
                lblMemberDeleteError.Text = ex.Message;
            }
                
            // Refresh GridViewMember
            var result = from M in dbcon.Members
                            select new { M.MemberFirstName, M.MemberLastName, M.MemberPhoneNumber, M.MemberDateJoined };
            GridViewMember.DataSource = result;
            GridViewMember.DataBind();
        }

        protected void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            try {
                using (var dbcon = new KarateSchoolDataContext(conn))
                {
                    // Collect the records to delete
                    var instructorRecord = dbcon.Instructors.SingleOrDefault(x => x.InstructorID == Convert.ToInt32(lblInstructorUserID.Text));
                    var userRecord = dbcon.NetUsers.SingleOrDefault(x => x.UserID == Convert.ToInt32(lblInstructorUserID.Text));
                    var sectionRecord = dbcon.Sections.SingleOrDefault(x => x.Instructor_ID == Convert.ToInt32(lblInstructorUserID.Text));

                    if (sectionRecord != null)
                    {
                        // Delete the Section record
                        dbcon.Sections.DeleteOnSubmit(sectionRecord);
                        dbcon.SubmitChanges();
                    }
                    else
                    {
                        lblInstructorDeleteError.Text = "No Section record found, Attempting to delete";
                    }
                    dbcon.Connection.Close();

                    if (instructorRecord != null)
                    {
                        // Delete the Instructor Record
                        dbcon.Instructors.DeleteOnSubmit(instructorRecord);
                        dbcon.SubmitChanges();
                    }
                    else
                    {
                        lblInstructorDeleteError.Text = "There was an error while atampting to delete the Instructor Record";
                    }

                    if (userRecord != null)
                    {
                        // Delete the NetUser Record
                        dbcon.NetUsers.DeleteOnSubmit(userRecord);
                        dbcon.SubmitChanges();
                    }
                    else
                    {
                        lblInstructorDeleteError.Text = "There was an error while atampting to delete the NetUser Record";
                    }

                    // Show confirmation
                    lblInstructorDeleteConfirmation.Text = "Delete succsessful!";

                    // Clear labels
                    lblSelectedInstructorFName.Text = string.Empty;
                    lblSelectedInstructorLName.Text = string.Empty;
                    lblInstructorUserID.Text = string.Empty;
                    lblInstructorSectionID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblInstructorDeleteError.Text = ex.Message;
            }

            //Refresh GridViewInstructor
            var result = from I in dbcon.Instructors
                             select new { I.InstructorFirstName, I.InstructorLastName };
                GridViewInstructor.DataSource = result;
                GridViewInstructor.DataBind();
        }

        protected void GridViewMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show Selected Item
            string deleteFName = GridViewMember.SelectedDataKey[0].ToString();
            lblSelectedMemberFName.Text = deleteFName.ToString();
            lblSelectedMemberFName1.Text = deleteFName.ToString();

            string deleteLName = GridViewMember.SelectedDataKey[1].ToString();
            lblSelectedMemberLName.Text = deleteLName.ToString();
            lblSelectedMemberLName1.Text = deleteLName.ToString();

            // Collect user ID
            var result = from M in dbcon.Members
                         where M.MemberFirstName == lblSelectedMemberFName1.Text
                         select M.Member_UserID;

            lblMemberUserID.Text = result.First().ToString();

            try
            {
                // Collect Section ID
                var sectionID = from S in dbcon.Sections
                                where S.Member_ID == Convert.ToInt32(lblMemberUserID.Text)
                                select S.SectionID;

                lblMemberSectionID.Text = sectionID.First().ToString();
            }
            catch
            {
                lblMemberSectionID.Text = "no SectionID";
            }

            // Clear Label
            lblMemberAssignError.Text = string.Empty;
            lblMemberDeleteError.Text = string.Empty;
            lblMemberAddError.Text = string.Empty;
            lblIMemberDeleteConfirmation.Text = string.Empty;
        }

        protected void GridViewInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Show Selected Item
            string deleteFName = GridViewInstructor.SelectedDataKey[0].ToString();
            lblSelectedInstructorFName.Text = deleteFName.ToString();

            string deleteLName = GridViewInstructor.SelectedDataKey[1].ToString();
            lblSelectedInstructorLName.Text = deleteLName.ToString();

            // Collect user ID
            var result = from I in dbcon.Instructors
                         where I.InstructorFirstName == lblSelectedInstructorFName.Text
                         select I.InstructorID;

            lblInstructorUserID.Text = result.First().ToString();

            try { 
                // Collect Section ID
                var sectionID = from S in dbcon.Sections
                                where S.Instructor_ID == Convert.ToInt32(lblInstructorUserID.Text)
                                select S.SectionID;

                lblInstructorSectionID.Text = sectionID.First().ToString();
            }
            catch 
            {
                lblInstructorSectionID.Text = "no SectionID";
            }

            // Clear Label
            lblInstructorDeleteError.Text = string.Empty;
            lblInstructorAddError.Text = string.Empty;
            lblInstructorDeleteConfirmation.Text = string.Empty;
        }

        protected void btnAssignMember_Click(object sender, EventArgs e)
        {
            try
            {
                dbcon = new KarateSchoolDataContext(conn);

                // New row
                Assignment4.Section newSection = new Assignment4.Section();

                // Add data to newSection
                newSection.Member_ID = Convert.ToInt32(lblMemberUserID.Text);
                newSection.SectionName = drpSectionAssign.SelectedItem.Text;
                newSection.SectionStartDate = Convert.ToDateTime(drpTimeAssign.SelectedItem.Text);

                // Get instructor ID
                var InstructorID = from I in dbcon.Instructors
                                   where I.InstructorFirstName == drpInstructorAssign.SelectedItem.Text
                                   select I.InstructorID;

                newSection.Instructor_ID = Convert.ToInt32(InstructorID.First());
                if(drpSectionAssign.SelectedItem.Text == "Karate Age-Uke")
                {
                    newSection.SectionFee = 500.0000M;
                }
                else if(drpSectionAssign.SelectedItem.Text == "Karate Chudan-Uke ")
                {
                    newSection.SectionFee = 600.0000M;
                }

                // Add row to table
                dbcon.Sections.InsertOnSubmit(newSection);
                dbcon.SubmitChanges();

                try
                {
                    // Set Section ID
                    var sectionID = from S in dbcon.Sections
                                    where S.Member_ID == Convert.ToInt32(lblMemberUserID.Text)
                                    select S.SectionID;

                    lblMemberSectionID.Text = sectionID.First().ToString();
                }
                catch
                {
                    lblMemberSectionID.Text = "no SectionID";
                }

                lblMemberAssignError.Text = "Member successfully assigned!";
            }
            catch (Exception ex)
            {
                lblMemberAssignError.Text = ex.Message;
            }
        }
    }
}