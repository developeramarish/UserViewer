using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserViewer.API.Model;
using UserViewer.Common.Model;

namespace UserViewer.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserProvider userProvider;

    public UserController(IUserProvider userProvider)
    {
      this.userProvider = userProvider;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
      return userProvider.GetUsers();
    }

    [HttpGet("{id}")]
    public User GetUser(int id)
    {
      return userProvider.GetUsers().FirstOrDefault(e => e.Id == id);
    }
  }
}