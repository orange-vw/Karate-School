<%@ Page Title="" Language="C#" MasterPageFile="~/websites/Site1.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="Assignment4.websites.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-size: xx-large;
        }
        .auto-style4 {
            width: 597px;
        }
        .auto-style5 {
            width: 597px;
            height: 249px;
        }
        .auto-style6 {
            height: 249px;
        }
        .auto-style8 {
            font-size: x-large;
        }
        .auto-style9 {
            width: 597px;
            height: 81px;
        }
        .auto-style10 {
            height: 81px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <span class="auto-style2">Weclome </span>
        <asp:Label ID="lblName" runat="server" CssClass="auto-style2" Text="Label"></asp:Label>
        <br />
        User Name:
        <asp:LoginName ID="LoginName1" runat="server" />
    &nbsp;<asp:LoginStatus ID="LoginStatus1" runat="server" />
    </p>
    <p>
        <br />
        </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style5">
                    <p class="auto-style8">
                        Members of the School</p>
    <asp:GridView ID="GridViewMember" runat="server" Height="135px" Width="214px" CellPadding="4" DataKeyNames="MemberFirstName,MemberLastName" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewMember_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
                    <br />
                </td>
                <td class="auto-style6"><span class="auto-style8">Add Member to the School</span><br />
                    <br />
                    First Name:&nbsp;
                    <asp:TextBox ID="txtFirstNameMember" runat="server" CausesValidation="True" EnableViewState="False"></asp:TextBox>
                    <br />
                    Last Name:&nbsp;
                    <asp:TextBox ID="txtLastNameMember" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMemberAddErrorBlank" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    Date Joined:&nbsp;
                    <asp:TextBox ID="txtDateJoined" runat="server" TextMode="Date"></asp:TextBox>
                    <br />
                    Phone Number:&nbsp;
                    <asp:TextBox ID="txtPhoneNumberMember" runat="server" TextMode="Phone"></asp:TextBox>
                    <br />
                    Email:&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnMemberAdd" runat="server" Text="Add New Member" OnClick="btnMemberAdd_Click" style="height: 26px" />
                &nbsp;&nbsp;
                    <asp:Label ID="lblMemberAddError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style9"><span class="auto-style8">Delete a Member</span><br />
                    <br />
                    Currently Selected:
                    <asp:Label ID="lblSelectedMemberFName" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblSelectedMemberLName" runat="server"></asp:Label>
                    &nbsp;<br />
                    User ID:
                    <asp:Label ID="lblMemberUserID" runat="server"></asp:Label>
                    &nbsp;Section ID:
                    <asp:Label ID="lblMemberSectionID" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnDeleteMember" runat="server" Text="Delete Member" OnClick="btnDeleteMember_Click" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMemberDeleteError" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;<asp:Label ID="lblIMemberDeleteConfirmation" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style10"><span class="auto-style8">Assign a Member to a Section</span><br />
                    <br />
                    Currently Selected:
                    <asp:Label ID="lblSelectedMemberFName1" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblSelectedMemberLName1" runat="server"></asp:Label>
                    <br />
                    Select a Section for them to join:&nbsp;&nbsp;
                    <asp:DropDownList ID="drpSectionAssign" runat="server">
                    </asp:DropDownList>
                    <br />
                    Select a Time&nbsp; for them to join:&nbsp;&nbsp;
                    <asp:DropDownList ID="drpTimeAssign" runat="server">
                    </asp:DropDownList>
                    <br />
                    Select an Instructor for them to join:&nbsp;&nbsp;
                    <asp:DropDownList ID="drpInstructorAssign" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="btnAssignMember" runat="server" Text="Assign Member" OnClick="btnAssignMember_Click" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMemberAssignError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
    <p class="auto-style8">
        Instructors of the School</p>
    <asp:GridView ID="GridViewInstructor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="InstructorFirstName,InstructorLastName" OnSelectedIndexChanged="GridViewInstructor_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <p>
        &nbsp;</p>
                </td>
                <td><span class="auto-style8">Add Instructor to the School</span><br />
                    <br />
                    First Name:&nbsp;
                    <asp:TextBox ID="txtFirstNameInstructor" runat="server"></asp:TextBox>
                    <br />
                    Last Name:&nbsp;
                    <asp:TextBox ID="txtLastNameInstructor" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblInstructorAddErrorBlank" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    Phone Number:&nbsp;
                    <asp:TextBox ID="txtPhoneNumberInstructor" runat="server" TextMode="Phone"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnInstructorAdd" runat="server" Text="Add New Instructor" OnClick="btnInstructorAdd_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblInstructorAddError" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><span class="auto-style8">Delete an Instructor</span><br />
                    <br />
                    Currently Selected: <asp:Label ID="lblSelectedInstructorFName" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblSelectedInstructorLName" runat="server"></asp:Label>
                    <br />
                    User ID:
                    <asp:Label ID="lblInstructorUserID" runat="server"></asp:Label>
&nbsp;
                    Section ID:
                    <asp:Label ID="lblInstructorSectionID" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="btnDeleteInstructor" runat="server" Text="Delete Instructor" OnClick="btnDeleteInstructor_Click" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblInstructorDeleteError" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;<asp:Label ID="lblInstructorDeleteConfirmation" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
