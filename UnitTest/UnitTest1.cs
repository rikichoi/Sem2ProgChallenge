namespace UnitTest;

public class UnitTest1
{

// Expected Result = 9 Passed, 8 Failed

    [Fact]
    public void PassingTotalCostTest1()
    {
        Assert.Equal(14.62, Program.TotalCost(1.0, 14.62));
    }

    [Fact]
    public void PassingTotalCostTest2()
    {
        Assert.Equal(87.72, Program.TotalCost(6, 14.62));
    }

    [Fact]
    public void PassingTotalCostTest3()
    {
        Assert.Equal(123.92, Program.TotalCost(2, 61.96));

    }
    [Fact]
    public void PassingTotalCostTest4()
    {
        Assert.Equal(785.8799999999999, Program.TotalCost(3, 261.96));

    }
    [Fact]
    public void PassingTotalCostTest5()
    {
        Assert.Equal(2927.76, Program.TotalCost(4, 731.94));

    }
    [Fact]
    public void PassingTotalCostTest6()
    {
        Assert.Equal(5855.52, Program.TotalCost(8, 731.94));

    }



    [Fact]
    public void FailingTotalCostTest1()
    {
        Assert.Equal(4, Program.TotalCost(9, 14.62));
    }
    [Fact]
    public void FailingTotalCostTest2()
    {
        Assert.Equal(773.8799999999999, Program.TotalCost(3, 261.96));
    }
    [Fact]
    public void FailingTotalCostTest3()
    {
        Assert.Equal(47.76, Program.TotalCost(4, 731.94));
    }
    [Fact]
    public void FailingTotalCostTest4()
    {
        Assert.Equal(221.52, Program.TotalCost(8, 731.94));
    }


    [Fact]
    public void PassingPayableGST1()
    {
        Assert.Equal(2.924, Program.PayableGST(2, 14.62, 1.1, 11));
    }
    [Fact]
    public void PassingPayableGST2()
    {
        Assert.Equal(235.764, Program.PayableGST(9, 261.96, 1.1, 11));
    }
    [Fact]
    public void PassingPayableGST3()
    {
        Assert.Equal(219.58200000000005, Program.PayableGST(3, 731.94, 1.1, 11));
    }

    [Fact]
    public void FailingPayableGST1()
    {
        Assert.Equal(492.99, Program.PayableGST(9, 14.62, 0.9, 82));
    }
    [Fact]
    public void FailingPayableGST2()
    {
        Assert.Equal(88, Program.PayableGST(3, 261.96, 1.7, 21));

    }
    [Fact]
    public void FailingPayableGST3()
    {
        Assert.Equal(296.17, Program.PayableGST(4, 731.94, 1.2, 32));

    }
    [Fact]
    public void FailingPayableGST4()
    {
        Assert.Equal(200.9, Program.PayableGST(8, 731.94, 1.6, 67));

    }



}