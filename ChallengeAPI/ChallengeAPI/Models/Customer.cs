using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; 

namespace ChallengeAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustId { get; set; }
        public int? SegId { get; set; }
        public string? Region { get; set; }
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PostCode { get; set; }

        [JsonIgnore]
        public virtual Region? RegionNavigation { get; set; }
        [JsonIgnore]
        public virtual Segment? Seg { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
