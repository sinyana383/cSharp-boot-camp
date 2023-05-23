using Xunit;

using Markdown.Generator.Core.Markdown.Elements;
namespace Markdown.Generator.Core.Tests;

public class ElementsTests
{
    [Fact]
    public void Given_Code_When_LanguageAndCodeAsParameter_Then_ReturnMarkdownCodeMarkup()
    {
        var expected = "csharp\\ some code\\";

        var c = new Code("csharp", "some code");
        string actual = c.Create();
        
        Assert.Equal(expected, actual);
    }
}