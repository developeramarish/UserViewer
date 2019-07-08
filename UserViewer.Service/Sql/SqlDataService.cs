using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.Sql
{
  public class SqlDataService : IDataService
  {
    private const string ENV_VARIABLE_CONNECTION = "Connection";
    private DbContextOptions<UserContext> options;
    public SqlDataService()
    {
      IInfoLoader envVariableLoader = new EnvVariableLoader { Name = ENV_VARIABLE_CONNECTION, Type = GetType() };
      var envVariable = envVariableLoader.Load();

      var builder = new DbContextOptionsBuilder<UserContext>();
      builder.UseSqlite(envVariable);
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
