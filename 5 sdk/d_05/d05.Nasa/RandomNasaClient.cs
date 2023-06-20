using System.Threading.Tasks;

namespace d05.Nasa
{
    public class RandomNasaClient : INasaClient<int, Task<string>>
    {
        public Task<string> GetAsync(string input)
        {
            
        }
    }
}