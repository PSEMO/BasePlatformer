using System.IO;
using UnityEngine;

public static class Env
{
    /*
    Save files will be located at following directories:

        Linux:
            /home/[YourUsername]/.config/unity3d/[YourCompanyName]/Base2DUnityPlatformer/
        Windows:
            C:\Users\[YourUsername]\AppData\LocalLow\[YourCompanyName]\Base2DUnityPlatformer\

        Note: Default company name is => "DefaultCompany"
    
    Default file names are:
        PlayerPrefs:
            prefs
        SceneDatas:
            [SceneName].data.EnterYourGameNameHere
    */

    public static string FileName = ".data.EnterYourGameNameHere";

    public static bool HasGameData(string SceneName = "")
    {
        string fullPath = Path.Combine(Application.persistentDataPath, SceneName, FileName);
        return File.Exists(fullPath);
    }
}