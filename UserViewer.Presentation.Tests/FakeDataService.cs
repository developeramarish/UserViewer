using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Service;

namespace UserViewer.Presentation.Tests
{
  class FakeDataService : IDataService
  {
    private IEnumerable<User> testData = new List<User>
    {
      new User { Id=1, FirstName="Janos", LastName="Nagy" },
      new User { Id=2, FirstName="Victor", LastName="Ortuondo" }
    };

    public Task<User> GetUser(int id)
    {
      return Task.Run(() => testData.FirstOrDefault(e => e.Id == id));
    }

    public Task<IEnumerable<User>> GetUsers()
    {
      return Task.Run(() => testData);
    }
  }
}
