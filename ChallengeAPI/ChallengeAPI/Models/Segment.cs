using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; 

namespace ChallengeAPI.Models
{
    public partial class Segment
    {
        public Segment()
        {
            Customers = new HashSet<Customer>();
        }

        public int SegId { get; set; }
        public string? SegName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
