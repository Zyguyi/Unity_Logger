using System.IO;
using System.Reflection;
using UnityEngine;

public static class Logger
{
    public enum LogLevel
{
    None,
    Error,
    Warning,
    Info
}
    private static StreamWriter logWriter;
    private static string logFilePath;
    public static LogLevel CurrentLogLevel = LogLevel.Info;
    static Logger()
    {
        string startTime = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"Log_{startTime}.txt";
        logFilePath = Path.Combine(Application.persistentDataPath, fileName);
        
        // 确保文件被创建，并准备写入
        logWriter = new StreamWriter(logFilePath, true);
        logWriter.AutoFlush = true;
    }

    public static void Log(string message)
    {
        string formattedMessage = FormatMessage("INFO", message);
        if (CurrentLogLevel >= LogLevel.Info)
        {
            WriteToFile(formattedMessage);
        }
        Debug.Log($"<color=green>{formattedMessage}</color>");  // 输出到Unity控制台
    }

    public static void LogWarning(string message)
    {
        string formattedMessage = FormatMessage("WARNING", message);
        if (CurrentLogLevel >= LogLevel.Warning)
        {
            WriteToFile(formattedMessage);
        }    
        Debug.LogWarning($"<color=yellow>{formattedMessage}</color>");  // 输出到Unity控制台
    }

    public static void LogError(string message)
    {
        string formattedMessage = FormatMessage("ERROR", message);
        if (CurrentLogLevel >= LogLevel.Error)
            WriteToFile(formattedMessage);
        Debug.LogError($"<color=red>{formattedMessage}</color>");  // 输出到Unity控制台
    }

    private static string FormatMessage(string type, string message)
    {
        var method = MethodBase.GetCurrentMethod();
        var declaringType = method.DeclaringType.Name;
        var methodName = method.Name;

        // 获取调用者信息，即前一个堆栈帧
        var stackFrame = new System.Diagnostics.StackTrace().GetFrame(2);
        if (stackFrame != null)
        {
            method = stackFrame.GetMethod();
            declaringType = method.DeclaringType.Name;
            methodName = method.Name;
        }

        return $"[{System.DateTime.Now:HH:mm:ss.fff}] [{type}] {declaringType}.{methodName} - {message}";
    }

    private static void WriteToFile(string message)
    {
        if (logWriter != null)
        {
            logWriter.WriteLine(message);
        }
        else
        {
            Debug.LogError("Log file writer is not initialized!");
        }
    }

    // Call this method to properly close the StreamWriter when the application exits
    public static void CloseLog()
    {
        if (logWriter != null)
        {
            logWriter.Close();
        }
    }
}
