using System.Diagnostics;


namespace BusinessLayer
{
  /// <summary>
  /// ILogger interface defines operation for logging.
  /// </summary>
  public interface ILogger
  {
    void Log(string error);
  }


  /* TEMPORARY COMMENT- For now just keeping DebugLogger class for debugging purpose. More specific logger
   classes can be added as per need. */


  /// <summary>
  /// DebugLogger class- it writes log message to debug window used for debugging.
  /// </summary>
  public class DebugLogger : ILogger
  {
    public void Log(string error) {
      //As these are debug error messages to write to trace listeners. So, not using localization and keeping it in English only.
      Debug.WriteLine(error);
    }
  }

}
