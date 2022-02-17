<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TexasBurger.Web.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <title>Texas Burger</title>

    <link href="CSS/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="home/css/heroic-features.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <div class="container">
        <a class="navbar-brand" href="#">Texas Burger</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
          <ul class="navbar-nav ml-auto">
            <li class="nav-item active">
              <a class="nav-link" href="home.html">Home
                <span class="sr-only">(current)</span>
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../about/about.html">About</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../gallery/gallery.html">Gallery</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="../contact/contact.html">Contact</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
        <!-- Page Content -->
    <div class="container">

      <!-- Jumbotron Header -->
      <header class="jumbotron my-4">
        <h1 class="display-3">Welcome</h1>
        <p class="lead">Welcome to the best burger brand in the World, in our burger joints you can enjoyr our handcrafted masterpieces or you can...</p>
          <asp:Button ID="buildBurgerButton" Text="Build your own!" runat="server" CssClass="btn btn-lg btn-primary" OnClick="buildBurgerButton_Click"/>
        <%--<a href="#" class="btn btn-primary btn-lg">Build your own!</a>--%>
      </header>

      <!-- Page Features -->
      <div class="row text-center">

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="../ressources/home/heroic1.jpg" alt="" width="253" height="164"/>
            <div class="card-body">
              <h4 class="card-title">Chicken Royale</h4>
              <p class="card-text">Crunchy fried chicken combined with the best garlic mayo in the world.</p>
            </div>
            <div class="card-footer">
              <a href="#" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="../ressources/home/heroic2.jpg" alt=""  width="253" height="164"/>
            <div class="card-body">
              <h4 class="card-title">Big Beefy</h4>
              <p class="card-text">Our Big Beefy contains a beef patty of a 100% beef mince, two slices of cheddar, chopped onions, pickles mustard and ketchup, served with a bun of sesame.</p>
            </div>
            <div class="card-footer">
              <a href="#" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="../ressources/home/heroic3.jpg" alt=""  width="253" height="164"/>
            <div class="card-body">
              <h4 class="card-title">Big Juicy</h4>
              <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente esse necessitatibus neque.</p>
            </div>
            <div class="card-footer">
              <a href="#" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-md-6 mb-4">
          <div class="card">
            <img class="card-img-top" src="../ressources/home/heroic4.png" alt=""  width="253" height="164"/>
            <div class="card-body">
              <h4 class="card-title">Bacon Deluxe</h4>
              <p class="card-text">Our Bacon Deluxe is stuffed with beef mince and its best friend bacon, a slice of cheddar fresh lettuce, and the best mayo in the world.</p>
            </div>
            <div class="card-footer">
              <a href="#" class="btn btn-primary">Find Out More!</a>
            </div>
          </div>
        </div>

      </div>
      <!-- /.row -->

    </div>
    <!-- /.container -->

    <!-- Footer -->
    <footer class="py-5 bg-dark">
      <div class="container">
        <p class="m-0 text-center text-white">Copyright &copy; Your Website 2018</p>
      </div>
      <!-- /.container -->
    </footer>

    <!-- Bootstrap core JavaScript -->
    <script src="../Vendor/jquery/jquery.min.js"></script>
    <script src="../Vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
