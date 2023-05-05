using System.Security.Cryptography;

namespace day00;

public class Customer
{
    // static field
    static Random r = new Random();
    public static int TotalAmount;

    // auto-properties:
    public string Name { get; }
    public int SerialNum { get; }
    public int GoodsNumInCart { get; private set; }


    public Customer(string name, int serialNum)
    {
        Name = name;
        SerialNum = serialNum;
        GoodsNumInCart = 0;
        Interlocked.Increment(ref TotalAmount);
    }

    public override string ToString()
    => Name + ", customer #" + SerialNum;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        var other = (Customer)obj;
        return this.Name == other.Name && this.SerialNum == other.SerialNum;
    }
    
    public override int GetHashCode()
    => HashCode.Combine(Name, SerialNum);

    public void FillCart(int cartCapacity, Storage s)
    => GoodsNumInCart = s.TakeGoods(r.Next(1, cartCapacity + 1));

    public void ThreadProcess(int cartCap, Store s, ref int threadCount, ManualResetEvent allThreadsComplete,
        Store.Mode storeMode = Store.Mode.ShortestQueue)
    {

        FillCartAndChooseRegister(cartCap, s, storeMode);
        if (Interlocked.Decrement(ref threadCount) <= 0)
            allThreadsComplete.Set();
    }

    public void FillCartAndChooseRegister(int cartCap, Store s, Store.Mode storeMode = Store.Mode.ShortestQueue)
    {
        CashRegister reg;
        if (storeMode == Store.Mode.ShortestQueue)
            reg = CustomerExtensions.LeastCustomerNumber(s.RegistersSet);
        else
            reg = CustomerExtensions.LeastGoodsNumber(s.RegistersSet);
        reg.AddCustomerToCheckout(this);
        FillCart(cartCap, s.Storage);
    }
}