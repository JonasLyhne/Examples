using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexasBurger.Domain;
using TexasBurger.DTO;

namespace TexasBurger.Web
{
    public partial class BurgerBuilder : System.Web.UI.Page
    {
        public DomainManager DomainManager = new DomainManager();
        private static BurgerDTO _burgerDto;
        private static readonly List<BurgerIngredientDTO> _burgerIngredients = DomainManager.GetIngredients();
        private static List<BurgerContentDTO> burgerContentsList;
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<BurgerIngredientDTO> burgerIngredients = DomainManager.GetIngredients();
            if (!IsPostBack) { 
                burgerContentsList = new List<BurgerContentDTO>();
                MultiView1.SetActiveView(CreateBurgerView);
            }
            if (_burgerIngredients != null)
            {
                sesameBunPriceLable.Text =
                    _burgerIngredients.FirstOrDefault(bi => bi.name == "Sesame Seed Bun")?.price.ToString("C");

                kaiserBunPriceLable.Text =
                    _burgerIngredients.FirstOrDefault(bi => bi.name == "Kaiser Bun")?.price.ToString("C");

                briocheBunPriceLable.Text =
                    _burgerIngredients.FirstOrDefault(bi => bi.name == "Brioche Bun")?.price.ToString("C");
            }
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                nextPageViewButton.Visible = false;
                previousPageViewButton.Visible = false;
            }
            else if (MultiView1.ActiveViewIndex == 7)
            {
                burgerLabel.Text = _burgerDto.name;
                foreach (BurgerContentDTO contentDto in burgerContentsList)
                {
                    burgerLabel.Text += contentDto.ToString();
                }
                //testGridView.DataSource = ToDataTable(burgerContentsList);
                nextPageViewButton.Visible = false;
                doneButton.Visible = true;
            }
            else
            {
                //burgerLabel.Text = "";
                nextPageViewButton.Visible = true;
                previousPageViewButton.Visible = true;
                doneButton.Visible = false;
            }
        }

        protected void sesameBunButton_Click(object sender, EventArgs e)
        {
            // TIlføj noget content.
            string name = "Sesame Seed Bun";
            BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
            burgerContent.burger_id = _burgerDto.guid;
            burgerContentsList.Add(burgerContent);
            //_burgerDto.BurgerContentDTO.Add(burgerContent);
            kaiserBunButton.Enabled = false;
            briocheBunButton.Enabled = false;
        }

        protected void kaiserBunButton_Click(object sender, EventArgs e)
        {
            string name = "Kaiser Bun";
            BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
            burgerContent.burger_id = _burgerDto.guid;
            burgerContentsList.Add(burgerContent);
            //_burgerDto.BurgerContentDTO.Add(burgerContent);
            sesameBunButton.Enabled = false;
            briocheBunButton.Enabled = false;

        }

        protected void briocheBunButton_Click(object sender, EventArgs e)
        {
            string name = "Brioche Bun";
            BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
            burgerContent.burger_id = _burgerDto.guid;
            burgerContentsList.Add(burgerContent);
            //_burgerDto.BurgerContentDTO.Add(burgerContent);
            sesameBunButton.Enabled = false;
            kaiserBunButton.Enabled = false;
        }

        protected void nameBurgerButton_Click(object sender, EventArgs e)
        {
            if (burgerNameTextBox.Text.Trim().Length == 0)
            {
                nameValidationLabel.Text = "Please enter a name for the burger.";
                nameValidationLabel.Visible = true;
                return;
            }
            else
            {
                _burgerDto = DomainManager.CreateBurger(burgerNameTextBox.Text);
                MultiView1.SetActiveView(bunView);
            }
        }

        protected void previousPageViewButton_Click(object sender, EventArgs e)
        {
            PreviousView();
        }

        protected void nextPageViewButton_Click(object sender, EventArgs e)
        {
            //MultiView1.SetActiveView(meatView);

            NextView();

        }

        private void NextView()
        {
            //foreach (Control control in MultiView1.Views[MultiView1.ActiveViewIndex].Controls)
            //{
            //    // Needs to be a TextBox
            //    if (control.GetType() == typeof(TextBox))
            //    {
            //        // ID Needs to contain counter.
            //        if (control.ID.Contains("counter".ToLower()))
            //        {

            //        }
            //    }
            //}

            int viewAmount = MultiView1.Views.Count;

            if (MultiView1.ActiveViewIndex >= viewAmount)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                MultiView1.ActiveViewIndex++;
            }
        }

        private void PreviousView()
        {
            int viewAmount = MultiView1.Views.Count;

            if (MultiView1.ActiveViewIndex <= 1)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                MultiView1.ActiveViewIndex--;
            }
        }

        protected void meatPulledPorkButton_OnClick(object sender, ImageClickEventArgs e)
        {
            //if (!meatPulledPorkCounter.Visible == true)
            //{
            //    meatPulledPorkCounter.Visible = true;
            //}

            meatPulledPorkCounter.Visible = !meatPulledPorkCounter.Visible;

            meatPulledPorkCounter.Text = DomainManager.IncrementCount(meatPulledPorkCounter.Text);

        }

        protected void meatBeefPattyButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!meatBeefPattyCounter.Visible == true)
            {
                meatBeefPattyCounter.Visible = true;
            }

            meatBeefPattyCounter.Text = DomainManager.IncrementCount(meatBeefPattyCounter.Text);


        }

        protected void meatTexasBeefButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!meatTexasBeefCounter.Visible == true)
            {
                meatTexasBeefCounter.Visible = true;
            }

            meatTexasBeefCounter.Text = DomainManager.IncrementCount(meatTexasBeefCounter.Text);
        }

        protected void meatTofuButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!meatTofuCounter.Visible == true)
            {
                meatTofuCounter.Visible = true;
            }
            meatTofuCounter.Text = DomainManager.IncrementCount(meatTofuCounter.Text);
        }

        protected void meatFriedChickenButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!meatFriedChickenCounter.Visible == true)
            {
                meatFriedChickenCounter.Visible = true;
            }

            meatFriedChickenCounter.Text = DomainManager.IncrementCount(meatFriedChickenCounter.Text);
        }

        protected void cheeseMozarellaButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!cheeseMozarellaCounter.Visible == true)
            {
                cheeseMozarellaCounter.Visible = true;
            }
            cheeseMozarellaCounter.Text = DomainManager.IncrementCount(cheeseMozarellaCounter.Text);
        }

        protected void cheeseCheddarButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!cheeseCheddarCounter.Visible == true)
            {
                cheeseCheddarCounter.Visible = true;
            }
            cheeseCheddarCounter.Text = DomainManager.IncrementCount(cheeseCheddarCounter.Text);
        }

        protected void cheeseSwissButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!cheeseSwissCounter.Visible == true)
            {
                cheeseSwissCounter.Visible = true;
            }
            cheeseSwissCounter.Text = DomainManager.IncrementCount(cheeseSwissCounter.Text);
        }

        protected void cheeseBlueButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!cheeseBlueCounter.Visible == true)
            {
                cheeseBlueCounter.Visible = true;
            }
            cheeseBlueCounter.Text = DomainManager.IncrementCount(cheeseBlueCounter.Text);
        }

        protected void cheeseEmmentalerButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!cheeseEmmentalerCounter.Visible == true)
            {
                cheeseEmmentalerCounter.Visible = true;
            }
            cheeseEmmentalerCounter.Text = DomainManager.IncrementCount(cheeseEmmentalerCounter.Text);
        }

        protected void cheeseGhoudaButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!cheeseGhoudaCounter.Visible == true)
            {
                cheeseGhoudaCounter.Visible = true;
            }
            cheeseGhoudaCounter.Text = DomainManager.IncrementCount(cheeseGhoudaCounter.Text);
        }

        protected void vegetableOnionButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!vegetableOnionCounter.Visible == true)
            {
                vegetableOnionCounter.Visible = true;
            }
            vegetableOnionCounter.Text = DomainManager.IncrementCount(vegetableOnionCounter.Text);
        }

        protected void vegetableLettuceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!vegetableLettuceCounter.Visible == true)
            {
                vegetableLettuceCounter.Visible = true;
            }
            vegetableLettuceCounter.Text = DomainManager.IncrementCount(vegetableLettuceCounter.Text);
        }

        protected void vegetableTomatoButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!vegetableTomatoCounter.Visible == true)
            {
                vegetableTomatoCounter.Visible = true;
            }
            vegetableTomatoCounter.Text = DomainManager.IncrementCount(vegetableTomatoCounter.Text);
        }

        protected void vegetableCucumberButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!vegetableCucumberCounter.Visible == true)
            {
                vegetableCucumberCounter.Visible = true;
            }
            vegetableCucumberCounter.Text = DomainManager.IncrementCount(vegetableCucumberCounter.Text);
        }

        protected void texasSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!texasSauceCounter.Visible == true)
            {
                texasSauceCounter.Visible = true;
            }
            texasSauceCounter.Text = DomainManager.IncrementCount(texasSauceCounter.Text);
        }

        protected void aioliSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!aioliSauceCounter.Visible == true)
            {
                aioliSauceCounter.Visible = true;
            }
            aioliSauceCounter.Text = DomainManager.IncrementCount(aioliSauceCounter.Text);
        }

        protected void chiliSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!chiliSauceCounter.Visible == true)
            {
                chiliSauceCounter.Visible = true;
            }
            chiliSauceCounter.Text = DomainManager.IncrementCount(chiliSauceCounter.Text);
        }

        protected void currySauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!currySauceCounter.Visible == true)
            {
                currySauceCounter.Visible = true;
            }
            currySauceCounter.Text = DomainManager.IncrementCount(currySauceCounter.Text);
        }

        protected void greenPestoSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!greenPestoSauceCounter.Visible == true)
            {
                greenPestoSauceCounter.Visible = true;
            }
            greenPestoSauceCounter.Text = DomainManager.IncrementCount(greenPestoSauceCounter.Text);
        }

        protected void ketchupSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!ketchupSauceCounter.Visible == true)
            {
                ketchupSauceCounter.Visible = true;
            }
            ketchupSauceCounter.Text = DomainManager.IncrementCount(ketchupSauceCounter.Text);
        }

        protected void mayonaiseSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!mayonaiseSauceCounter.Visible == true)
            {
                mayonaiseSauceCounter.Visible = true;
            }
            mayonaiseSauceCounter.Text = DomainManager.IncrementCount(mayonaiseSauceCounter.Text);
        }

        protected void sweetChiliSauceButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!sweetChiliSauceCounter.Visible == true)
            {
                sweetChiliSauceCounter.Visible = true;
            }
            sweetChiliSauceCounter.Text = DomainManager.IncrementCount(sweetChiliSauceCounter.Text);
        }

        protected void extrasBaconButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!extrasBaconCounter.Visible == true)
            {
                extrasBaconCounter.Visible = true;
            }
            extrasBaconCounter.Text = DomainManager.IncrementCount(extrasBaconCounter.Text);
        }

        protected void extrasFriedOnionButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (!extrasFriedOnionCounter.Visible == true)
            {
                extrasFriedOnionCounter.Visible = true;
            }
            extrasFriedOnionCounter.Text = DomainManager.IncrementCount(extrasFriedOnionCounter.Text);
        }

        protected void doneButton_OnClick(object sender, EventArgs e)
        {
            _burgerDto.BurgerContentDTO = burgerContentsList;
            DomainManager.SaveBurger(_burgerDto);
            DomainManager.StartOrder();
        }

        protected void meatAddButton_OnClick(object sender, EventArgs e)
        {
            int.TryParse(meatTexasBeefCounter.Text, out int texasBeefCount);
            int.TryParse(meatBeefPattyCounter.Text, out int beefPattyCount);
            int.TryParse(meatFriedChickenCounter.Text, out int friedChickenCount);
            int.TryParse(meatPulledPorkCounter.Text, out int pulledporkCount );
            int.TryParse(meatTofuCounter.Text, out int tofuCount);

            if (texasBeefCount != 0)
            {
                for (int i = 0; i < texasBeefCount; i++)
                {
                    string name = "Texas Beef";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (beefPattyCount != 0)
            {
                for (int i = 0; i < beefPattyCount; i++)
                {
                    string name = "Beef Patty";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (friedChickenCount != 0)
            {
                for (int i = 0; i < friedChickenCount; i++)
                {
                    string name = "Fried Chicken";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if ( pulledporkCount != 0)
            {
                for (int i = 0; i < pulledporkCount; i++)
                {
                    string name = "Pulled Pork";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (tofuCount != 0)
            {
                for (int i = 0; i < tofuCount; i++)
                {
                    string name = "Tofu Patty";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }

        }

        protected void cheeseAddButton_OnClick(object sender, EventArgs e)
        {
            int.TryParse(cheeseMozarellaCounter.Text, out int mozarellaCount );
            int.TryParse(cheeseCheddarCounter.Text, out int cheddarCount );
            int.TryParse(cheeseSwissCounter.Text, out int swissCount);
            int.TryParse(cheeseBlueCounter.Text, out int blueCount);
            int.TryParse(cheeseEmmentalerCounter.Text, out int emmentalerCount);
            int.TryParse(cheeseGhoudaCounter.Text, out int ghoudaCount);

            if (mozarellaCount != 0)
            {
                for (int i = 0; i < mozarellaCount; i++)
                {
                    string name = "Mozarella";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (cheddarCount != 0)
            {
                for (int i = 0; i < cheddarCount; i++)
                {
                    string name = "Cheddar";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (swissCount != 0)
            {
                for (int i = 0; i < swissCount; i++)
                {
                    string name = "Swiss";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (blueCount != 0)
            {
                for (int i = 0; i < blueCount; i++)
                {
                    string name = "Blue";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (emmentalerCount != 0)
            {
                for (int i = 0; i < emmentalerCount; i++)
                {
                    string name = "Emmentaler";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (ghoudaCount != 0)
            {
                for (int i = 0; i < ghoudaCount; i++)
                {
                    string name = "Ghouda";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }


        }

        protected void vegetableAddButton_OnClick(object sender, EventArgs e)
        {
            int.TryParse(vegetableOnionCounter.Text, out int onionCount);
            int.TryParse(vegetableLettuceCounter.Text, out int lettuceCount);
            int.TryParse(vegetableTomatoCounter.Text, out int tomatoCount);
            int.TryParse(vegetableCucumberCounter.Text, out int cucumberCount);

            if (onionCount != 0)
            {
                for (int i = 0; i < onionCount; i++)
                {
                    string name = "Onions";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (lettuceCount != 0)
            {
                for (int i = 0; i < lettuceCount; i++)
                {
                    string name = "Lettuce";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (tomatoCount != 0)
            {
                for (int i = 0; i < tomatoCount; i++)
                {
                    string name = "Tomato";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (cucumberCount != 0)
            {
                for (int i = 0; i < cucumberCount; i++)
                {
                    string name = "Cucumber";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }

        }

        protected void sauceAddButton_OnClick(object sender, EventArgs e)
        {
            int.TryParse(texasSauceCounter.Text, out int texasSauceCount);
            int.TryParse(aioliSauceCounter.Text, out int aioliSauceCount);
            int.TryParse(chiliSauceCounter.Text, out int chiliSauceCount);
            int.TryParse(currySauceCounter.Text, out int currySauceCount);
            int.TryParse(greenPestoSauceCounter.Text, out int greenPestoSauceCount);
            int.TryParse(ketchupSauceCounter.Text, out int ketchupSauceCount);
            int.TryParse(mayonaiseSauceCounter.Text, out int mayonaiseSauceCount);
            int.TryParse(sweetChiliSauceCounter.Text, out int sweetChiliSauceCount);

            if (texasSauceCount != 0)
            {
                for (int i = 0; i < texasSauceCount; i++)
                {
                    string name = "Texas Sauce";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (aioliSauceCount != 0)
            {
                for (int i = 0; i < aioliSauceCount; i++)
                {
                    string name = "Aioli";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (chiliSauceCount != 0)
            {
                for (int i = 0; i < chiliSauceCount; i++)
                {
                    string name = "Chili";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (currySauceCount != 0)
            {
                for (int i = 0; i < currySauceCount; i++)
                {
                    string name = "Curry";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (greenPestoSauceCount != 0)
            {
                for (int i = 0; i < greenPestoSauceCount; i++)
                {
                    string name = "Green Pesto";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (ketchupSauceCount != 0)
            {
                for (int i = 0; i < ketchupSauceCount; i++)
                {
                    string name = "Ketchup";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (mayonaiseSauceCount != 0)
            {
                for (int i = 0; i < mayonaiseSauceCount; i++)
                {
                    string name = "Mayonaise";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (sweetChiliSauceCount != 0)
            {
                for (int i = 0; i < sweetChiliSauceCount; i++)
                {
                    string name = "Sweet Chili";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
        }

        protected void extrasAddButton_OnClick(object sender, EventArgs e)
        {
            int.TryParse(extrasBaconCounter.Text, out int baconCount);
            int.TryParse(extrasFriedOnionCounter.Text, out int friedOnionCount);

            if (baconCount != 0)
            {
                for (int i = 0; i < baconCount; i++)
                {
                    string name = "Bacon strips";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
            if (friedOnionCount != 0)
            {
                for (int i = 0; i < friedOnionCount; i++)
                {
                    string name = "Fried Onion Rings";
                    BurgerContentDTO burgerContent = DomainManager.AddIngredientId(name);
                    burgerContent.burger_id = _burgerDto.guid;
                    burgerContentsList.Add(burgerContent);
                }
            }
        }

        //private DataTable ToDataTable(List<BurgerContentDTO> BurgerContent)
        //{
        //    DataTable returnTable = new DataTable("BurgerTable");
        //    returnTable.Columns.Add(new DataColumn("Ingredient Name"));
        //    returnTable.Columns.Add(new DataColumn("Description"));

        //    foreach (var content in BurgerContent)
        //    {
        //        returnTable.AcceptChanges();
        //        DataRow row = returnTable.NewRow();
        //        row[0] = content.BurgerIngredientDTO.name;
        //        row[1] = content.BurgerIngredientDTO.description;
        //        returnTable.Rows.Add(row);
        //    }
        //    return returnTable;
        //}

    }
}