namespace day00;

public class Storage
{
    private readonly int _capacity;
    private int _goodsNum;

    public Storage(int capacity, int goodsNum)
    {
        _capacity = capacity;
        _goodsNum = goodsNum;
    }
    public Storage(int capacity)
    {
        _capacity = capacity;
        _goodsNum = capacity;
    }
    
    public bool IsEmpty => _goodsNum <= 0;
    public int TakeGoods(int num)
    {
        if (num > _goodsNum)
            num = _goodsNum;

        Interlocked.Add(ref _goodsNum, -num);
        Console.WriteLine(_goodsNum + " goods left");
        return num;
    }
}