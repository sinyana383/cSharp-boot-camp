namespace day00;

public class Store
{
    private Storage _storage;
    private HashSet<CashRegister> _registersSet;

    public Store(int capacity, int numberOfRegisters)
    {
        _storage = new Storage(capacity);
        _registersSet = new HashSet<CashRegister>(numberOfRegisters);
        for (var i = 0; i < numberOfRegisters; ++i)
            _registersSet.Add(new CashRegister('#' + i.ToString()));
    }

    public bool IsOpen() => !_storage.IsEmpty;
}