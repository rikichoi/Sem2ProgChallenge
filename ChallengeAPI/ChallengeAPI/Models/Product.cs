using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; 

namespace ChallengeAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public string ProdId { get; set; }
        public int? CatId { get; set; }
        public string? Description { get; set; }
        public int? UnitPrice { get; set; }

        [JsonIgnore]
        public virtual Category? Cat { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
