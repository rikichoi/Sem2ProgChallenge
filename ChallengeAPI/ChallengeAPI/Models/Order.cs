using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ChallengeAPI.Models
{
    public partial class Order
    {
        public DateTime OrderDate { get; set; }
        public string ProdId { get; set; }
        public string? ShipMode { get; set; }
        public string CustId { get; set; }
        public int Quantity { get; set; }
        public DateTime? ShipDate { get; set; }

        public static double TotalCost(double OrderQuantity, double ProductPrice)
    {
        double TotalCost = OrderQuantity * ProductPrice;
        return (TotalCost);
    }

        public static double PayableGST(double OrderQuantity, double ProductPrice, double TotalGST, double WithoutGST)
    {
        double PayableGST = (((OrderQuantity * ProductPrice)*TotalGST)/WithoutGST);
        return (PayableGST);
    }


        [JsonIgnore]
        public virtual Customer Cust { get; set; }
        [JsonIgnore]
        public virtual Product Prod { get; set; }
        [JsonIgnore]
        public virtual Shipping? ShipModeNavigation { get; set; }
    }
}
