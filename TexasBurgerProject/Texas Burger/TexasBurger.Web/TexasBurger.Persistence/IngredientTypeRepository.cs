using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public class IngredientTypeRepository
    {
        public static List<BurgerIngredientTypeDTO> GetIngredientTypes()
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<BurgerIngredientType> ingredientTypes = db.BurgerIngredientType.ToList();
            List<BurgerIngredientTypeDTO> burgerIngredientTypeDTO = ConvertToDTO(ingredientTypes);
            return burgerIngredientTypeDTO;
        }

        private static List<BurgerIngredientTypeDTO> ConvertToDTO(List<BurgerIngredientType> ingredientTypes)
        {
            List<BurgerIngredientTypeDTO> typeDTO = Mapper.Map<List<BurgerIngredientType>, List<BurgerIngredientTypeDTO>>(ingredientTypes);
            return typeDTO;
        }
    }
}
