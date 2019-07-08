using System.Collections.Generic;
using System.Threading.Tasks;
using UserViewer.Common.Model;
using UserViewer.Service;

namespace UserViewer.Presentation
{
  public class UserViewModel : ViewModelBase
  {
    private IEnumerable<User> users;
    private IDataService dataService;
    public UserViewModel(IDataService dataService)
    {
      this.dataService = dataService;
    }

    public IEnumerable<User> Users
    {
      get { return users; }
      set
      {
        if (users == value)
        {
          return;
        }
        users = value;
        OnPropertyChanged();
      }
    }

    public async Task RefreshUsers()
    {
      Users = await dataService.GetUsers();
    }

    public void ClearUsers()
    {
      Users = new List<User>();
    }

    public string DataServiceType
    {
      get
      {
        return dataService.GetType().ToString();
      }
    }
  }
}
