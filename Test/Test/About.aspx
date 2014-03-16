<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Test.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 189px;
            height: 24px;
        }
        .style2
        {
            height: 24px;
        }
        .style3
        {
            width: 189px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        
    <table width = "100%" cellpadding = "0" runat ="server" style="height: 62px">
    <tr>
    <td class="style1">
        No Of documents Read:
    </td>
    <td class="style2">
        <asp:label ID ="ID" Text="" Width= "62px" runat = "Server"></asp:label>
    </td>
    </tr>
    <tr>
    <td class="style3">Rows Created for Developers :</td>
    <td>
    <asp:label ID = "TextBox" AutoPostBack = "True" Text="" Width= "62px" 
            runat = "Server" ></asp:label>
       </td>
    </tr>
    <tr>
    <td class="style3">Rows Created for Contribs :</td>
    <td>
    <asp:label ID = "TextBox1" AutoPostBack = "True" Text="" Width= "62px" 
            runat = "Server" ></asp:label>
       </td>
    </tr>
    <tr>
    <td class="style3">Rows Created for Awards :</td>
    <td>
    <asp:label ID = "TextBox2" AutoPostBack = "True" Text="" Width= "62px" 
            runat = "Server" ></asp:label>
       </td>
    </tr>
    </table>
 
</asp:Content>
