using System.Text.Json;
using d04.Model;

List<BookReview> bookReviews = new List<BookReview>();

string json = File.ReadAllText("book_reviews.json");

var jsonObject = JsonDocument.Parse(json).RootElement;
var jasonArray = jsonObject.GetProperty("results");

foreach (var element in jasonArray.EnumerateArray())
{
    bookReviews.Add(JsonSerializer.Deserialize<BookReview>(element));
}

foreach (var rBook in bookReviews)
{
    Console.WriteLine(rBook);
}