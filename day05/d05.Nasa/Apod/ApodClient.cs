using day05.Nasa.Apod.Models;

namespace day05.Nasa.Apod;

public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
{
     //Implement an HTTP GET request to the NASA API
     //using HttpClient and deserialize the response to the MediaOfToday list.
     public async Task<MediaOfToday[]> GetAsync(int N)
     {
          
     }
}