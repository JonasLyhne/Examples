using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class OrderContentDTO
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public System.Guid burger_id { get; set; }
        public int quantity { get; set; }
        public BurgerDTO BurgerDTO { get; set; }
        public OrderDTO OrderDTO { get; set; }
    }
}
