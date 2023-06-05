using System.Globalization;
using d02_ex00;
using d02_ex00.Models;

var curCult = new CultureInfo("en-GB");
string filePath;
Exchanger exchanger;
ExchangeSum origSum;

//  Errors checks
if (args.Length < 2)
    return ErrorMassage();
if (!ExchangeSum.ParsingData(args[0], out origSum))
    return ErrorMassage();
if (!Exchanger.ParsingData(args[1], out exchanger))
    return ErrorMassage();

Console.WriteLine($"Amount in the original currency: {origSum.ToString()}");
foreach (var sums in exchanger.Convert(origSum))
    Console.WriteLine($"Amount in {sums.identifier}: {sums.ToString()}");

    static int ErrorMassage()
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return -1;
}

return 1; 