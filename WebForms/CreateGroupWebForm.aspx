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

    </div>


    <asp:Panel runat="server" CssClass="row">
        <asp:Panel runat="server" CssClass="col-md-12" HorizontalAlign="Center">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btnSubmit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="btnBack" />
        </asp:Panel>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
