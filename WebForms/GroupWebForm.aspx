<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupWebForm.aspx.cs" Inherits="UsersWebAPI.WebForms.GroupWebForm" EnableEventValidation="false" %>

<!DOCTYPE html>
<link rel="stylesheet" runat="server" type="text/css" href="stylesheet.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700">
    <form id="form1" runat="server">
        <div style="font-weight: 700">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="#FAFAFA" />
                <Columns>
                    <asp:BoundField DataField="GroupId" HeaderText="GroupId" SortExpression="GroupId" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-CssClass="hidden"
                        HeaderStyle-CssClass="hidden">
<HeaderStyle HorizontalAlign="Left" CssClass="hidden"></HeaderStyle>

<ItemStyle CssClass="hidden"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="GroupName" HeaderText="Name" SortExpression="GroupName" HeaderStyle-HorizontalAlign="Left">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" HeaderStyle-HorizontalAlign="Left">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" Font-Bold="False" />
                <FooterStyle BackColor="#F0F1F1" Font-Bold="True" ForeColor="#6F6F6F" />
                <HeaderStyle BackColor="#F0F1F1" Font-Bold="True" ForeColor="#6F6F6F" CssClass="uppercase" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#FAFAFA" Font-Bold="false"/>
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="btnBack" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGroups" TypeName="UsersWebAPI.UserRepository"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
