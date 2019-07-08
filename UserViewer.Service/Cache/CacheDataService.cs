using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.Cache
{
  public class CacheDataService : IDataService
  {
    private const string ENV_VARIABLE_CACHE_DURATION = "CacheDuration";
    private readonly IDataService dataService;
    private MemoryCacher<User> cache;

    public CacheDataService(IDataService dataService)
    {
      cache = new MemoryCacher<User>(GetCacheDuration());
      this.dataService = dataService;
    }
    public async Task<User> GetUser(int id)
    {
      var users = await ValidateCache();
      return users.FirstOrDefault(e => e.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      return await ValidateCache();
    }

    private TimeSpan GetCacheDuration()
    {
      IInfoLoader envVariableLoader = new EnvVariableLoader { Name = ENV_VARIABLE_CACHE_DURATION, Type = GetType() };
      var variable = envVariableLoader.Load();
      var times = variable.Split(':');
      return new TimeSpan(int.Parse(times[0]), int.Parse(times[1]), int.Parse(times[2]));
    }

    private async Task<IEnumerable<User>> ValidateCache()
    {
      IEnumerable<User> users = cache.Get(nameof(User));
      if (users == null)
      {
        try
        {
          users = await dataService.GetUsers();
          cache.Add(nameof(User), users);
        }
        catch (Exception)
        {
          users = new List<User>
          {
            new User { Id=0, FirstName="No", LastName="Data"}
          };
        }
      }

      return users;
    }

  }
}
