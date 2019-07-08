using System;
using System.IO;
using System.Threading.Tasks;

namespace UserViewer.Common.Utilities
{
  public class FileLoader : IInfoLoaderAsync
  {
    public string Name { get; set; }
    public Type Type { get; set; }
    public async Task<string> Load()
    {
      using (var reader = new StreamReader(GetFilePath()))
      {
        return await reader.ReadToEndAsync();
      }
    }
    private string GetFilePath()
    {
      IInfoLoader envVariableLoader = new EnvVariableLoader { Name = Name, Type = Type };
      var envVariable = envVariableLoader.Load();
      var assembly = Type.Assembly;      
      return $"{assembly.Location.Remove(assembly.Location.IndexOf(assembly.ManifestModule.Name))}{envVariable}";
    }
  }
}
