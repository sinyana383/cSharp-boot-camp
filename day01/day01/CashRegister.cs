namespace day00;

public class CashRegister
{
    private Queue<Customer> _queueCheckout;
    static private TimeSpan _itemSpend;
    static private TimeSpan _betweenCustomerSpend;
    static private TimeSpan _allTimeSpan;
    public string Name { get; }

    public CashRegister(string name, TimeSpan itemSpend, TimeSpan betweenCustomerSpend)
    {
        Name = name;
        _queueCheckout = new Queue<Customer>();
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

    void Process(Customer c)
    {
        for (int i = 0; i < c.GoodsNumInCart; ++i)
            Thread.Sleep(_itemSpend);
        Thread.Sleep(_betweenCustomerSpend);
    }
}