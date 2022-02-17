using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class BurgerIngredientDTO
    {
        public BurgerIngredientDTO()
        {
            this.BurgerContentDTO = new HashSet<BurgerContentDTO>();
            this.InventoryDTO = new HashSet<InventoryDTO>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public Nullable<int> type_id { get; set; }
        public ICollection<BurgerContentDTO> BurgerContentDTO { get; set; }
        public BurgerIngredientTypeDTO BurgerIngredientTypeDTO { get; set; }
        public ICollection<InventoryDTO> InventoryDTO { get; set; }
    }
}
