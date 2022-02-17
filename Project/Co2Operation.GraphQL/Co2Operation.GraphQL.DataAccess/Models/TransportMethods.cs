using System;
using System.Collections.Generic;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class TransportMethods
    {
        public TransportMethods()
        {
            Trip = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? AverageCo2 { get; set; }

        public virtual ICollection<Trip> Trip { get; set; }
    }
}
