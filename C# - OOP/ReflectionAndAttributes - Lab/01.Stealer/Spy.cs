using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealedFieldInfo(string investigatedClass, params string[] requeatedFields)
        {
            Type type = Type.GetType(investigatedClass);

            FieldInfo[] fieldInfos = type.GetFields((BindingFlags)60);

            StringBuilder sb = new StringBuilder();

            //Hacker hacker = new Hacker();

            //Object hackerInstamce = Activator.CreateInstance(typeof(Hacker));

            Object hackerInstamce = Activator.CreateInstance(type, new object[] {});

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (var fieldInfo in fieldInfos.Where(f => requeatedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(hackerInstamce)}");
            }

            return sb.ToString().TrimEnd();

        }

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type type = Type.GetType(investigatedClass);

            FieldInfo[] fieldeInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] publicMethodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);


            StringBuilder sb = new();

            foreach(var fieldInfo in fieldeInfos)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }
            foreach(var nonPublicMethodInfo in nonPublicMethodInfos.Where(p => p.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethodInfo.Name} have to be public!");
            }
            foreach(var publicMethodInfo in publicMethodInfos.Where(p => p.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethodInfo.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string investigatedClass)
        {
            Type type = Type.GetType(investigatedClass);

            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new();

            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach(var method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd() ;
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type type = Type.GetType(investigatedClass);

            MethodInfo[] classMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new();

            foreach (var method in classMethods.Where(m=> m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
