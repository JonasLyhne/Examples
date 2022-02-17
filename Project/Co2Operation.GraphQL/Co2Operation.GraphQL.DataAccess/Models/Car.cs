using System;
using System.Collections.Generic;

namespace Co2Operation.GraphQL.DataAccess.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int? AverageCo2 { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
