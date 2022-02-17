using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO2API.Models
{
    /// <summary>
    /// This is used for the respond when loggin in.
    /// </summary>
    public class CustomUserModel : User
    {
        public string UserMail { get; set; }
    }
}