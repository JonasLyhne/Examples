using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class BurgerContentDTO
    {

        public int id { get; set; }
        public System.Guid burger_id { get; set; }
        public Nullable<int> burgerIngredient_id { get; set; }

        public virtual BurgerDTO BurgerDTO { get; set; }
        public virtual BurgerIngredientDTO BurgerIngredientDTO { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Ingredient: {BurgerIngredientDTO?.name}");

            return sb.ToString();


        }
    }
}
