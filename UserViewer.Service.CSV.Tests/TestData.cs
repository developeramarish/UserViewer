using System;

namespace UserViewer.Service.CSV.Tests
{
  public class TestData
  {
    public static string GoodRecordsOnly =
      "1, John, Koenig" + Environment.NewLine
      + "2, Dylan, Hunt" + Environment.NewLine;

    public static string GoodAndBadRecords =
      "1, John, Koenig" + Environment.NewLine
      + "INVALID DATA" + Environment.NewLine
      + "2, Dylan, Hunt" + Environment.NewLine
      + "INVALID DATA" + Environment.NewLine;

    public static string BadRecordsOnly =
      "INVALID DATA" + Environment.NewLine
      + "MORE INVALID DATA" + Environment.NewLine;
  }
}
