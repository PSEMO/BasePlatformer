using System.IO;
using UnityEngine;

public static class Env
{
    public static string FileName = "data.GameName";

    public static bool HasGameData()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, FileName);
        return File.Exists(fullPath);
    }
}