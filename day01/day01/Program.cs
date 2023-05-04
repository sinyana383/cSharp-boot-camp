

using day00;

const int custNum = 10;
const int storCap = 50;
const int regNum = 4;
const int cartCap = 7;

var s06 = new Store(storCap, regNum);
var cHS06 = new HashSet<Customer>(custNum);
int custIn = 1;
for (custIn = 1; custIn <= custNum; ++custIn)
    cHS06.Add(new Customer("Noname", custIn));

int threadCount = custNum;
ManualResetEvent allThreadsComplete = new ManualResetEvent(false);

Parallel.ForEach(cHS06, customer =>
{
    var th = new Thread(() => customer.FillCartAndStandInCheckout(cartCap, s06, ref threadCount, allThreadsComplete));
    th.Start();
});

allThreadsComplete.WaitOne();

var cashThreads = s06.OpenRegisters();

var timer = new System.Timers.Timer(7000);
        
// Hook up the Elapsed event handler
timer.Elapsed += TimerElapsed;
        
// Start the timer
timer.Start();

foreach (Thread th in cashThreads)
    th.Join();