using Microsoft.EntityFrameworkCore;
using UserViewer.Common.Model;

namespace UserViewer.Service.Sql
{
  public class UserContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public UserContext(DbContextOptions<UserContext> options) : base(options) 
    {

    }
  }
}
