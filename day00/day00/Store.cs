namespace day00;

public class Store
{
    public Storage Storage { get; private set; }
    public HashSet<CashRegister> RegistersSet { get; private set; }

    public Store(int storageCapacity, int numberOfRegisters)
    {
        Storage = new Storage(storageCapacity);
        RegistersSet = new HashSet<CashRegister>(numberOfRegisters);
        for (var i = 1; i <= numberOfRegisters; ++i)
            RegistersSet.Add(new CashRegister('#' + i.ToString()));
    }

    public bool IsOpen() => !Storage.IsEmpty;
    public CashRegister GetCashRegister(string name) => RegistersSet.FirstOrDefault(n => n.Name == name);
    public int GetRegisterAmount() => RegistersSet.Count;
}