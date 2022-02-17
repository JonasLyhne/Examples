using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.Persistence;
using TexasBurger.DTO;

namespace TexasBurger.Domain
{
    public class DomainManager
    {
        public static void StartMapper()
        {
            MapperConfig.RegisterMapping();
        }

        private static OrderDTO _orderDTO;
        private static CustomerDTO _customerDTO;
        private static List<BurgerContentDTO> _listBurgerContentDTO;
        private static List<BurgerDTO> _listBurgerDTO = new List<BurgerDTO>();
        public static List<BurgerIngredientDTO> _burgerIngredients;


        public static List<BurgerIngredientDTO> GetIngredients()
        {
            List<BurgerIngredientDTO> ingredients = IngredientRepository.GetAllIngredients();
            return ingredients;
        }

        public void SaveBurger(BurgerDTO burgerDTO)
        {
            _listBurgerDTO.Add(burgerDTO);
        }

        public void SaveCustomer(CustomerDTO customer)
        {
            _customerDTO = customer;
        }

        public BurgerDTO CreateBurger(string burgerName)
        {
            BurgerDTO burger = new BurgerDTO();
            burger.guid = Guid.NewGuid();
            burger.name = burgerName;
            return burger;
        }



        public void StartOrder()
        {
            foreach (var burgerDTO in _listBurgerDTO) //Tiltænkt at man skal kunne bestille flere burgere på éngang
            {
                OrderContentDTO orderContentDTO = new OrderContentDTO();
                orderContentDTO.burger_id = burgerDTO.guid;
                orderContentDTO.order_id = _orderDTO.id;
            }
            BurgerRepository.CreateBurgers(_listBurgerDTO);
        }

        public CustomerDTO CreateCustomer(string name, string tableNumber)
        {
            CustomerDTO customer = new CustomerDTO();
            customer.name = name;
            customer.tableNumber = tableNumber;
            customer.id = CustomerRepository.CreateCustomer(customer);
            return customer;
        }

        public OrderDTO CreateOrder(CustomerDTO customerDTO)
        {
            OrderDTO order = new OrderDTO();
            order.restaurant_id = 1; //HARDCODED VALUE. TODO: Figure out how to get this thing..
            order.customer_id = customerDTO.id;
            order.id = OrderRepository.CreateOrder(order);
            _orderDTO = order;
            return order;
        }





        public BurgerContentDTO AddIngredientId(string name)
        {
            _burgerIngredients = GetIngredients();
            BurgerContentDTO burgerContent = new BurgerContentDTO();
            burgerContent.burgerIngredient_id = _burgerIngredients.FirstOrDefault(x => x.name == name).id;
            burgerContent.BurgerIngredientDTO = AddBurgerIngredientDTO(burgerContent.burgerIngredient_id);
            return burgerContent;
        }

        private BurgerIngredientDTO AddBurgerIngredientDTO(int? burgerIngredientId)
        {
            BurgerIngredientDTO burgerIngredient = new BurgerIngredientDTO();
            if (burgerIngredientId != null)
            {
                burgerIngredient = IngredientRepository.GetIngredientById(burgerIngredientId);
            }
            return burgerIngredient;
        }

        public string IncrementCount(string textBoxText)
        {
            int.TryParse(textBoxText, out int count);
            count++;
            return count.ToString();
        }
    }
}
