<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BurgerBuilder.aspx.cs" Inherits="TexasBurger.Web.BurgerBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Responsive Burger Builder</title>
    <link href="CSS/Bootstrap/bootstrap.min.css" rel="stylesheet"/>
    <script type="text/javascript" src="Scripts/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="Scripts/Bootstrap/bootstrap.min.js"></script>

</head>
<body>

    <form id="form1" runat="server">
        <p>asp.net sutter</p>
        <div>
            <asp:Button runat="server" ID="previousPageViewButton" CssClass="btn btn-lg btn-primary float-left" Text="◀ Previous" OnClick="previousPageViewButton_Click" Visible="False"/>
            <asp:Button runat="server" ID="nextPageViewButton" CssClass="btn btn-lg btn-primary float-right" Text="Next ▶" OnClick="nextPageViewButton_Click" Visible="False"/>
        </div>
        <div>
            <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">

                <asp:View runat="server" ID="CreateBurgerView">
                    <div class="container align-content-center">
                        <header class="jumbotron my-4">
                            <h1 class="display-3 text-sm-center">Welcome To Texas Burger</h1>
                            <asp:TextBox ID="burgerNameTextBox" runat="server" CssClass="form-control text-center" placeholder="Please give your burger a name."></asp:TextBox>
                            <p>&nbsp</p>
                            <p>&nbsp</p>
                            <div class="text-center">
                                <asp:Button ID="nameBurgerButton" runat="server" Text="Done" CssClass="btn btn-lg btn-primary" OnClick="nameBurgerButton_Click"></asp:Button>
                            </div>
                            <p>&nbsp</p>
                            <div class="text-center">
                                <asp:Label ID="nameValidationLabel" runat="server" Text="" Visible="false" CssClass="bg-danger"></asp:Label>
                            </div>
                        </header>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="bunView">
                <br />
                <br />
                <div class="container">
                    <div >
                        
                        <h1 class="display-3 ml-auto mr-auto text-center d-inline-block">Select your bun!</h1>
                    </div>
                    <p>&nbsp</p>
                        <div>
                            <h3>Sesame Seed Bun:</h3>
                            
                            <asp:Label runat="server" ID="sesameBunPriceLable" Text=""/>
                            <p>&nbsp</p>
                            <asp:Button runat="server" ID="sesameBunButton" CssClass="btn btn-lg btn-primary" Text="Select" OnClick="sesameBunButton_Click"/>
                            
                        </div>
                        <div>
                            <h3>Kaiser Bun:</h3>
                            <asp:Label runat="server" ID="kaiserBunPriceLable" Text=""/>
                            <p>&nbsp</p>
                            <asp:Button runat="server" ID="kaiserBunButton" CssClass="btn btn-lg btn-primary" Text="Select" OnClick="kaiserBunButton_Click"/>
                        </div>
                        <div>
                            <h3>Brioche Bun:</h3>
                            <asp:Label runat="server" ID="briocheBunPriceLable" Text=""/> 
                            <p>&nbsp</p>
                            <asp:Button runat="server" ID="briocheBunButton" CssClass="btn btn-lg btn-primary" Text="Select" OnClick="briocheBunButton_Click"/>
                        </div>
                    </div>
                <br/>
                <br/>
                </asp:View>
                <asp:View runat="server" ID="meatView">
                    <div class="container">
                        <div class="row text-center text-lg-left">
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="meatPulledPorkButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/angry-beef.png" OnClick="meatPulledPorkButton_OnClick"/>
                                <asp:TextBox runat="server" ID="meatPulledPorkCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="meatBeefPattyButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/angry-beef.png" OnClick="meatBeefPattyButton_OnClick"/>
                                <asp:TextBox runat="server" ID="meatBeefPattyCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="meatTexasBeefButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/angry-beef.png" OnClick="meatTexasBeefButton_OnClick"/>
                                <asp:TextBox runat="server" ID="meatTexasBeefCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="meatTofuButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/angry-beef.png" OnClick="meatTofuButton_OnClick"/>
                                <asp:TextBox runat="server" ID="meatTofuCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="meatFriedChickenButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/angry-beef.png" OnClick="meatFriedChickenButton_OnClick"/>
                                <asp:TextBox runat="server" ID="meatFriedChickenCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <asp:Button runat="server" ID="meatAddButton" Text="Add" CssClass="btn btn-lg btn-primary" OnClick="meatAddButton_OnClick"/>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="cheeseView">
                    <div class="container">
                        <div class="row text-center text-lg-left">
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="cheeseMozarellaButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/cheese-emmental.png" OnClick="cheeseMozarellaButton_OnClick"/>
                                <asp:TextBox runat="server" ID="cheeseMozarellaCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="cheeseCheddarButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/cheese-emmental.png" OnClick="cheeseCheddarButton_OnClick"/>
                                <asp:TextBox runat="server" ID="cheeseCheddarCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="cheeseSwissButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/cheese-emmental.png" OnClick="cheeseSwissButton_OnClick"/>
                                <asp:TextBox runat="server" ID="cheeseSwissCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="cheeseBlueButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/cheese-emmental.png" OnClick="cheeseBlueButton_OnClick"/>
                                <asp:TextBox runat="server" ID="cheeseBlueCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="cheeseEmmentalerButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/cheese-emmental.png" OnClick="cheeseEmmentalerButton_OnClick"/>
                                <asp:TextBox runat="server" ID="cheeseEmmentalerCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="cheeseGhoudaButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/cheese-emmental.png" OnClick="cheeseGhoudaButton_OnClick"/>
                                <asp:TextBox runat="server" ID="cheeseGhoudaCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <asp:Button runat="server" ID="cheeseAddButton" Text="Add" CssClass="btn btn-lg btn-primary" OnClick="cheeseAddButton_OnClick"/>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="vegetableView">
                    <div class="container">
                        <div class="row text-center text-lg-left">
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="vegetableOnionButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="vegetableOnionButton_OnClick"/>
                                <asp:TextBox runat="server" ID="vegetableOnionCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="vegetableLettuceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="vegetableLettuceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="vegetableLettuceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="vegetableTomatoButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="vegetableTomatoButton_OnClick"/>
                                <asp:TextBox runat="server" ID="vegetableTomatoCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="vegetableCucumberButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="vegetableCucumberButton_OnClick"/>
                                <asp:TextBox runat="server" ID="vegetableCucumberCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <asp:Button runat="server" ID="vegetableAddButton" Text="Add" CssClass="btn btn-lg btn-primary" OnClick="vegetableAddButton_OnClick"/>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="saucesView">
                    <div class="container">
                        <div class="row text-center text-lg-left">
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="texasSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="texasSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="texasSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="aioliSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/aioli.png" OnClick="aioliSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="aioliSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="chiliSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/chili.png" OnClick="chiliSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="chiliSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="currySauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/curry.png" OnClick="currySauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="currySauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="greenPestoSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/green-pesto.png" OnClick="greenPestoSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="greenPestoSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="ketchupSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/ketchup.png" OnClick="ketchupSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="ketchupSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="mayonaiseSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/mayonaise.png" OnClick="mayonaiseSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="mayonaiseSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="sweetChiliSauceButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/sauce/sweet-chili.png" OnClick="sweetChiliSauceButton_OnClick"/>
                                <asp:TextBox runat="server" ID="sweetChiliSauceCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <asp:Button runat="server" ID="sauceAddButton" Text="Add" CssClass="btn btn-lg btn-primary" OnClick="sauceAddButton_OnClick"/>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="extrasView">
                    <div class="container">
                        <div class="row text-center text-lg-left">
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="extrasBaconButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="extrasBaconButton_OnClick"/>
                                <asp:TextBox runat="server" ID="extrasBaconCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-lg-3 col-md-4 col-xs-6">
                                <asp:ImageButton runat="server" ID="extrasFriedOnionButton" CssClass="img-fluid img-thumbnail" ImageUrl="ressources/burger-builder/placeholder205x205.png" OnClick="extrasFriedOnionButton_OnClick"/>
                                <asp:TextBox runat="server" ID="extrasFriedOnionCounter" type="number" CssClass="img-fluid" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <asp:Button runat="server" ID="extrasAddButton" Text="Add" CssClass="btn btn-lg btn-primary" OnClick="extrasAddButton_OnClick"/>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="finalBurgerView">
                    <div class="container align-content-center">
                        <header class="jumbotron my-4">
                            <h1 class="display-3 text-sm-center">Your burger!</h1>
                            <div>
                                
                                <asp:Label ID="burgerLabel" runat="server" Text="Label"></asp:Label>
                                
                                <asp:Button runat="server" Text="Order Burger" ID="doneButton" CssClass="btn btn-lg btn-primary float-right" Visible="False" OnClick="doneButton_OnClick"/>
                            </div>
                        </header>
                    </div>
                </asp:View>
            </asp:MultiView>
            <div>
                
            </div>
        </div>
    </form>
</body>
</html>
