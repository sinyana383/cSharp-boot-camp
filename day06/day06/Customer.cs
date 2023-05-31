using System.Security.Cryptography;

namespace day01;

public class Customer
{
    private static readonly Random s_r = new Random();
    public static int TotalAmount;
    
    private readonly string _name;
    private readonly int _serialNum;
    public int GoodsNumInCart { get; private set; }
    
    private void FillCart(int cartCapacity, Storage s)
    => GoodsNumInCart = s.TakeGoods(s_r.Next(1, cartCapacity + 1));
    public Customer(string name, int serialNum)
    {
        _name = name;
        _serialNum = serialNum;
        GoodsNumInCart = 0;
        Interlocked.Increment(ref TotalAmount);
    }
    public override string ToString() => _name + ", customer #" + _serialNum;
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        var other = (Customer)obj;
        return this._name == other._name && this._serialNum == other._serialNum;
    }
    public override int GetHashCode() => HashCode.Combine(_name, _serialNum);
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
        FillCart(cartCap, s.Storage);
        if (storeMode == Store.Mode.ShortestQueue)
            reg = CustomerExtensions.LeastCustomerNumber(s.CashRegistersSet);
        else
            reg = CustomerExtensions.LeastGoodsNumber(s.CashRegistersSet);
        reg.AddCustomerToCheckout(this);
    }
}