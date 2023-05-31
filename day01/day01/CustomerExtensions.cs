namespace day00;

public static class CustomerExtensions
{
    public static  CashRegister LeastCustomerNumber(IEnumerable<CashRegister> setOfRegisters)
    {
        var minCustomers = setOfRegisters.FirstOrDefault();
        foreach (CashRegister cur in setOfRegisters)
            minCustomers = cur.GetCustomerNumberAtCheckout() < minCustomers.GetCustomerNumberAtCheckout() 
                ? cur
                : minCustomers;

        return minCustomers;
    }
    
    public static CashRegister LeastGoodsNumber(IEnumerable<CashRegister> setOfRegisters)
    {
        var minGoods = setOfRegisters.FirstOrDefault();
        foreach (CashRegister cur in setOfRegisters)
            minGoods = cur.GetGoodsNumberFromAllCustomers() < minGoods.GetGoodsNumberFromAllCustomers()
                ? cur
                : minGoods;

        return minGoods;
    }
}