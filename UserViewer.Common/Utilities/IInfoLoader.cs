using System;

namespace UserViewer.Common.Utilities
{
  public interface IInfoLoader
  {
    string Name { get; set; }
    Type Type { get; set; }
    string Load();
  }
}
