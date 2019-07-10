using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace UserViewer.Service.CSV.Tests
{
  [TestClass]
  public class CsvDataServiceTests
  {
    [TestMethod]
    public async Task GetUsers_GoodRecordsOnly_ReturnsAllRecords()
    {
      // Arrange
      var service = new FakeCsvDataService(nameof(TestData.GoodRecordsOnly));

      // Act
      var users = await service.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(2, users.Count());
    }

    [TestMethod]
    public async Task GetUsers_BadRecordsOnly_ReturnsEmptyList()
    {
      // Arrange
      var service = new FakeCsvDataService(nameof(TestData.BadRecordsOnly));

      // Act
      var users = await service.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(0, users.Count());
    }

    [TestMethod]
    public async Task GetUsers_MixedRecords_ReturnsGoodRecords()
    {
      // Arrange
      var service = new FakeCsvDataService(nameof(TestData.GoodAndBadRecords));

      // Act
      var users = await service.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(2, users.Count());
    }

    [TestMethod]
    public async Task GetUsers_EmptyFile_ReturnsEmptyList()
    {
      // Arrange
      var service = new FakeCsvDataService("Empty");

      // Act
      var users = await service.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(0, users.Count());
    }
  }
}
