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

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        var other = (Customer)obj;
        return this.Name == other.Name && this.SerialNum == other.SerialNum;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, SerialNum);
    }

    public void FillCart(int cartCapacity, Storage s)
    {
        if (cartCapacity < 1 || s.IsEmpty) return;
        
        GoodsNumInCart = s.TakeGoods(r.Next(1, cartCapacity + 1));
    }
}