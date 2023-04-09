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
    public bool IsEmpty => _goodsNum <= 0;
    public int TakeGoods(int num)
    {
        if (num > GoodsNum)
            num = GoodsNum;

        GoodsNum -= num;
        return num;
    }
}