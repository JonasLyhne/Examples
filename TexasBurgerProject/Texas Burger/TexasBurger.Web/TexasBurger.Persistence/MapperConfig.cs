using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public static class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Burger, BurgerDTO>().ReverseMap();
                cfg.CreateMap<BurgerIngredient, BurgerIngredientDTO>().ReverseMap();
                cfg.CreateMap<BurgerIngredientType, BurgerIngredientTypeDTO>().ReverseMap();
                cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
                cfg.CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
                cfg.CreateMap<BurgerContent, BurgerContentDTO>().ReverseMap();
                cfg.CreateMap<Inventory, InventoryDTO>().ReverseMap();
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
                cfg.CreateMap<OrderContent, OrderContentDTO>().ReverseMap();
            });
        }
    }
}
