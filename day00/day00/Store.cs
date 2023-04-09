namespace day00;

public class Store
{
    public Storage Storage { get; }
    private HashSet<CashRegister> _registersSet;

    public IEnumerable<CashRegister> RegistersSet => _registersSet;

    public Store(int storageCapacity, int numberOfRegisters)
    {
        Storage = new Storage(storageCapacity);
        _registersSet = new HashSet<CashRegister>(numberOfRegisters);
        for (var i = 1; i <= numberOfRegisters; ++i)
            _registersSet.Add(new CashRegister('#' + i.ToString()));
    }

    public bool IsOpen() => !Storage.IsEmpty;
    public CashRegister GetCashRegister(string name) => _registersSet.FirstOrDefault(n => n.Name == name);
    public int GetRegisterAmount() => _registersSet.Count;
}