using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasBurger.DTO
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
            this.OrderDTO = new HashSet<OrderDTO>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string tableNumber { get; set; }
        public ICollection<OrderDTO> OrderDTO { get; set; }
    }
}
