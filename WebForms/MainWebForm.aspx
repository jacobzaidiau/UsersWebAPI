<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainWebForm.aspx.cs" Inherits="UsersWebAPI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="btnUsers" runat="server" Text="Users" OnClick="btnUsers_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGroups" runat="server" Text="Groups" OnClick="btnGroups_Click" />
    </form>
</body>
</html>
