using System.Collections;

namespace day03.Configuration.Sources;
using System.Text.Json;

public class JsonSource : IConfigurationSource
{
    private string _filePath;
    private Hashtable _hashtable;

    public JsonSource(string filePath)
    {
        _filePath = filePath;
        _hashtable = new Hashtable();
    }

    public void LoadData()
    {
        string jString = File.ReadAllText(_filePath);
        // !!! exception check

        
        Dictionary<string, object> dictionary = 
            JsonSerializer.Deserialize<Dictionary<string, object>>(jString);
        if (dictionary != null)
            _hashtable = new Hashtable(dictionary);
    }

    public Hashtable GetParameters() => _hashtable;
}