using System;

namespace UserViewer.Common.Utilities
{
  public class EnvVariableLoader : IInfoLoader
  {
    public string Name { get; set; }
    public Type Type { get; set; }
    public string Load()
    {
      var variable = $"{Type.Assembly.GetName().Name}.{Type.Name}.{Name}";
      return Environment.GetEnvironmentVariable(variable);
    }
  }
}
