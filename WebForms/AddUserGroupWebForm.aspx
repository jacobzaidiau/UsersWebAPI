<%@ Page Language="C#" MasterPageFile="~/WebForms/Site.Master" AutoEventWireup="true" CodeBehind="AddUserGroupWebForm.aspx.cs" Inherits="UsersWebAPI.AddUserGroupWebForm" EnableEventValidation="false" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="#FAFAFA" />
            <Columns>
                <asp:BoundField DataField="GroupId" HeaderText="GroupId" SortExpression="GroupId"
                    ItemStyle-CssClass="hidden"
                    HeaderStyle-CssClass="hidden"></asp:BoundField>
                <asp:BoundField DataField="GroupName" HeaderText="Name" SortExpression="GroupName" />
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
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" CssClass="btnSubmit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Text="Back" CssClass="btnBack" />
        </asp:Panel>
        <br />

    </div>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGroups" TypeName="UsersWebAPI.GroupRepository" EnablePaging="True" SelectCountMethod="GetGroupsTotalCount">
        <SelectParameters>
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
