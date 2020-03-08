<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserGroupWebForm.aspx.cs" Inherits="UsersWebAPI.AddUserGroupWebForm" EnableEventValidation="false" %>

<!DOCTYPE html>
<link rel="stylesheet" runat="server" type="text/css" href="stylesheet.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="#FAFAFA" />
                <Columns>
                    <asp:BoundField DataField="GroupId" HeaderText="GroupId" SortExpression="GroupId" />
                    <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#F0F1F1" Font-Bold="True" ForeColor="#6F6F6F" />
                <HeaderStyle BackColor="#F0F1F1" Font-Bold="True" ForeColor="#6F6F6F" CssClass="uppercase" HorizontalAlign="Left" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#FAFAFA" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Text="Back" CssClass="btnBack" />
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGroups" TypeName="UsersWebAPI.UserRepository"></asp:ObjectDataSource>
    </form>
</body>
</html>
