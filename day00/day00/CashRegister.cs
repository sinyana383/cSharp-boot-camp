namespace day00;

public class CashRegister
{
    public string Name { get; private set; }
    // is it necessary to encapsulate this property?
    private Queue<Customer> _queueCheckout;

    public CashRegister(string name)
    {
        Name = name;
        _queueCheckout = new Queue<Customer>();
    }

    public override string ToString() => "Register" + ' ' + Name;
    public static bool operator ==(CashRegister a, CashRegister b) => a.Name == b.Name;
    public static bool operator !=(CashRegister a, CashRegister b) => a.Name != b.Name;

    public void AddCustomerToCheckout(Customer c) => _queueCheckout.Enqueue(c);

    public int GetGoodsNumberFromAllCustomers()
    {
        int res = 0;
        var qEnum = _queueCheckout.GetEnumerator();
        while (qEnum.MoveNext())
            res += qEnum.Current.GoodsNumInCart;
        return res;
    }

    public int GetCustomerNumberAtCheckout() => _queueCheckout.ToArray().Length;
}