using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LDAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.CreateDirectoryEntry();
            Console.WriteLine("You are connected to the Texas Burger domain");
            try
            {
            Console.Write("Input username: ");
            ResultPropertyCollection fields = client.SearchAllFromOne(Console.ReadLine()).Properties;
            foreach (string ldapField in fields.PropertyNames)
            {
                foreach (Object myCollection in fields[ldapField])
                {
                    Console.WriteLine(String.Format("{0,-20} : {1}",
                    ldapField, myCollection.ToString()));
                }
            }
            }
            catch (Exception)
            {
                Console.WriteLine("User not found");
            }
            Console.ReadLine();
        }
    }
}

