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
        .auto-style7 {
            font-size: xx-large;
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
        <span class="auto-style7">Welcome </span>
        <asp:Label ID="lblName" runat="server" CssClass="auto-style7" Text="Label"></asp:Label>
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
    <asp:GridView ID="GridViewMember" runat="server" Height="135px" Width="214px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                    <asp:TextBox ID="txtFirstNameMember" runat="server" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstNameMember" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    Last Name:&nbsp;
                    <asp:TextBox ID="txtLastNameMember" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastNameMember" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    Date Joined:&nbsp;
                    <asp:TextBox ID="txtDateJoined" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateJoined" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    Phone Number:&nbsp;
                    <asp:TextBox ID="txtPhoneNumberMember" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhoneNumberMember" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    Email:&nbsp;
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button ID="btnMemberAdd" runat="server" Text="Add New Member" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9"><span class="auto-style8">Delete a Member</span><br />
                    <br />
                    Currently Selected:
                    <asp:Label ID="lblSelectedMember" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnDeleteMember" runat="server" Text="Delete" />
                </td>
                <td class="auto-style10"><span class="auto-style8">Assign a Member to a Section</span><br />
                    <br />
                    Currently Selected:
                    <asp:Label ID="lblSelectedMember1" runat="server" Text="Label"></asp:Label>
                    <br />
                    Select a Section for them to join:
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
    <p class="auto-style8">
        Instructors of the School</p>
    <asp:GridView ID="GridViewInstructor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFirstNameInstructor" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    Last Name:&nbsp;
                    <asp:TextBox ID="txtLastNameInstructor" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLastNameInstructor" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    Phone Number:&nbsp;
                    <asp:TextBox ID="txtPhoneNumberInstructor" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhoneNumberInstructor" ErrorMessage="Field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button ID="btnInstructorAdd" runat="server" Text="Add New Instructor" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><span class="auto-style8">Delete an Instructor</span><br />
                    <br />
                    Currently Selected: <asp:Label ID="lblDeleteInstructor" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnDeleteInstructor" runat="server" Text="Delete" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
