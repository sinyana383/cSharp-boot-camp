if(File.Exists("dictionary"))
    return ErrorMassage("Dictionary file not found");
string[] names = File.ReadLines("dictionary").ToArray();
for (int i = 0; i < names.Length; ++i)
    names[i] = names[i].Trim();

Console.WriteLine(">Enter name:");
string? input = Console.ReadLine();
if (input == null || !input.All(c => Char.IsLetter(c) || c == '-' || c == ' '))
    return ErrorMassage("Your name was not found");
input = input.Trim();


return 1;
int ErrorMassage(string message)
{
    Console.WriteLine(message);
    return -1;
}

int LevenshteinDistance(string s1, string s2)
{
    if (s1.Length == 0)
        return s2.Length;
    if (s2.Length == 0)
        return s1.Length;
    
    int[,] array = new int[s1.Length + 1, s2.Length + 1];
    int add;
    
    for (int c = 0; c < s2.Length + 1; c++)
        array[0, c] = c;
    for (int r = 0; r < s1.Length + 1; r++)
        array[r, 0] = r;

    for (int i = 1; i < s1.Length + 1; i++)
    {
        for (int j = 1; j < s2.Length + 1; j++)
        {
            add = s1.ToCharArray()[i - 1] != s2.ToCharArray()[j - 1] ? 1 : 0;
            
            array[i, j] = Min(array[i - 1, j] + 1, array[i, j - 1] + 1
                , array[i - 1, j - 1] + add);
        }
    }

    return array[s1.Length, s2.Length];
}

int Min(int a, int b, int c)
{
    int min = a;

    if (min > b)
        min = b;
    if (min > c)
        min = c;

    return min;
}

int MinDistance(string word1, string word2) {
    if (word1.Length == 0)
        return word2.Length;
    if (word2.Length == 0)
        return word1.Length;
    
    int[,] array = new int[word1.Length + 1, word2.Length + 1];
    int add;
    
    for (int c = 0; c < word1.Length + 1; c++)
        array[0, c] = c;
    for (int r = 0; r < word2.Length + 1; r++)
        array[r, 0] = r;

    for (int i = 1; i < word1.Length; i++)
    {
        for (int j = 1; j < word2.Length; j++)
        {
            add = word1.ToCharArray()[i - 1] != word2.ToCharArray()[j - 1] ? 1 : 0;
            
            array[i, j] = Min(array[i - 1, j], array[i, j - 1]
                , array[i - 1, j - 1] + add);
        }
    }

    return array[word1.Length, word2.Length];    
}