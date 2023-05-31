namespace day01;
using System.Collections.Concurrent;

public class CashRegister
{
    private static readonly Random s_r = new Random();
    private static  TimeSpan s_itemSpend;
    private static TimeSpan s_betweenCustomerSpend;
    
    private readonly ConcurrentQueue<Customer> _queueCheckout;
    private TimeSpan _allTimeSpan = TimeSpan.Zero;
    private int _passCustomersNumber;
    public string Name { get; }

    public CashRegister(string name, TimeSpan itemSpend, TimeSpan betweenCustomerSpend)
    {
        Name = name;
        _queueCheckout = new ConcurrentQueue<Customer>();
        s_itemSpend = itemSpend;
        s_betweenCustomerSpend = betweenCustomerSpend;
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
        var res = 0;
        var qEnum = _queueCheckout.GetEnumerator();
        while (qEnum.MoveNext())
            res += qEnum.Current.GoodsNumInCart;
        return res;
    }
    public int GetCustomerNumberAtCheckout() => _queueCheckout.ToArray().Length;
    public IEnumerable<Customer> Customers => _queueCheckout;
    public void AddCustomerToCheckout(Customer c)
    {
        _queueCheckout.Enqueue(c);
        Interlocked.Increment(ref _passCustomersNumber);
    }
    private void Process(Customer c)
    {
        var allItemSpend = 0;
        for (var i = 0; i < c.GoodsNumInCart; ++i)
        {
            int itemSpend = s_r.Next(1, s_itemSpend.Seconds);
            Thread.Sleep(itemSpend * 1000);
            allItemSpend += itemSpend;
        }

        int betweenCustomerSpend = s_r.Next(1, s_betweenCustomerSpend.Seconds);
        Thread.Sleep(betweenCustomerSpend * 1000);
        _allTimeSpan = _allTimeSpan.Add(TimeSpan.FromSeconds(allItemSpend + betweenCustomerSpend));
        Console.WriteLine($"{this} -> {c} total: {_allTimeSpan.Seconds} sec\n" +
                          $"with {c.GoodsNumInCart} goods\n" +
                          $"{_queueCheckout.Count} customers behind\n");
    }

    public void Work(Store s)
    {
        while (_queueCheckout.Any() || s.IsOpen() || s.IsSomeCustomerIn)
        {
            Customer curCustomer;
            _queueCheckout.TryDequeue(out curCustomer);
            if (curCustomer != null)
                Process(curCustomer);
        }
        Console.WriteLine($"{this}, average time: {_allTimeSpan / _passCustomersNumber}");
    }
}