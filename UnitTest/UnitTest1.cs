using System;
namespace UnitTest;

public class OrderTests
{

// Expected Result = 9 Passed, 8 Failed

[Theory]
[InlineData(1, 14.62, 14.62)]
[InlineData(6, 14.62, 87.72)]
[InlineData(2, 61.96, 123.92)]
[InlineData(4, 731.94, 2927.76)]
[InlineData(8, 731.94, 5855.52)]
public void PassingTotalCostTestTheory(double OrderQuantity, double ProductPrice, double expected)
{
    // Arrange
    
    // Act -- call the method we ARE TESTING
    double actual = Order.TotalCost(OrderQuantity, ProductPrice);

    //Assert = CHECK IF THE RESULT = THE EXPECTED RESULT
    Assert.Equal(expected, actual);
}

[Theory]
[InlineData(2, 14.62, 1.1, 11, 2.924)]
[InlineData(9, 261.96, 1.1, 11, 235.764)]
[InlineData(3, 731.94, 1.1, 11, 219.58200000000005)]
public void PassingPayableGSTTestTheory(double OrderQuantity, double ProductPrice, double TotalGST, double WithoutGST, double expected)
{
    // Arrange
    
    // Act -- call the method we ARE TESTING
    double actual = Order.PayableGST(OrderQuantity, ProductPrice, TotalGST, WithoutGST);

    //Assert = CHECK IF THE RESULT = THE EXPECTED RESULT
    Assert.Equal(expected, actual);
}

    [Fact]
    public void PassingTotalCostTest1()
    {
        Assert.Equal(14.62, Order.TotalCost(1.0, 14.62));
    }

    [Fact]
    public void PassingTotalCostTest2()
    {
        Assert.Equal(87.72, Order.TotalCost(6, 14.62));
    }


    [Fact]
    public void PassingTotalCostTest4()
    {
        Assert.Equal(785.8799999999999, Order.TotalCost(3, 261.96));

    }
    [Fact]
    public void PassingTotalCostTest5()
    {
        Assert.Equal(2927.76, Order.TotalCost(4, 731.94));

    }
    [Fact]
    public void PassingTotalCostTest6()
    {
        Assert.Equal(5855.52, Order.TotalCost(8, 731.94));

    }




    [Fact]
    public void PassingPayableGST1()
    {
        Assert.Equal(2.924, Order.PayableGST(2, 14.62, 1.1, 11));
    }
    [Fact]
    public void PassingPayableGST2()
    {
        Assert.Equal(235.764, Order.PayableGST(9, 261.96, 1.1, 11));
    }
    [Fact]
    public void PassingPayableGST3()
    {
        Assert.Equal(219.58200000000005, Order.PayableGST(3, 731.94, 1.1, 11));
    }






}