using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class RestaurantDTO
    {
        public RestaurantDTO()
        {
            this.InventoryDTO = new HashSet<InventoryDTO>();
            this.OrderDTO = new HashSet<OrderDTO>();
        }
        public int id { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public ICollection<InventoryDTO> InventoryDTO { get; set; }
        public ICollection<OrderDTO> OrderDTO { get; set; }
    }
}
