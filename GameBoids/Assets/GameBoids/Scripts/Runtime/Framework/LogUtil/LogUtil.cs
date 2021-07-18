using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class LogUtil
{
    [Conditional("DebugLog")]
    public static void Log(object msg)
    {
        Debug.Log(msg);
    }

    [Conditional("DebugLog")]
    public static void Log(object msg, Object context)
    {
        Debug.Log(msg, context);
    }

    [Conditional("DebugLog")]
    public static void LogWarning(object msg)
    {
        Debug.LogWarning(msg);
    }

    [Conditional("DebugLog")]
    public static void LogWarning(object msg, Object context)
    {
        Debug.LogWarning(msg, context);
    }

    [Conditional("DebugLog")]
    public static void LogError(object msg)
    {
        Debug.LogError(msg);
    }

    [Conditional("DebugLog")]
    public static void LogError(object msg, Object context)
    {
        Debug.LogError(msg, context);
    }
}
