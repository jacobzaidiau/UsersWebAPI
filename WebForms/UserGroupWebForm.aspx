﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGroupWebForm.aspx.cs" Inherits="UsersWebAPI.UserGroupWebForm" EnableEventValidation="false" %>

<!DOCTYPE html>
<link rel="stylesheet" runat="server" type="text/css" href="stylesheet.css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#F0F1F1" Font-Bold="True" ForeColor="#6F6F6F" />
            <HeaderStyle BackColor="#F0F1F1" Font-Bold="True" ForeColor="#6F6F6F" CssClass="uppercase" />
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
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" CssClass="btnSubmit" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="btnBack" />
    </form>
</body>
</html>
