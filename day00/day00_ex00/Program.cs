using System.Globalization;

var curCult = new CultureInfo("en-GB");
double sum;
double rate;
int term;

//  Errors checks
if (args.Length < 3)
    return ErrorMassage();
if (!(double.TryParse(args[0], out sum) && double.TryParse(args[1], out rate) && int.TryParse(args[2], out term)))
    return ErrorMassage();
// rate == 0 if you borrow from friends or relatives :)
if (sum <= 0 || (rate < 0 || rate - 100.0d > 0) || (term < 1 || term > 12))
    return ErrorMassage();

var i = rate / (12 * 100);

// Console.WriteLine("| Payment no. | Payment date | Payment | Principal debt | Interest | Remaining debt |");


static int ErrorMassage()
{
    Console.WriteLine("Something went wrong. Check your input and retry.");
    return -1;
}

return 1; 


