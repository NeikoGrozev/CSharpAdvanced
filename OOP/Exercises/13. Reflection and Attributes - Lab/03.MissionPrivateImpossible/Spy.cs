using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string investgatedClass)
    {
        Type classType = Type.GetType(investgatedClass);
        MethodInfo[] classPrivateMetod = classType.GetMethods(
           BindingFlags.Instance |
           BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investgatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classPrivateMetod)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().TrimEnd();
    }
}