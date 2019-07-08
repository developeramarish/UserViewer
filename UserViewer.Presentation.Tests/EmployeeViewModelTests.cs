using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace UserViewer.Presentation.Tests
{
  [TestClass]
  public class UserViewModelTests
  {
    [TestMethod]
    public async Task Users_AfterRefresh_IsPopulated()
    {
      // Arrange
      var dataService = new FakeDataService();
      var viewModel = new UserViewModel(dataService);

      // Act
      await viewModel.RefreshUsers();

      // Assert
      Assert.IsNotNull(viewModel.Users);
      Assert.AreEqual(2, viewModel.Users.Count());
    }

    public async Task Users_AfterClear_IsEmpty()
    {
      // Arrange
      var dataService = new FakeDataService();
      var viewModel = new UserViewModel(dataService);
      await viewModel.RefreshUsers();
      Assert.AreEqual(2, viewModel.Users.Count());

      // Act
      viewModel.ClearUsers();

      // Assert
      Assert.IsNotNull(viewModel.Users);
      Assert.AreEqual(0, viewModel.Users.Count());
    }
  }
}
