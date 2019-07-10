using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.Csv
{
  public class CsvDataService : IDataService
  {
    public async Task<User> GetUser(int id)
    {
      var users = await GetUsers();
      return users.FirstOrDefault(e => e.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      var data = await GetFileData();
      return data
          .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
          .Select(line => ParseLineToUser(line))
          .Where(e => e != null);
    }

    private User ParseLineToUser(string line)
    {
      string[] segments = line.Split(',');
      return segments.Length == Utilities.Count<User>() ?
        new User
        {
          Id = int.Parse(segments[0]),
          FirstName = segments[1],
          LastName = segments[2]
        }
        : null;
    }

    protected virtual async Task<string> GetFileData()
    {
      Type type = GetType();
      return await Utilities.LoadFile($"{type.Name}.FilePath", type);
    }

  }
}
