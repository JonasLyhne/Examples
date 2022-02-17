using System;
using System.Collections.Generic;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class Trip
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? TransportMethodId { get; set; }
        public decimal? Distance { get; set; }
        public decimal? TotalCo2 { get; set; }

        public virtual TransportMethods TransportMethod { get; set; }
        public virtual User User { get; set; }
    }
}
