using System.Globalization;

namespace d02_ex00.Models;

public struct ExchangeSum
{
    public string identifier;
    public double amount;

    public ExchangeSum(string identifier, double amount)
    {
        this.identifier = identifier;
        this.amount = amount;
    }

    public static bool ParsingData(string? data, out ExchangeSum exSum)
    {
        exSum = new ExchangeSum();

        if (data == null)
            return false;
        string[] strs = data.Split();
        if (strs.Length != 2)
            return false;
        
        if (!double.TryParse(strs[0], out exSum.amount))
            return false;
        exSum.identifier = strs[1];
        return true;
    }

    public override string ToString()
    {
        return $"{amount.ToString("N2", new CultureInfo("en-GB"))}" +
               $" {identifier}";
    }
}