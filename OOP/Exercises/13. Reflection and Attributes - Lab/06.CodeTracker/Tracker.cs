
using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}