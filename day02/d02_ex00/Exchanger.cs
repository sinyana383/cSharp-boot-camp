using System.Collections;
using d02_ex00.Models;

namespace d02_ex00;

public class Exchanger
{
    public List<ExchangeRate> exchangeRates;

    public Exchanger() => exchangeRates = new List<ExchangeRate>();
    
    public static bool ParsingData(string ratesDirectory, out Exchanger ex)
    {
        ex = new Exchanger();
        if (!Directory.Exists(ratesDirectory))
            return false;
        
        var stockExchangerFiles = Directory.GetFiles(ratesDirectory);
        foreach (var file in stockExchangerFiles)
        {
            string[] strs = File.ReadAllLines(file);
            string name = Path.GetFileNameWithoutExtension(file);
            foreach (var str in strs)
            {
                ExchangeRate exRate;
                if (!ExchangeRate.ParsingData(name + "->" + str, out exRate))
                    return false;
                ex.exchangeRates.Add(exRate);
            }
        }
        return true;
    }
    
    public List<ExchangeSum> Convert(ExchangeSum originalSum)
    {
        List<ExchangeSum> convertedList = new List<ExchangeSum>();
        List<ExchangeRate> rates = exchangeRates
            .Where(r => r.currencyFrom == originalSum.identifier).ToList();
        foreach (var r in rates)
        {
            convertedList.Add(new ExchangeSum(
                r.currencyTo, 
                originalSum.amount * r.exchangeRate));
        }

        return convertedList;
    }
}