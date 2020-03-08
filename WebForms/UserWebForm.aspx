<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWebForm.aspx.cs" Inherits="UsersWebAPI.UserWebForm" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblFirstname" runat="server" Text="First Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblLastname" runat="server" Text="Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMobile" runat="server" Text="Mobile:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
            OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" PageSize="5" DataSourceID="ObjectDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Salt" HeaderText="Salt" SortExpression="Salt" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetUsersWhere" 
            TypeName="UsersWebAPI.UserRepository"
            EnablePaging="True"
            SelectCountMethod="GetTotalCount">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtFirstname" ConvertEmptyStringToNull="False" DefaultValue="" Name="firstname" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtLastname" ConvertEmptyStringToNull="False" DefaultValue="" Name="lastname" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtDateOfBirth" ConvertEmptyStringToNull="False" DefaultValue="" Name="dateOfBirth" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtEmail" ConvertEmptyStringToNull="False" DefaultValue="" Name="email" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtPhone" ConvertEmptyStringToNull="False" DefaultValue="" Name="phone" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtMobile" ConvertEmptyStringToNull="False" DefaultValue="" Name="mobile" PropertyName="Text" Type="String" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
