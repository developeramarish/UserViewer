using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UserViewer.Common.Utilities
{
  public static class Utilities
  {
    public static async Task<string> LoadFile(string key, Type type)
    {
      Assembly assembly = type.Assembly;
      string filePath = LoadConfig(key);
      string fullFilePath = $"{assembly.Location.Remove(assembly.Location.IndexOf(assembly.ManifestModule.Name))}{filePath}";
      using (var reader = new StreamReader(fullFilePath))
      {
        return await reader.ReadToEndAsync();
      }
    }

    public static string LoadConfig(string key)
    {
      return new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build()
        .GetValue<string>(key);
    }

    public static int Count<T>()
    {
      Type type = typeof(T);
      return type
        .GetProperties()
        .Where(p => p.GetCustomAttributes(typeof(TestPropertyAttribute), false).Count() == 1)
        .Count();
    }
  }
}
