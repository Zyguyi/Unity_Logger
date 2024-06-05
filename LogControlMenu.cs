using UnityEditor;
using UnityEngine;

public class LogControlMenu
{
    // 设置日志等级为 None
    [MenuItem("Tools/Set Log Level/None")]
    private static void SetLogLevelNone()
    {
        Logger.CurrentLogLevel = Logger.LogLevel.None;
        Logger.Log("Log level set to None");
    }

    [MenuItem("Tools/Set Log Level/None", true)]
    private static bool SetLogLevelNoneValidate()
    {
        Menu.SetChecked("Tools/Set Log Level/None", Logger.CurrentLogLevel == Logger.LogLevel.None);
        return true;
    }

    // 设置日志等级为 Error
    [MenuItem("Tools/Set Log Level/Error")]
    private static void SetLogLevelError()
    {
        Logger.CurrentLogLevel = Logger.LogLevel.Error;
        Logger.LogError("Log level set to Error");
    }

    [MenuItem("Tools/Set Log Level/Error", true)]
    private static bool SetLogLevelErrorValidate()
    {
        Menu.SetChecked("Tools/Set Log Level/Error", Logger.CurrentLogLevel == Logger.LogLevel.Error);
        return true;
    }

    // 设置日志等级为 Warning
    [MenuItem("Tools/Set Log Level/Warning")]
    private static void SetLogLevelWarning()
    {
        Logger.CurrentLogLevel = Logger.LogLevel.Warning;
        Logger.LogWarning("Log level set to Warning");
    }

    [MenuItem("Tools/Set Log Level/Warning", true)]
    private static bool SetLogLevelWarningValidate()
    {
        Menu.SetChecked("Tools/Set Log Level/Warning", Logger.CurrentLogLevel == Logger.LogLevel.Warning);
        return true;
    }

    // 设置日志等级为 Info
    [MenuItem("Tools/Set Log Level/Info")]
    private static void SetLogLevelInfo()
    {
        Logger.CurrentLogLevel = Logger.LogLevel.Info;
        Logger.Log("Log level set to Info");
    }

    [MenuItem("Tools/Set Log Level/Info", true)]
    private static bool SetLogLevelInfoValidate()
    {
        Menu.SetChecked("Tools/Set Log Level/Info", Logger.CurrentLogLevel == Logger.LogLevel.Info);
        return true;
    }
}
