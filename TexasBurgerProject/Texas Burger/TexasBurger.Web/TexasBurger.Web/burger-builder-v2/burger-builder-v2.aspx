<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="burger-builder-v2.aspx.cs" Inherits="TexasBurger.Web.burger_builder_v2.burger_builder_v2" %>

<%@ Register assembly="Microsoft.AspNet.EntityDataSource" namespace="Microsoft.AspNet.EntityDataSource" tagprefix="ef" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Select bun"></asp:Label>
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Sesame Seed Bun</asp:ListItem>
            <asp:ListItem>Kaiser Bun</asp:ListItem>
            <asp:ListItem>Brioche Bun</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="test"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="guid" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="guid" HeaderText="guid" ReadOnly="True" SortExpression="guid" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BurgerDBConnectionString %>" SelectCommand="SELECT * FROM [Burger]"></asp:SqlDataSource>
    </form>
</body>
</html>
