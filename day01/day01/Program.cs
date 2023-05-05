using day00;

const int custNum = 10;
const int storCap = 50;
const int regNum = 4;
const int cartCap = 7;

// Store
var s06 = new Store(storCap, regNum, cartCap);
// Console.WriteLine("press Q for: Customers always choose the shortest queue\n" +
//                   "press G for: Customers choose the queue with the least number of goods");
// if (Console.ReadKey().Key == ConsoleKey.Q)
//     s06.StoreMode = Store.Mode.ShortestQueue;
// else
    s06.StoreMode = Store.Mode.ShortestQueue;

// Customers
var cHS06 = new HashSet<Customer>(custNum);
int custIn = 1;
for (custIn = 1; custIn <= custNum; ++custIn)
    cHS06.Add(new Customer("Noname", custIn));

// Threads and Events
int threadCount = custNum;
ManualResetEvent allThreadsComplete = new ManualResetEvent(false);

Parallel.ForEach(cHS06, customer =>
{
    var th = new Thread(() => customer.ThreadProcess(cartCap, s06, ref threadCount, allThreadsComplete));
    th.Start();
});
allThreadsComplete.WaitOne();
var cashThreads = s06.OpenRegisters();

// Timer
var timer = new System.Timers.Timer(7000);
timer.Elapsed += s06.AddNewCustomerEvery7Seconds;
timer.Start();

// End threads
foreach (Thread th in cashThreads)
    th.Join();
timer.Stop();