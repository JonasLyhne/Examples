<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMenu1.aspx.cs" Inherits="TexasBurger.Web.test.WebFormMenu1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br>
            <br>

            <div id="carouselExampleIndicators" class="carousel slide" data-interval="false">

                <div class="carousel-inner">

                    <div class="carousel-item active">

                        <!-- /ressources/sesame-bun.png?auto=no&text=First Slide -->
                        <img class="d-block w-100" src="../burger-builder/../ressources/burger-builder/sesame-bun-v2.png?auto=no" alt="First slide">
                        <h3>Sesame Seed Bun</h3>
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="../burger-builder/../ressources/burger-builder/kaiser-bun-v2.png?auto=no&text=Second Slide"
                             alt="Second slide">
                        <h3>Kaiser Bun</h3>
                    </div>
                    <div class="carousel-item">
                        <asp:ImageButton runat="server" ID="BriocheBunButton" CssClass="d-block w-100" ImageUrl="~/ressources/burger-builder/brioche-bun-v2.png" Source="../burger-builder/../ressources/burger-builder/brioche-bun-v2.png?auto=no&text=Third Slide" OnClick="BriocheBunButton_Click"/>
                        <%--<img class="d-block w-100" src="../burger-builder/../ressources/burger-builder/brioche-bun-v2.png?auto=no&text=Third Slide"
                             alt="Third slide">--%>
                        <h3>Brioche Bun</h3>
                        <p>&nbsp;</p>
                    </div>
                </div>

                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>

                <!-- Name of currently selected bun ..-->



            </div>

            <br>
            <br>

        </div>
    </form>
</body>
</html>
