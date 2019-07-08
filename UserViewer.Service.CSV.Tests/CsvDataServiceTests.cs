using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using UserViewer.Service.Csv;

namespace UserViewer.Service.CSV.Tests
{
  [TestClass]
  public class CsvDataServiceTests
  {
    [TestMethod]
    public async Task GetUsers_GoodRecordsOnly_ReturnsAllRecords()
    {
      // Arrange
      var fakeFileLoader = new FakeInfoLoader { Name = nameof(TestData.GoodRecordsOnly) };
      var dataService = new CsvDataService();
      dataService.FileLoader = fakeFileLoader;

      // Act
      var users = await dataService.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(2, users.Count());
    }

    [TestMethod]
    public async Task GetUsers_BadRecordsOnly_ReturnsEmptyList()
    {
      // Arrange
      var fakeFileLoader = new FakeInfoLoader { Name = nameof(TestData.BadRecordsOnly) };
      var dataService = new CsvDataService();
      dataService.FileLoader = fakeFileLoader;

      // Act
      var users = await dataService.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(0, users.Count());
    }

    [TestMethod]
    public async Task GetUsers_MixedRecords_ReturnsGoodRecords()
    {
      // Arrange
      var fakeFileLoader = new FakeInfoLoader { Name = nameof(TestData.GoodAndBadRecords) };
      var dataService = new CsvDataService();
      dataService.FileLoader = fakeFileLoader;

      // Act
      var users = await dataService.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(2, users.Count());
    }

    [TestMethod]
    public async Task GetUsers_EmptyFile_ReturnsEmptyList()
    {
      // Arrange
      var fakeFileLoader = new FakeInfoLoader { Name = "Empty" };
      var dataService = new CsvDataService();
      dataService.FileLoader = fakeFileLoader;

      // Act
      var users = await dataService.GetUsers();

      // Assert
      Assert.IsNotNull(users);
      Assert.AreEqual(0, users.Count());
    }
  }
}
