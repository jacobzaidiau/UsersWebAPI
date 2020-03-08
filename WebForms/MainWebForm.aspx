<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="~/WebForms/MainWebForm.aspx.cs" Inherits="UsersWebAPI.WebForm1" %>



<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2"><asp:Label ID="lblMain" runat="server" Text="Click on one of the below buttons to manage your information." CssClass="footerTableHeaderText" ForeColor="#1E384B"></asp:Label>
</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server" HorizontalAlign="Center">
            <asp:TableCell runat="server">
                <asp:Button ID="btnUsers" runat="server" Text="Users" OnClick="btnUsers_Click" CssClass="btnSubmit" /></asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button ID="btnGroups" runat="server" Text="Groups" OnClick="btnGroups_Click" CssClass="btnSubmit" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />
</asp:Content>
