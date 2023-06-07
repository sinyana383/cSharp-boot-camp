using System.Collections;

namespace day03.Configuration.Sources;

public interface IConfigurationSource
{
// loading data from the file
    public void LoadData();
    
// and have a method that returns a collection of parameters
    public Hashtable GetParameters();
}