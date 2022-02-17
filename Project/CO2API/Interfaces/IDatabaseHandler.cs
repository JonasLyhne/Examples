using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2API.Interfaces
{
    interface IDatabaseHandler
    {
        User UserLogin(string username, string password);
        bool CreateUser(string username, string password, bool haveCar, string carModel, string lat, string lon, string emission);
        CarbonHistroy GetUserCarbonHistroy(int userId);
        bool CreateTrip(int userid,ProtobufServer.Trip newTrip);
    }
}
