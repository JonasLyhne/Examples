using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TexasBurger.Domain;

namespace TexasBurger.Web.burger_builder_v2
{
    public partial class burger_builder_v2 : System.Web.UI.Page
    {
        private readonly HtmlGenericControl _meatContainer = new HtmlGenericControl("div") { ID = "meat-container" };
        private HtmlGenericControl _cheeseContainer = new HtmlGenericControl("div") {ID = "cheese-container"};
        private HtmlGenericControl _sauceContainer = new HtmlGenericControl("div") {ID = "sauce-container"};
        private HtmlGenericControl _extraContainer = new HtmlGenericControl("div") {ID = "extra-container"};

        protected void Page_Load(object sender, EventArgs e)
        {

            
            
            
            

            DropDownList1.Items.Clear(); // Bun
            

            this.form1.Controls.Add(_meatContainer);
            this.form1.Controls.Add(_cheeseContainer);
            this.form1.Controls.Add(_sauceContainer);
            this.form1.Controls.Add(_extraContainer);

            DropDownList meatList = new DropDownList();
            DropDownList cheeseList = new DropDownList();
            DropDownList sauceList = new DropDownList();
            DropDownList extraList = new DropDownList();

            Button _meatAddButton = new Button() {Text = "ADD MEAT"};
            Button _cheeseAddButton = new Button() {Text = "ADD CHEESE"};
            Button _sauceAddButton = new Button() {Text = "ADD SAUCE"};
            Button _extraAddButton = new Button() {Text = "ADD EXTRA"};

            _meatAddButton.Click += (o, args) =>
            {
                DropDownList dlTest = new DropDownList();
                _meatContainer.Controls.Add(dlTest);
                _meatContainer.Controls.Add(new TextBox(){Text="0"});

                
                

            };

            
            _cheeseAddButton.Click += (o, args) =>
            {
                _cheeseContainer.Controls.Add(cheeseList);
                _cheeseContainer.Controls.Add(new TextBox(){Text="0"});
            };
            _sauceAddButton.Click += (o, args) =>
            {
                _sauceContainer.Controls.Add(sauceList);
                _sauceContainer.Controls.Add(new TextBox(){Text="0"});
            };
            _extraAddButton.Click += (o, args) =>
            {
                _extraContainer.Controls.Add(extraList);
                _extraContainer.Controls.Add(new TextBox(){Text="0"});
            };

            _meatContainer.Controls.Add(new HtmlGenericControl("br"));
            _meatContainer.Controls.Add(new HtmlGenericControl("br"));
            _meatContainer.Controls.Add(new HtmlGenericControl("br"));
            _meatContainer.Controls.Add(new Label(){Text = "Meat     "});
            _meatContainer.Controls.Add(new Label(){Text = "Quantity"});
            _meatContainer.Controls.Add(_meatAddButton);
            _meatContainer.Controls.Add(new HtmlGenericControl("br"));
            _meatContainer.Controls.Add(meatList);
            _meatContainer.Controls.Add(new TextBox(){Text = "0"});
            _meatContainer.Controls.Add(new HtmlGenericControl("br"));
            _meatContainer.Controls.Add(new HtmlGenericControl("br"));
            _meatContainer.Controls.Add(new HtmlGenericControl("br"));

            _cheeseContainer.Controls.Add(new Label() { Text = "Cheese     " });
            _cheeseContainer.Controls.Add(new Label() { Text = "Quantity" });
            _cheeseContainer.Controls.Add(_cheeseAddButton);
            _cheeseContainer.Controls.Add(new HtmlGenericControl("br"));
            _cheeseContainer.Controls.Add(cheeseList);
            _cheeseContainer.Controls.Add(new TextBox(){Text = "0"});
            _cheeseContainer.Controls.Add(new HtmlGenericControl("br"));
            _cheeseContainer.Controls.Add(new HtmlGenericControl("br"));
            _cheeseContainer.Controls.Add(new HtmlGenericControl("br"));

            _sauceContainer.Controls.Add(new Label() { Text = "Sauce     " });
            _sauceContainer.Controls.Add(new Label() { Text = "Quantity" });
            _sauceContainer.Controls.Add(_sauceAddButton);
            _sauceContainer.Controls.Add(new HtmlGenericControl("br"));
            _sauceContainer.Controls.Add(sauceList);
            _sauceContainer.Controls.Add(new TextBox() { Text = "0" });
            _sauceContainer.Controls.Add(new HtmlGenericControl("br"));
            _sauceContainer.Controls.Add(new HtmlGenericControl("br"));
            _sauceContainer.Controls.Add(new HtmlGenericControl("br"));

            _extraContainer.Controls.Add(new Label() { Text = "Extras     " });
            _extraContainer.Controls.Add(new Label() { Text = "Quantity" });
            _extraContainer.Controls.Add(_extraAddButton);
            _extraContainer.Controls.Add(new HtmlGenericControl("br"));
            _extraContainer.Controls.Add(extraList);
            _extraContainer.Controls.Add(new TextBox() { Text = "0" });
            _extraContainer.Controls.Add(new HtmlGenericControl("br"));
            _extraContainer.Controls.Add(new HtmlGenericControl("br"));
            _extraContainer.Controls.Add(new HtmlGenericControl("br"));


            var ingredients = DomainManager.GetIngredients();
            var buns = ingredients.Where(ingredient => ingredient.BurgerIngredientTypeDTO.name == "Bun");
            var meats = ingredients.Where(ingredient => ingredient.BurgerIngredientTypeDTO.name == "Meat");
            var cheeses = ingredients.Where(ingredient => ingredient.BurgerIngredientTypeDTO.name == "Cheese");
            var sauces = ingredients.Where(ingredient => ingredient.BurgerIngredientTypeDTO.name == "Sauce");
            var extras = ingredients.Where(ingredient => ingredient.BurgerIngredientTypeDTO.name == "Extra");


            foreach (var bun in buns)
            {

                DropDownList1.Items.Add(bun.name);

            }

            foreach (var meat in meats)
            {
                meatList.Items.Add(meat.name);
            }

            foreach (var cheese in cheeses)
            {
                cheeseList.Items.Add(cheese.name);
            }

            foreach (var sauce in sauces)
            {
                sauceList.Items.Add(sauce.name);
            }

            foreach (var extra in extras)
            {
                extraList.Items.Add(extra.name);

            }




            




        }

        protected void BurgerBunDataSource_Selecting(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceSelectingEventArgs e)
        {

        }

        protected void EntityDataSource1_Selecting(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceSelectingEventArgs e)
        {

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            var dropdown = new DropDownList();
            var textbox = new TextBox();
            var meats = DomainManager.GetIngredients().Where(i => i.BurgerIngredientTypeDTO.name == "Meat");

            foreach (var meat in meats)
            {
                dropdown.Items.Add(meat.name);
            }

            dropdown.Visible = true;





            _meatContainer.Controls.Add(dropdown);
            _meatContainer.Controls.Add(textbox);
            

            //this.form1.Controls.Add(dropdown);
            //this.form1.Controls.Add(textbox);

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           // Label2.Text = DropDownList1.SelectedIndex;
        }
    }
}