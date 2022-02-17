using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;
using AutoMapper;

namespace TexasBurger.Persistence
{
    public class OrderRepository
    {
        public static int CreateOrder(OrderDTO dto)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            Order order = ConvertToEntities(dto);
            db.Order.Add(order);
            db.SaveChanges();
            int id = order.id;
            return id;
        }

        public static OrderDTO GetOrderById(int id)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<Order> order = db.Order.Where(o => o.id == id).ToList();
            OrderDTO orderDTO = ConvertToDTO(order);
            return orderDTO;
        }

        private static OrderDTO ConvertToDTO(List<Order> orders)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Order, OrderDTO>(); });
            Order order = orders.FirstOrDefault();
            OrderDTO orderDTO = Mapper.Map<Order, OrderDTO>(order);
            orderDTO.CustomerDTO = Mapper.Map<Customer, CustomerDTO>(order.Customer);
            return orderDTO;
        }

        private static Order ConvertToEntities(OrderDTO dto)
        {
            Order order = Mapper.Map<OrderDTO, Order>(dto);
            return order;
        }
    }
}
