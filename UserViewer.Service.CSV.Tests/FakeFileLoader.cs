using System;
using System.Threading.Tasks;
using UserViewer.Common.Utilities;

namespace UserViewer.Service.CSV.Tests
{
  public class FakeInfoLoader : IInfoLoaderAsync
  {
    public string Name { get; set; }
    public Type Type { get; set; }

    public Task<string> Load()
    {
      return Task.Run(() =>
      {
        switch (Name)
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
