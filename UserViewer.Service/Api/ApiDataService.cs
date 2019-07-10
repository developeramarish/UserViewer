using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.Api
{
  public class ApiDataService : IDataService
  {
    private readonly string url;
    public ApiDataService()
    {
      string key = $"{this.GetType().Name}.Url";
      url = Utilities.LoadConfig(key);
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
      return await url.GetJsonAsync<IEnumerable<User>>();
    }
    public async Task<User> GetUser(int id)
    {
      return await $"{url}/{id}".GetJsonAsync<User>();
    }
  }
}
