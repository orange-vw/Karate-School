<%@ Page Title="" Language="C#" MasterPageFile="~/websites/Site1.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment4.websites.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            font-size: x-large;
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
    <p class="auto-style3">
        Current Sections&nbsp;
        <asp:Label ID="lblNoCurrentSections" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
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
    </asp:Content>
