using Xunit;

using Markdown.Generator.Core.Markdown.Elements;
namespace Markdown.Generator.Core.Tests;

public class MarkdownableTypeTests
{
    public class Sut
    {
        public void PublicMethod(){ }
        private void PrivateMethod(){ }
    }
    
}