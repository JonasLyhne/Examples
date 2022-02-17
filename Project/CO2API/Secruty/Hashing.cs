using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CO2API.Secruty
{
    public class Hashing
    {
        public string HashPassword(string texttohsh)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] byteHasdh = hash.ComputeHash(Encoding.UTF8.GetBytes(texttohsh));
                StringBuilder bulid = new StringBuilder();
                foreach (byte item in byteHasdh)
                {
                    bulid.Append(item.ToString("x2"));
                }
                return bulid.ToString();
            }

        }
    }
}