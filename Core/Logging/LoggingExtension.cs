using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Serilog;

public static class LoggerExtensions
{
    public static void LogWarning(this ILogger logger, Exception ex, string message, [CallerMemberName] string callerName = "")
    {
        logger.Warning(ex, $"Method: {callerName} - {message}");
    }
    public static void LogDetailedException(this ILogger logger, Exception ex, string customMessage = "", object parameter = null,
       [CallerMemberName] string memberName = "",
       [CallerFilePath] string filePath = "",
       [CallerLineNumber] int lineNumber = 0)
    {
        var logMessage = $"{customMessage} \n" +
                         $"Exception: {ex.Message} \n" +
                         $"Method: {memberName} \n" +
                         $"File: {filePath} \n" +
                         $"Line: {lineNumber} \n" +
                         $"Parameter : {JsonConvert.SerializeObject(parameter)}";

        logger.Warning(logMessage);
    }

    public static void LogDetailed(this ILogger logger, string customMessage = "", object parameter = null,
      [CallerMemberName] string memberName = "",
      [CallerFilePath] string filePath = "",
      [CallerLineNumber] int lineNumber = 0)
    {
        var logMessage = $"{customMessage} \n" +
                         $"Method: {memberName} \n" +
                         $"File: {filePath} \n" +
                         $"Line: {lineNumber} \n" +
                         $"Parameter : {JsonConvert.SerializeObject(parameter)}";

        logger.Warning(logMessage);
    }
}