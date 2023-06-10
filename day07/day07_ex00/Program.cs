using System.Reflection;
using Microsoft.AspNetCore.Http;

// static and non-static for all

// full name of the type, the description of its Assembly and the name of its base type.
Console.WriteLine($"Type: {typeof(DefaultHttpContext)}");
Console.WriteLine($"Assembly: {Assembly.GetAssembly(typeof(DefaultHttpContext))}");
Console.WriteLine($"Based on: {typeof(DefaultHttpContext).BaseType}");
Console.WriteLine();

// public and non-public
// name and type name field in the FieldInfo list
Console.WriteLine("Fields:");
FieldInfo[] myFieldInfo;
myFieldInfo = typeof(DefaultHttpContext).GetFields(BindingFlags.Instance | BindingFlags.Static
                                                                         | BindingFlags.NonPublic | BindingFlags.Public);
for(int i = 0; i < myFieldInfo.Length; i++)
    Console.WriteLine($"{myFieldInfo[i].FieldType} {myFieldInfo[i].Name}");
Console.WriteLine();

// only public
// output the name and type name for each properties in the PropertyInfo list
Console.WriteLine("Properties:");
PropertyInfo [] myPropertyInfo;
myPropertyInfo = typeof(DefaultHttpContext).GetProperties(BindingFlags.Instance | BindingFlags.Static 
                                                                            | BindingFlags.Public);
for(int i = 0; i < myPropertyInfo.Length; i++)
    Console.WriteLine($"{myPropertyInfo[i].PropertyType} {myPropertyInfo[i].Name}");
Console.WriteLine();

// only public
// output the name and type name for each method in the MethodInfo list
// the name, the type returned by the method, and the method parameters
Console.WriteLine("Methods:");
MethodInfo [] myMethodInfo;
myMethodInfo = typeof(DefaultHttpContext).GetMethods(BindingFlags.Instance | BindingFlags.Static 
                                                                    | BindingFlags.Public);
for (int i = 0; i < myMethodInfo.Length; i++)
{
    Console.Write($"{myMethodInfo[i].ReturnType.Name} {myMethodInfo[i].Name} (");
    ParameterInfo[] myPinfo = myMethodInfo[i].GetParameters();
    for (int j = 0; j < myPinfo.Length; j++)
    {
        Console.Write($"{myPinfo[j].ParameterType.Name} {myPinfo[j].Name}");
        if (j < myPinfo.Length - 1)
            Console.WriteLine(", ");
    }
    Console.WriteLine(")");
}



