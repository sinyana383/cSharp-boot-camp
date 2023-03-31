namespace day00;

public class Storage
{
    private int _capacity;
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

    public int GoodsNum
    {
        get => _goodsNum;
        set { if (value > 0 && value <= _capacity) _goodsNum = value; }
    }

    // ??? which will return information about the goods that are out of stock
    // lambda operator '=>'
    public int IsEmpty => _capacity - _goodsNum;
}