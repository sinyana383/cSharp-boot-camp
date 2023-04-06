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

// Store a = new Store(15,10);
// Console.WriteLine(a.IsOpen());

/* ex05 */