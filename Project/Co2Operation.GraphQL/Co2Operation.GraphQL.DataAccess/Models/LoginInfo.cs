using System;
using System.Collections.Generic;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class LoginInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
