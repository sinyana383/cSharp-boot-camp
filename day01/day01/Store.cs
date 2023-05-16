using System.Timers;

namespace day01;
using Newtonsoft.Json;

public class Store
{
    private static int s_cartCapasity = 10;
    private HashSet<CashRegister> _cashRegistersSet;
    
    // <!-- shows whether the customers enter the store, but don't choose the queue yet -->
    public bool IsSomeCustomerIn = false;
    // <!-- customer chose-register modes -->
    public enum Mode
    {
        ShortestQueue,
        LeastNumberOfGoods
    }
    public Mode StoreMode = Mode.ShortestQueue;
    public Storage Storage { get; }

    public IEnumerable<CashRegister> CashRegistersSet => _cashRegistersSet;
    public Store(int storageCapacity, int numberOfRegisters, int cartCapasity)
    {
        var r = new StreamReader("/Users/ddurrand/Desktop/c-/day01/day01/appsettings.json");
        var json = r.ReadToEnd();
        var items = JsonConvert.DeserializeObject<Dictionary<string, Int32>>(json);

        s_cartCapasity = cartCapasity;
        Storage = new Storage(storageCapacity);
        _cashRegistersSet = new HashSet<CashRegister>(numberOfRegisters);
        for (var i = 1; i <= numberOfRegisters; ++i)
        {
            _cashRegistersSet.Add(new CashRegister('#' + i.ToString(), new TimeSpan(0, 0, items["timePerItem"]),
                new TimeSpan(0, 0, items["timePerCustomer"])));
        }
    }
    public bool IsOpen() => !Storage.IsEmpty;
    public CashRegister GetCashRegister(string name) => _cashRegistersSet.FirstOrDefault(n => n.Name == name);
    public int GetCashRegisterAmount() => _cashRegistersSet.Count;
    public Thread[] OpenRegisters()
    {
        var cashThreads = new Thread[GetCashRegisterAmount()];
        var threadIndex = -1;
        foreach (CashRegister register in CashRegistersSet)
        {
            cashThreads[++threadIndex] = new Thread(() => register.Work(this));
            cashThreads[threadIndex].Start();
        }
        return cashThreads;
    }
    public void AddNewCustomerEvery7Seconds(object? sender, ElapsedEventArgs e)
    {
        if (!IsOpen()) return;
        IsSomeCustomerIn = true;
        Console.WriteLine("new Customer came");
        var cust = new Customer("SevenSecond", Customer.TotalAmount);
        
        cust.FillCartAndChooseRegister(s_cartCapasity, this, StoreMode);
        IsSomeCustomerIn = false;
    }
}