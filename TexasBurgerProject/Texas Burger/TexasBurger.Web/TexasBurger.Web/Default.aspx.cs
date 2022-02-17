using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexasBurger.Domain;
using TexasBurger.DTO;

namespace TexasBurger.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void doneButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                nameValidationLabel.Text = "Please enter your name.";
                nameValidationLabel.Visible = true;
                return;
            }
            if (tableTextBox.Text.Trim().Length == 0) //Or if not == to name in list of predefined tableNames.
            {
                tableValidationLabel.Text = "Please enter table number.";
                tableValidationLabel.Visible = true;
                return;
            }
            else
            {
                DomainManager dm = new DomainManager();
                CustomerDTO customer = dm.CreateCustomer(nameTextBox.Text.Trim(), tableTextBox.Text.Trim());
                OrderDTO orderDTO = dm.CreateOrder(customer); 
                dm.SaveCustomer(customer);
                Response.Redirect("Home.aspx");
            }
        }
    }
}