using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CO2API.Interfaces;
using CO2API.Secruty;
using ProtobufServer;

namespace CO2API.Handlers
{
    public class DatabaseHandler : IDatabaseHandler
    {
        /// <summary>
        /// Creates a new user with a car if they have one.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="haveCar"></param>
        /// <param name="carModel"></param>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="emission"></param>
        /// <returns></returns>
        public bool CreateUser(string username, string password, bool haveCar, string carModel, string lat, string lon, string emission)
        {
            User newUser;
            using (Co2DatabaseEntities context = new Co2DatabaseEntities())
            {
                newUser =
                    new User
                    {
                        TotalFootPrint = (decimal)8.500,
                        PrimaryLocation = DbGeography.PointFromText(string.Format("POINT({0} {1})", lat, lon), 4326)
                    };
                newUser.LoginInfo = new List<LoginInfo>() { new LoginInfo { Email = username, Password = new Hashing().HashPassword(password), UserID = newUser.Id } };

                if (haveCar)
                {
                    newUser.Car = new List<Car>() { new Car { Model = carModel, UserId = newUser.Id, AverageCo2 = Convert.ToInt32(emission) } };
                }
                if (newUser != null)
                {
                    context.User.Add(newUser);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Get carbonHistryoy.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CarbonHistroy GetUserCarbonHistroy(int userId)
        {
            using (Co2DatabaseEntities context = new Co2DatabaseEntities())
            {
                CarbonHistroy carbon = context.CarbonHistroy.Where(x => x.UserID == userId).ToList()[0];
                if (carbon != null)
                {
                    return carbon;
                }
            }
            return new CarbonHistroy() { UserID = 0 };
        }
        /// <summary>
        /// Login for the user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User UserLogin(string username, string password)
        {
            using (Co2DatabaseEntities context = new Co2DatabaseEntities())
            {
                try
                {
                    User loginuser = context.User.Find(context.LoginInfo.Find(username).UserID);
                    if (loginuser != null && loginuser.LoginInfo.FirstOrDefault().Password == new Hashing().HashPassword(password))
                    {
                        return loginuser;
                    }
                }
                catch (Exception)
                {

                    return new User { Id = 0 };
                }
            }
            return new User { Id = 0 };
        }
        /// <summary>
        /// Creates a trip based on userid and transport used.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newtrip"></param>
        /// <returns></returns>
        public bool CreateTrip(int userid, ProtobufServer.Trip newtrip)
        {
            // TODO: Make a TotalCo2 caluleation.
            //TODO: get TransportMethos.
            // 180 * distands
            // https://localhost:44324/api/MobilClient/TripViaProtobuf/?data=CAkSEK06efl1q0tA1XS9io+OJ0AaEOZ8R0g/rUtA5BINxOCCJ0AhbedjNGZSAUAqBgj0n9z7BTIGCJ+h3PsFSX1L/fknbklA
            using (Co2DatabaseEntities contex = new Co2DatabaseEntities())
            {
                Trip tripFordatabase = new CO2API.Trip();
                tripFordatabase.StartTime = newtrip.Starttime.ToDateTime();
                tripFordatabase.StartLocation = DbGeography.FromText($"POINT({newtrip.StartLocationFormated[0].ToString().Replace(",",".")} {newtrip.StartLocationFormated[1].ToString().Replace(",", ".")})");
                tripFordatabase.Endlocation = DbGeography.PointFromText(string.Format("POINT({0} {1})", newtrip.EndLocationFormated[0].ToString().Replace(",", "."), newtrip.EndLocationFormated[1].ToString().Replace(",", ".")), 4326);
                tripFordatabase.Distance = (decimal)newtrip.Distance;
                tripFordatabase.TotalCo2 = 0;
                tripFordatabase.EndTime = newtrip.Endtime.ToDateTime();
                tripFordatabase.UserID = newtrip.UserId;

                if (newtrip.BreakCount >= 4 && newtrip.Distance > 5)
                {

                    tripFordatabase.TransportMethodId = (int)transport.Bus;
                    tripFordatabase.TotalCo2 = (decimal)(((int)contex.TransportMethods.Find((int)transport.Bus).AverageCo2) * newtrip.Distance / 1000);
                }
                else
                {
                    tripFordatabase.TransportMethodId = (int)transport.Car;
                    tripFordatabase.TotalCo2 = (decimal)(((int)contex.TransportMethods.Find((int)transport.Car).AverageCo2) * newtrip.Distance ) / 1000;
                }
                contex.Trip.Add(tripFordatabase);
                contex.SaveChanges();

            }
            return true;
        }
    }
    enum transport
    {
        Car = 1,
        Train = 2,
        Bus = 3
    }
}