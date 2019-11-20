using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investgatedClass, params string[] allFileds)
    {
        Type classType = Type.GetType(investgatedClass);
        FieldInfo[] classField = classType.GetFields(
            BindingFlags.Public | BindingFlags.Instance |
            BindingFlags.Static | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        Object obj = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {investgatedClass}");

        foreach (var field in classField.Where(x => allFileds.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(obj)}");
        }

        return sb.ToString().TrimEnd();
    }
}
