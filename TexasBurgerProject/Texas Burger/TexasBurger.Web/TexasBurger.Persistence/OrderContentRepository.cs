using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public class OrderContentRepository
    {
        public static List<OrderContentDTO> GetOrderContentByOrderId(int orderId)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<OrderContent> orderContents = db.OrderContent.Where(oc => oc.order_id == orderId).ToList();
            List<OrderContentDTO> ordercontentDTOs = ConvertToDto(orderContents);
            return ordercontentDTOs;
        }

        public static void AddOrderContent(List<OrderContentDTO> orderContentDTOs)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<OrderContent> orderContents = ConvertToEntity(orderContentDTOs);
            foreach (var orderContent in orderContents)
            {
                db.OrderContent.Add(orderContent);
            }
            db.SaveChanges();
        }

        private static List<OrderContent> ConvertToEntity(List<OrderContentDTO> orderContentDTOs)
        {
            List<OrderContent> orderContents = new List<OrderContent>();
            foreach (var orderContentDTO in orderContentDTOs)
            {
                OrderContent orderContent = Mapper.Map<OrderContentDTO, OrderContent>(orderContentDTO);
                orderContents.Add(orderContent);
            }
            return orderContents;
        }

        private static List<OrderContentDTO> ConvertToDto(List<OrderContent> orderContents)
        {
            List<OrderContentDTO> orderContentDTOs = new List<OrderContentDTO>();

            foreach (var orderContent in orderContents)
            {
                OrderContentDTO orderContentDTO = Mapper.Map<OrderContent, OrderContentDTO>(orderContent);
                orderContentDTO.BurgerDTO = Mapper.Map<Burger, BurgerDTO>(orderContent.Burger);
                orderContentDTO.OrderDTO = Mapper.Map<Order, OrderDTO>(orderContent.Order);
                orderContentDTOs.Add(orderContentDTO);
            }
            return orderContentDTOs;
        }


    }
}
