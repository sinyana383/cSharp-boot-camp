using System.Security.Cryptography;

namespace day00;

public class Customer
{
    // static field
    static Random r = new Random();
    
    // auto-properties:
    public string Name { get; private set; }
    public int SerialNum { get; private set; }
    public int GoodsNumInCart { get; private set; }
    

    public Customer(string name, int serialNum)
    {
        Name = name;
        SerialNum = serialNum;
        GoodsNumInCart = 0;
    }
    
    public override string ToString()
    {
        return Name + ", customer #" + SerialNum;
    }
    public static bool operator ==(Customer a, Customer b) => a.Name == b.Name && a.SerialNum == b.SerialNum;
    public static bool operator !=(Customer a, Customer b) => a.Name != b.Name || a.SerialNum != b.SerialNum;

    public void FillCart(int cartCapacity)
    {
        if (cartCapacity < 1) return;
        
        GoodsNumInCart = r.Next() % cartCapacity + 1;
    }
}