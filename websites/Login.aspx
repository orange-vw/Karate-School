<%@ Page Title="" Language="C#" MasterPageFile="~/websites/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment4.websites.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
        </asp:Login>
    </p>
    <p>
    </p>
</asp:Content>
