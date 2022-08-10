using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; 

namespace ChallengeAPI.Models
{
    public partial class Region
    {
        public Region()
        {
            Customers = new HashSet<Customer>();
        }

        public string Region1 { get; set; }

        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
