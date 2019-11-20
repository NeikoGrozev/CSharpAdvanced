using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string investgatedClass)
    {
        Type classType = Type.GetType(investgatedClass);
        FieldInfo[] classField = classType.GetFields(
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static);
        MethodInfo[] classPrivateMethod = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.NonPublic);
        MethodInfo[] classPublicMetod = classType.GetMethods(
            BindingFlags.Instance |
            BindingFlags.Public);

        StringBuilder sb = new StringBuilder();
        
        foreach (var field in classField)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classPrivateMethod.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMetod.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }
}