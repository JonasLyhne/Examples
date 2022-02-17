using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class InventoryDTO
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public int burger_ingredient_id { get; set; }
        public int quantity { get; set; }
        public BurgerIngredientDTO BurgerIngredientDTO { get; set; }
        public RestaurantDTO RestaurantDTO { get; set; }
    }
}
