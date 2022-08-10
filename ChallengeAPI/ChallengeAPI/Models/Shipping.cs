using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; 

namespace ChallengeAPI.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Order>();
        }

        public string ShipMode { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
