<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateGroupWebForm.aspx.cs" Inherits="UsersWebAPI.WebForms.CreateGroupWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
        </div>
    </form>
</body>
</html>
