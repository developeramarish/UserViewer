using System.Collections.Generic;
using System.Threading.Tasks;
using UserViewer.Common.Model;

namespace UserViewer.Service
{
  public interface IDataService
  {
    Task<User> GetUser(int id);
    Task<IEnumerable<User>> GetUsers();
  }
}