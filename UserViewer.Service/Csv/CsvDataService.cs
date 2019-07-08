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
    public IInfoLoaderAsync FileLoader { get; set; }
    private const string ENV_VARIABLE_FILE_PATH = "FilePath";

    public CsvDataService()
    {
      FileLoader = new FileLoader { Type = GetType(), Name = ENV_VARIABLE_FILE_PATH };
    }

    public async Task<User> GetUser(int id)
    {
      var users = await GetUsers();
      return users.FirstOrDefault(e => e.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      string fileData = await FileLoader.Load();
      return
        fileData
          .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
          .Select(line => ParseLineToUser(line))
          .Where(e => e != null);
    }

    private User ParseLineToUser(string line)
    {
      string[] segments = line.Split(',');
      return segments.Length == PropertyCounter<User>.Count() ?
        new User
        {
          Id = int.Parse(segments[0]),
          FirstName = segments[1],
          LastName = segments[2]
        }
        : null;
    }

  }
}
