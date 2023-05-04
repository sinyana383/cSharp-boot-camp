namespace day00;
using System.Collections.Concurrent;

public class CashRegister
{
    private ConcurrentQueue<Customer> _queueCheckout;
    private TimeSpan _allTimeSpan = TimeSpan.Zero;
    static private TimeSpan _itemSpend;
    static private TimeSpan _betweenCustomerSpend;
    // static public bool AreAnyCustomersLeft = true;
    public string Name { get; }

    public CashRegister(string name, TimeSpan itemSpend, TimeSpan betweenCustomerSpend)
    {
        Name = name;
        _queueCheckout = new ConcurrentQueue<Customer>();
        _itemSpend = itemSpend;
        _betweenCustomerSpend = betweenCustomerSpend;
    }

    public override string ToString() => "Register" + ' ' + Name;
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        var other = (CashRegister)obj;
        return this.Name == other.Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public int GetGoodsNumberFromAllCustomers()
    {
        int res = 0;
        var qEnum = _queueCheckout.GetEnumerator();
        while (qEnum.MoveNext())
            res += qEnum.Current.GoodsNumInCart;
        return res;
    }
    public int GetCustomerNumberAtCheckout() => _queueCheckout.ToArray().Length;

    public IEnumerable<Customer> Customers => _queueCheckout;
    public void AddCustomerToCheckout(Customer c) => _queueCheckout.Enqueue(c);

    public void Process(Customer c)
    {
        for (int i = 0; i < c.GoodsNumInCart; ++i)
            Thread.Sleep(_itemSpend);
        Thread.Sleep(_betweenCustomerSpend);
        _allTimeSpan = _allTimeSpan.Add(TimeSpan.FromSeconds(_itemSpend.Seconds * c.GoodsNumInCart
                                                             + _betweenCustomerSpend.Seconds));
        Console.WriteLine($"{this} -> {c} total: {_allTimeSpan.Seconds} sec" +
                          $"with {c.GoodsNumInCart} goods" +
                          $"{_queueCheckout.Count} customers behind");
    }

    public void Work(Storage s)
    {
        while (_queueCheckout.Any())
        {
            Customer curCustomer;
            _queueCheckout.TryDequeue(out curCustomer);
            if (curCustomer != null)
                Process(curCustomer);
        }
    }
}