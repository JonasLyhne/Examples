using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            this.OrderContentDTO = new HashSet<OrderContentDTO>();
        }
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public int customer_id { get; set; }
        public Nullable<bool> completed { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public RestaurantDTO RestaurantDTO { get; set; }
        public ICollection<OrderContentDTO> OrderContentDTO { get; set; }
    }
}
