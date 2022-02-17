using System;
using System.Collections.Generic;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Car = new HashSet<Car>();
            CarbonHistroy = new HashSet<CarbonHistroy>();
            LoginInfo = new HashSet<LoginInfo>();
            Trip = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public decimal? TotalFootPrint { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<CarbonHistroy> CarbonHistroy { get; set; }
        public virtual ICollection<LoginInfo> LoginInfo { get; set; }
        public virtual ICollection<Trip> Trip { get; set; }
    }
}
