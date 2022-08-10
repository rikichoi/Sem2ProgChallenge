using System;

namespace UnitTest
{
public class Program
{
    public static double TotalCost(double OrderQuantity, double ProductPrice)
    {
        return (OrderQuantity * ProductPrice);
    }

        public static double PayableGST(double OrderQuantity, double ProductPrice, double TotalGST, double WithoutGST)
    {
        return (((OrderQuantity * ProductPrice)*TotalGST)/WithoutGST);
    }
}
}