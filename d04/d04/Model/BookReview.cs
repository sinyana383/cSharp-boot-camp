namespace d04.Model;

public class BookReview : ISearchable
{
    // the title of the book, its author, description, place in the rating, its (rating) title,
    // link to a page in the store.
    private string title;
    private List<string> info;
    
    public string Title => title;

    // Глянь, что написал gpt 
    BookReview bookReview = JsonSerializer.Deserialize<BookReview>(json);
    
    public override string ToString()
    {
        return base.ToString();
    }
}