using System;
using System.Linq;
using UserViewer.Common.Model;

namespace UserViewer.Common.Utilities
{
  public class PropertyCounter<T> where T : User
  {
    public static int Count()
    {
      Type type = typeof(T);
      return type
        .GetProperties()
        .Where(p => p.GetCustomAttributes(typeof(TestPropertyAttribute), false).Count() == 1)
        .Count();
    }
  }
}
