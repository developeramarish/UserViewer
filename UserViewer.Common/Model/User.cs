using UserViewer.Common.Utilities;

namespace UserViewer.Common.Model
{
  public class User
  {
    [TestProperty]
    public int Id { get; set; }
    [TestProperty]
    public string FirstName { get; set; }
    [TestProperty]
    public string LastName { get; set; }
    public string FullName { get { return $"{FirstName} {LastName}"; } }
  }
}
