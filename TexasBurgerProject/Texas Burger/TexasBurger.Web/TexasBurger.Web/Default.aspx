<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TexasBurger.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, inittial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap core CSS -->
    <link href="CSS/Bootstrap/bootstrap.min.css" rel="stylesheet" />


    <title>Texas Burger</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container align-content-center">
            <header class="jumbotron my-4">
                <h1 class="display-3 text-sm-center">Welcome To Texas Burger</h1>
                <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control text-center" placeholder="Please enter your name."></asp:TextBox>
                <p>&nbsp</p>
                <asp:TextBox ID="tableTextBox" runat="server" CssClass="form-control text-center" placeholder="Please enter table number."></asp:TextBox>
                <p>&nbsp</p>
                <div class="text-center">
                    <asp:Button ID="doneButton" runat="server" Text="Done" CssClass="btn btn-lg btn-primary" OnClick="doneButton_Click"></asp:Button>
                </div>
                <p>&nbsp</p>
                <div class="text-center">
                    <asp:Label ID="nameValidationLabel" runat="server" Text="" Visible="false" CssClass="bg-danger"></asp:Label>
                    <asp:Label ID="tableValidationLabel" runat="server" Text="" Visible="false" CssClass="bg-danger"></asp:Label>
                </div>
            </header>
        </div>
    </form>
</body>
</html>
