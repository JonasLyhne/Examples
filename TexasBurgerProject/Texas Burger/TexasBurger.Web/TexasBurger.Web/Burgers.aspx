<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Burgers.aspx.cs" Inherits="TexasBurger.Web.Burgers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Texas Burger - Burgers</title>

   <!-- Bootstrap core CSS -->
  <link href="../Vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

  <!-- Custom styles for this template -->
  <link href="css/thumbnail-gallery.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
    <div class="container">
      <a class="navbar-brand" href="#">Texas Burger</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive"
        aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item">
            <a class="nav-link" href="../home/home.html">Home
              <span class="sr-only">(current)</span>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="../about/about.html">About</a>
          </li>
          <li class="nav-item">
            <a class="nav-link active" href="gallery.html">Gallery</a>
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

    <h1 class="my-4 text-center text-lg-left">Burger Gallery</h1>

    <div class="row text-center text-lg-left">

      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd1.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd2.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd3.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd4.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd5.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd6.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd7.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd8.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd9.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd10.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd11.jpg" alt=""/>
        </a>
      </div>
      <div class="col-lg-3 col-md-4 col-xs-6">
        <a href="#" class="d-block mb-4 h-100">
          <img class="img-fluid img-thumbnail" src="../ressources/gallery/mcd12.jpg" alt=""/>
        </a>
      </div>
    </div>

  </div>
  <!-- /.container -->

  <!-- Footer -->
  <footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">Copyright &copy; Your Website 2017</p>
    </div>
    <!-- /.container -->
  </footer>

  <!-- Bootstrap core JavaScript -->
  <script src="../Vendor/jquery/jquery.min.js"></script>
  <script src="../Vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
