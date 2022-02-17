using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public class BurgerContentRepository
    {
        public static void AddBurgerContent(List<BurgerContentDTO> burgerContentDTOs)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<BurgerContent> burgerContents = ConvertToEntity(burgerContentDTOs);
            foreach (var burgerContent in burgerContents)
            {
                db.BurgerContent.Add(burgerContent);
            }
            db.SaveChanges();
        }

        private static List<BurgerContent> ConvertToEntity(List<BurgerContentDTO> burgerContentDTOs)
        {
            List<BurgerContent> burgerContents = new List<BurgerContent>();
            foreach (var contentDTO in burgerContentDTOs)
            {
                BurgerContent burgerContent = Mapper.Map<BurgerContentDTO, BurgerContent>(contentDTO);
                burgerContent.Burger = Mapper.Map<BurgerDTO, Burger>(contentDTO.BurgerDTO);
                burgerContent.BurgerIngredient = Mapper.Map<BurgerIngredientDTO, BurgerIngredient>(contentDTO.BurgerIngredientDTO);
                burgerContents.Add(burgerContent);
            }
            return burgerContents;
        }
    }
}
