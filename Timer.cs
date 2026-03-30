using System.Diagnostics;

namespace Encryptor
{
  public static class Timer
  {
    public static TimeSpan MeasureTimeForAction(Action action)
    {
      var stopwatch = Stopwatch.StartNew();
      action();
      stopwatch.Stop();
      return stopwatch.Elapsed;
    }
  }
}