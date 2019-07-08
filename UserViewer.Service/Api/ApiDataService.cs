using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.Api
{
  public class ApiDataService : IDataService
  {
    private const string ENV_VARIABLE_URL = "Url";
    private readonly string url;

    public ApiDataService()
    {
      IInfoLoader envVariableLoader = new EnvVariableLoader { Name = ENV_VARIABLE_URL, Type = GetType() };
      url = envVariableLoader.Load();
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
