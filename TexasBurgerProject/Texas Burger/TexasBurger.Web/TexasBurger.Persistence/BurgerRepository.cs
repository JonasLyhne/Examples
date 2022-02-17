using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public class BurgerRepository
    {
        public static void CreateBurgers(List<BurgerDTO> burgerDTOs)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<Burger> burgers = ConvertToEntity(burgerDTOs);
            foreach (var burger in burgers)
            {
                db.Burger.Add(burger);

                foreach (var burgerContent in burger.BurgerContent)
                {
                    db.BurgerContent.Add(burgerContent);
                }

                foreach (var orderContent in burger.OrderContent)
                {
                    db.OrderContent.Add(orderContent);
                }
            }

            db.SaveChanges();
        }

        //TODO: create stuff.. 

        private static List<Burger> ConvertToEntity(List<BurgerDTO> burgerDTOs)
        {
            List<Burger> burgers = new List<Burger>();
            foreach (var burgerDTO in burgerDTOs)
            {
                Burger burger = Mapper.Map<BurgerDTO, Burger>(burgerDTO);
                foreach (var orderContentDTO in burgerDTO.OrderContentDTO)
                {
                    OrderContent orderContent = Mapper.Map<OrderContentDTO, OrderContent>(orderContentDTO);
                    burger.OrderContent.Add(orderContent);                
                };
                foreach (var burgerContentDTO in burgerDTO.BurgerContentDTO)
                {
                    BurgerContent burgerContent = Mapper.Map<BurgerContentDTO, BurgerContent>(burgerContentDTO);
                    burger.BurgerContent.Add(burgerContent);
                };
                burgers.Add(burger);
            }
            return burgers;
        }
    }
}
