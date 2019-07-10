using System.Threading.Tasks;
using UserViewer.Service.Csv;

namespace UserViewer.Service.CSV.Tests
{
  public class FakeCsvDataService : CsvDataService
  {
    private string testDataName;
    public FakeCsvDataService(string testDataName)
    {
      this.testDataName = testDataName;
    }
    protected override async Task<string> GetFileData()
    {
      return await Task.Run(() =>
      {
        switch (testDataName)
        {
          case nameof(TestData.GoodRecordsOnly):
            return TestData.GoodRecordsOnly;
          case nameof(TestData.BadRecordsOnly):
            return TestData.BadRecordsOnly;
          case nameof(TestData.GoodAndBadRecords):
            return TestData.GoodAndBadRecords;
          case "Empty":
            return string.Empty;
          default:
            return TestData.GoodRecordsOnly;
        }
      });
    }
  }
}
