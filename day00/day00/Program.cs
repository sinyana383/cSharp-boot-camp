using day00;

/*
 * auto-properties, static fields, lambda operators
 * top-level-statements, override the ToString()
 */

/* ex00 */

/*var s = new Storage(10, 4);
 s.GoodsNum = 10;
 Console.WriteLine(s.GoodsNum);*/

/* ex01 */

/*var customer1 = new Customer("Andrew", 1);
var customer2 = new Customer("Andrew", 1);

Console.WriteLine(customer1);
Console.WriteLine(customer2);
if (customer1 == customer2)
    Console.WriteLine(customer1 == customer2);*/


/* ex02 */

/*var customer3 = new Customer("Ergan", 1);
var customer4 = new Customer("Natasha", 2);
var customer5 = new Customer("Povar", 3);

customer3.FillCart(15);
customer4.FillCart(15);
customer5.FillCart(15);

Console.WriteLine(customer3 + " (" + customer3.GoodsNumInCart + " items in cart)");
Console.WriteLine(customer4 + " (" + customer4.GoodsNumInCart + " items in cart)");
Console.WriteLine(customer5 + " (" + customer5.GoodsNumInCart + " items in cart)");*/


/* ex03 */

/*var customer32 = new Customer("Ergan", 1);
var customer42 = new Customer("Natasha", 2);
var customer52 = new Customer("Povar", 3);

customer32.FillCart(15);
customer42.FillCart(15);
customer52.FillCart(15);

var сashRegister1 = new CashRegister("#1");
var сashRegister12 = new CashRegister("#1");
var сashRegister2 = new CashRegister("#2");

сashRegister1.AddCustomerToCheckout(customer32);
сashRegister1.AddCustomerToCheckout(customer42);
сashRegister2.AddCustomerToCheckout(customer52);

Console.WriteLine(сashRegister1 + " " + сashRegister1.GetCustomerNumberAtCheckout().ToString());
Console.WriteLine(сashRegister2 + " " + сashRegister2.GetCustomerNumberAtCheckout().ToString());
Console.WriteLine(сashRegister1 == сashRegister12);*/

/* ex04 */

/*Store a = new Store(15,10);
Console.WriteLine(a.IsOpen());*/

/* ex05 */

/*var r = new Random();
Store a = new Store(160,4);

for (int i = 1; i <= a.GetRegisterAmount(); ++i)
{
    CashRegister cashI = a.GetCashRegister('#' + i.ToString());
    int nb = r.Next(1, 4);
    for (int p = 1; p <= nb; p++)
    {
        var customer = new Customer("noname" + i, p);
        customer.FillCart(16, a.Storage);
        cashI.AddCustomerToCheckout(customer);
        Console.WriteLine(customer + " (" + customer.GoodsNumInCart + " items in cart)");
    }
    Console.WriteLine("In sum, " + cashI.GetCustomerNumberAtCheckout() + " customers on " + cashI + " register "
                      + "with " + cashI.GetGoodsNumberFromAllCustomers() + " goods\n" );
}

Console.WriteLine("The Least Customer Number on " + CustomerExtensions.LeastCustomerNumber(a.RegistersSet));
Console.WriteLine("The Least Goods Number on " + CustomerExtensions.LeastGoodsNumber(a.RegistersSet));*/

/* ex06 */

/*var s06 = new Store(40, 3);

var cHS06 = new HashSet<Customer>(10);
for (int i = 1; i <= 10; ++i)
    cHS06.Add(new Customer("Noname", i));
    
while (s06.IsOpen() && cHS06.Count > 0)
{
    var c06 = cHS06.FirstOrDefault();
    cHS06.Remove(c06);
    c06.FillCart(7, s06.Storage);
    if (s06.Storage.IsEmpty)
    {
        Console.WriteLine($"{c06} ({c06.GoodsNumInCart} items left in cart)");
        var tempReg06 = CustomerExtensions.LeastCustomerNumber(s06.RegistersSet);
        Console.WriteLine($"{c06} ({c06.GoodsNumInCart} items left in cart) – {tempReg06}" +
                          $" ({tempReg06.GetCustomerNumberAtCheckout()} people with " +
                          $"{tempReg06.GetGoodsNumberFromAllCustomers()} items behind)");
        tempReg06 = CustomerExtensions.LeastGoodsNumber(s06.RegistersSet);
        Console.WriteLine($"{c06} ({c06.GoodsNumInCart} items left in cart) – {tempReg06}" +
                          $" ({tempReg06.GetCustomerNumberAtCheckout()} people with " +
                          $"{tempReg06.GetGoodsNumberFromAllCustomers()} items behind)");
    }
    
    var reg06 = CustomerExtensions.LeastCustomerNumber(s06.RegistersSet);
    reg06.AddCustomerToCheckout(c06);
}*/