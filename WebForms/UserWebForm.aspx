<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWebForm.aspx.cs" Inherits="UsersWebAPI.UserWebForm" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <div>
        </div>
        <asp:Button ID="btnGroups" runat="server" OnClick="btnGroups_Click" Text="Groups" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUsers" TypeName="UsersWebAPI.UserRepository"></asp:ObjectDataSource>
    </form>
</body>
</html>
