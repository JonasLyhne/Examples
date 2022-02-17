using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class BurgerIngredientTypeDTO
    {
        public BurgerIngredientTypeDTO()
        {
            this.BurgerIngredientDTO = new HashSet<BurgerIngredientDTO>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<BurgerIngredientDTO> BurgerIngredientDTO { get; set; }
    }
}
