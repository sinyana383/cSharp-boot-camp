using day03.Configuration;
using day03.Configuration.Sources;

JsonSource jSource;
Configuration c;

if (args.Length < 1 || !File.Exists(args[0]))
    return ErrorMassage();

jSource = new JsonSource(args[0]);
jSource.LoadData();
c = new Configuration(jSource);

Console.WriteLine(c);

static int ErrorMassage()
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return -1;
}

return 1;