using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public class IngredientRepository
    {
        public static List<BurgerIngredientDTO> GetAllIngredients()
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<BurgerIngredient> ingredients = db.BurgerIngredient.ToList();
            List<BurgerIngredientDTO> burgerIngredientDTO = ConvertToDto(ingredients);
            return burgerIngredientDTO;
        }

        public static BurgerIngredientDTO GetIngredientById(int? id)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<BurgerIngredient> burgerIngredients = db.BurgerIngredient.Where(i => i.id == id).ToList();
            List<BurgerIngredientDTO> burgerIngredientDTOs = ConvertToDto(burgerIngredients);
            return burgerIngredientDTOs.FirstOrDefault();
        }

        public static List<BurgerIngredientDTO> GetIngredientsByName(string ingredientName)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<BurgerIngredient> burgerIngredients = db.BurgerIngredient.Where(i => i.name == ingredientName).ToList();
            List<BurgerIngredientDTO> burgerIngredientDTOs = ConvertToDto(burgerIngredients);
            return burgerIngredientDTOs;
        }

        public static List<BurgerIngredientDTO> GetIngredientsByType(string typeName)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<BurgerIngredient> burgerIngredients = db.BurgerIngredient.Where(i => i.BurgerIngredientType.name == typeName).ToList();
            List<BurgerIngredientDTO> burgerIngredientDTOs = ConvertToDto(burgerIngredients);
            return burgerIngredientDTOs;
        }

        private static List<BurgerIngredientDTO> ConvertToDto(List<BurgerIngredient> ingredients)
        {
            List<BurgerIngredientDTO> ingredientDTOs = new List<BurgerIngredientDTO>();

            foreach (var ingredient in ingredients)
            {
                BurgerIngredientDTO burgerIngredientDTO = Mapper.Map<BurgerIngredient, BurgerIngredientDTO>(ingredient);
                burgerIngredientDTO.BurgerContentDTO = Mapper.Map<List<BurgerContent>, List<BurgerContentDTO>>(ingredient.BurgerContent.ToList());
                burgerIngredientDTO.BurgerIngredientTypeDTO = Mapper.Map<BurgerIngredientType, BurgerIngredientTypeDTO>(ingredient.BurgerIngredientType);
                ingredientDTOs.Add(burgerIngredientDTO);
            }
            return ingredientDTOs;
        }
    }
}
