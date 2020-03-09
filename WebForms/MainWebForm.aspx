<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="~/WebForms/MainWebForm.aspx.cs" Inherits="UsersWebAPI.WebForm1" %>



<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Panel CssClass="row" runat="server">
        <asp:Panel CssClass="col-md-12" runat="server">
            <asp:Label runat="server" Text="Click on one of the below buttons to manage your information." CssClass="footerTableHeaderText" ForeColor="#1E384B"></asp:Label>
            <br />
            <br />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel runat="server" CssClass="row">
        <asp:Panel CssClass="col-md-12" runat="server" HorizontalAlign="Center">
            <asp:Button ID="btnUsers" runat="server" Text="Users" OnClick="btnUsers_Click" CssClass="btnSubmit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnGroups" runat="server" Text="Groups" OnClick="btnGroups_Click" CssClass="btnSubmit" />
        </asp:Panel>
    </asp:Panel>
    <br />
</asp:Content>
