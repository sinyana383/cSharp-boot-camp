using System.Globalization;

namespace d02_ex00.Models;

public struct ExchangeRate
{
    public string currencyFrom;
    public string currencyTo;
    public double exchangeRate;

    // data ex: "currencyFrom-currencyTo: exchangeRate"
    public static bool ParsingData(string? data, out ExchangeRate exRate)
    {
        exRate = new ExchangeRate();
        if (data == null)
            return false;
        
        var whitespaceChars = data.Where(char.IsWhiteSpace);
        string sep = " " + string.Join("", data.Where(c=> char.IsWhiteSpace(c) 
                                    || (!char.IsDigit(c) && !char.IsLetter(c) && c != '.')));
        string[] strs = data.Split(sep.ToCharArray());
        string[] result = strs.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        if (result.Length != 3)
            return false;
        
        if (!double.TryParse(result[2], out exRate.exchangeRate))
            return false;
        exRate.currencyFrom = result[0];
        exRate.currencyTo = result[1];
        return true;
    }

    public override string ToString()
    {
        return $"{currencyFrom} - {currencyTo}: " +
               $"{exchangeRate.ToString("N2", new CultureInfo("en-GB"))}";
    }
}