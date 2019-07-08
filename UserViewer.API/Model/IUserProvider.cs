using System.Collections.Generic;
using UserViewer.Common.Model;

namespace UserViewer.API.Model
{
  public interface IUserProvider
  {
    List<User> GetUsers();
  }
}
