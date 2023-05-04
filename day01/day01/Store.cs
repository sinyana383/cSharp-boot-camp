namespace day00;
using Newtonsoft.Json;

public class Store
{
    public Storage Storage { get; }
    private HashSet<CashRegister> _registersSet;

    public IEnumerable<CashRegister> RegistersSet => _registersSet;

    public Store(int storageCapacity, int numberOfRegisters)
    {
        
        var r = new StreamReader("/Users/ddurrand/Desktop/c-/day01/day01/appsettings.json");
        var json = r.ReadToEnd();
        var items = JsonConvert.DeserializeObject<Dictionary<string, Int32>>(json);

        Storage = new Storage(storageCapacity);
        _registersSet = new HashSet<CashRegister>(numberOfRegisters);
        for (var i = 1; i <= numberOfRegisters; ++i)
            _registersSet.Add(new CashRegister('#' + i.ToString(), new TimeSpan(0, 0, items["_itemSpend"]),
                new TimeSpan(0, 0, items["_customerSpend"])));
    }

    public bool IsOpen() => !Storage.IsEmpty;
    public CashRegister GetCashRegister(string name) => _registersSet.FirstOrDefault(n => n.Name == name);
    public int GetRegisterAmount() => _registersSet.Count;

    public Thread[] OpenRegisters()
    {
        var cashThreads = new Thread[GetRegisterAmount()];
        int threadIndex = -1;
        foreach (CashRegister register in RegistersSet)
        {
            cashThreads[++threadIndex] = new Thread(() => register.Work(Storage));
            cashThreads[threadIndex].Start();
        }

        return cashThreads;
    }
}