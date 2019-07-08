using System.Collections.Generic;
using UserViewer.Common.Model;

namespace UserViewer.API.Model
{
  public class StaticUserProvider : IUserProvider
  {
    public List<User> GetUsers()
    {
      return new List<User>
      {
        new User() { Id=1, FirstName="John", LastName="Koenig" },
        new User() { Id=2, FirstName="Dylan", LastName="Hunt" },
        new User() { Id=3, FirstName="Leela", LastName="Turanga" },
        new User() { Id=4, FirstName="John", LastName="Crichton" },
        new User() { Id=5, FirstName="Dave", LastName="Lister" },
        new User() { Id=6, FirstName="Laura", LastName="Roslin" },
        new User() { Id=7, FirstName="John", LastName="Sheridan" },
        new User() { Id=8, FirstName="Dante", LastName="Montana" },
        new User() { Id=9, FirstName="Isaac", LastName="Gampu" },
      };
    }
  }
}
