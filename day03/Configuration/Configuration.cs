using System.Collections;
using System.Text;
using day03.Configuration.Sources;

namespace day03.Configuration;

// To process and store parameters
public class Configuration
{
    // a set of parameters necessary for the application to work
    private Hashtable _setOfParams;

    // accepts the IConfigurationSource collection of parameters
    // and the Params collection is filled with them
    public Configuration(IConfigurationSource source)
    {
        _setOfParams = source.GetParameters();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("Configuration\n");
        foreach (DictionaryEntry param in _setOfParams)
        {
            stringBuilder.Append($"{param.Key}: {param.Value}");
            stringBuilder.Append('\n');
        }

        return stringBuilder.ToString();
    }
}