/*using Newtonsoft.Json;

var r = new StreamReader("/Users/ddurrand/Desktop/c-/day01/day01/appsettings.json");

var json = r.ReadToEnd();
var items = JsonConvert.DeserializeObject<Dictionary<string, Int64>>(json);

foreach (var i in items)
{
    Console.WriteLine(i.Value);
}
Console.WriteLine("THE END");*/

using day00;

var s = new Store(100, 10);
