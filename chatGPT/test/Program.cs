using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string url = "https://api.openai.com/v1/chat/completions";
        string openaiApiKey = "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";

        using (var client = new HttpClient())
        {
            // Create the request body
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = "response something" }
                },
                temperature = 0.7
            };
            string json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Set the Authorization header
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {openaiApiKey}");

            // Send the POST request
            var response = await client.PostAsync(url, content);

            // Handle the response
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}