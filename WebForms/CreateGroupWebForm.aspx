<%@ Page Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="CreateGroupWebForm.aspx.cs" Inherits="UsersWebAPI.WebForms.CreateGroupWebForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

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
</asp:Content>