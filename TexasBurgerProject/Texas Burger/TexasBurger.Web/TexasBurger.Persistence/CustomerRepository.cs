using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasBurger.DTO;

namespace TexasBurger.Persistence
{
    public class CustomerRepository
    {
        public static int CreateCustomer(CustomerDTO customerDTO)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            Customer customer = ConvertToEntity(customerDTO);
            db.Customer.Add(customer);
            db.SaveChanges();
            int id = customer.id;
            return id;
        }

        public static List<CustomerDTO> GetCustomers()
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<Customer> customers = db.Customer.ToList();
            List<CustomerDTO> customersDTOs = ConvertToDTO(customers);
            return customersDTOs;
        }

        public static CustomerDTO GetCustomerById(int id)
        {
            BurgerDBEntities db = new BurgerDBEntities();
            List<Customer> customers = db.Customer.Where(c => c.id == id).ToList();
            CustomerDTO customer = ConvertToDTO(customers).FirstOrDefault();
            return customer;
        }


        private static List<CustomerDTO> ConvertToDTO(List<Customer> customers)
        {
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                CustomerDTO dto = Mapper.Map<Customer, CustomerDTO>(customer);
            }
            return customerDTOs;
        }

        private static Customer ConvertToEntity(CustomerDTO customerDTO)
        {
            Customer customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            return customer;
        }
    }
}
