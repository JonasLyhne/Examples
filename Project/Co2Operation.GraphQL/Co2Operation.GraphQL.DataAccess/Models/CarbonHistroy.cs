using System;
using System.Collections.Generic;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class CarbonHistroy
    {
        public int UserId { get; set; }
        public decimal? TotalFootPrint { get; set; }
        public DateTime Day { get; set; }

        public virtual User User { get; set; }
    }
}
