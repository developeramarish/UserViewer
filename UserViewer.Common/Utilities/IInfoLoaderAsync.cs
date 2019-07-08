using System;
using System.Threading.Tasks;

namespace UserViewer.Common.Utilities
{
  public interface IInfoLoaderAsync
  {
    string Name { get; set; }
    Type Type { get; set; }
    Task<string> Load();
  }
}
