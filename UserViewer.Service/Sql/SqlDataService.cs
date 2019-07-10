using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.Sql
{
  public class SqlDataService : IDataService
  {
    private DbContextOptions<UserContext> options;
    public SqlDataService()
    {
      string key = $"{GetType().Name}.Connection";
      string connection = Utilities.LoadConfig(key);

      var builder = new DbContextOptionsBuilder<UserContext>();
      builder.UseSqlite(connection);
      options = builder.Options;
    }
    public async Task<User> GetUser(int id)
    {
      using (var context = new UserContext(options))
      {
        return await context.Users.SingleAsync(e => e.Id == id);
      }
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      using (var context = new UserContext(options))
      {
        return await context.Users.ToListAsync();
      }
    }
  }
}
