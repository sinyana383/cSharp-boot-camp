namespace d05.Nasa
{
    public interface INasaClient<in TIn, out TOut> 
    {
        // data acquisition. Whatever we get from NASA, it will be responsible for this
        TOut GetAsync(TIn input);
    }
}