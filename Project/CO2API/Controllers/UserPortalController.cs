using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web.Http;
using CO2API.Models;
using CO2API.Secruty;
using CO2API.Interfaces;

namespace CO2API.Controllers
{
    public class UserPortalController : ApiController
    {
        private IDatabaseHandler databaseHandler = new CO2API.Handlers.DatabaseHandler();
        /// <summary>
        /// This is used for testing the conncection betweed server and client.
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            return "Bla lbas";
        }
        /// <summary>
        /// Login Controller that compares the reveived password and the password stored in the database.
        /// </summary>
        /// <param name="username">normaily a mail</param>
        /// <param name="Password">Non hashing form</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<CustomUserModel> Login(string username, string Password)
        {

            User loginUser = databaseHandler.UserLogin(username, Password);
            try
            {
                if (loginUser.Id != 0)
                {
                    //TODO: add this line ,CarbonHistroy = new List<CarbonHistroy>(){ databaseHandler.GetUserCarbonHistroy(loginUser.Id)}
                    return Json(new CustomUserModel { UserMail = loginUser.LoginInfo.FirstOrDefault().Email, Id = loginUser.Id, TotalFootPrint = loginUser.TotalFootPrint });
                }
                else
                {
                    return Json(new CustomUserModel { UserMail = "Not Found" });

                }
            }
            catch (Exception e)
            {
                return Json(new CustomUserModel { UserMail = e.Message });
            }
        }
        /// <summary>
        /// This is for creating a user profil.
        /// </summary>
        /// <param name="username">normaly a mail</param>
        /// <param name="password">non hashed form</param>
        /// <param name="haveCar">a simple bool for indicatining wheter a user profile owns a car.</param>
        /// <param name="carModel">a model name</param>
        /// <param name="lat">The lattetud of the users primrey locktion</param>
        /// <param name="lon">the longtatuid of the users primert locktion</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult<string> CreateUser(string username, string password, bool haveCar, string carModel, string lat, string lon, string emission)
        {
            try
            {
                bool userCreated = databaseHandler.CreateUser(username, password, haveCar, carModel, lat, lon, emission);
                if (userCreated)
                    return Json("True");
                else
                    return Json("False");
            }
            catch (Exception e)
            {

                return Json($" Exception : {e.Message}\n The data reviceved user mail : {username} PassWord : {password} Have Car : {haveCar} Car Model :  {carModel}");
            }

        }
    }
}