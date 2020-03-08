<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateGroupWebForm.aspx.cs" Inherits="UsersWebAPI.WebForms.CreateGroupWebForm" %>

<!DOCTYPE html>
<link rel="stylesheet" runat="server" type="text/css" href="stylesheet.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblGroupName" runat="server" Text="Group Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="btnBack" />
        </div>
    </form>
</body>
</html>
