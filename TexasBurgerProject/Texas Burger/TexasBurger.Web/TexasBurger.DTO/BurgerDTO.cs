using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class BurgerDTO
    {
        public BurgerDTO()
        {
            this.BurgerContentDTO = new HashSet<BurgerContentDTO>();
            this.OrderContentDTO = new HashSet<OrderContentDTO>();
        }
        public Guid guid { get; set; }
        public string name { get; set; }
        public ICollection<BurgerContentDTO> BurgerContentDTO { get; set; }
        public ICollection<OrderContentDTO> OrderContentDTO { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // Name of Burger.
            sb.Append($"Name: {this.name} ");
            
            // Name of each Ingredient
            foreach (var burgercontent in this.BurgerContentDTO)
            {
                sb.Append($"Ingredient: {burgercontent?.BurgerIngredientDTO?.name}");
            }

            


            return sb.ToString();


        }
    }
}
