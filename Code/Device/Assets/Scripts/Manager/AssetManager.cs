
using System.IO;
using UnityEngine;

public class AssetManager
{
    /// <summary>
    /// 读取文本文件
    /// </summary>
    private static string ReadTextFromPath(string path)
    {
        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        Logger.LogWarning("ReadTextFromStreamAsset faile : " + path);
        return null;
    }

    /// <summary>
    /// 读取配置文件
    /// </summary>
    public static string ReadConfigText(string fileName)
    {
        return ReadTextFromPath(Path.Combine(AppConstant.CONFIG_PATH, fileName));
    }

    /// <summary>
    /// 读取表数据
    /// </summary>
    /// <returns></returns>
    public static string ReadCsvText(string fileName)
    {
        return ReadTextFromPath(Path.Combine(AppConstant.EXCEL_PATH, fileName));
    }
}
