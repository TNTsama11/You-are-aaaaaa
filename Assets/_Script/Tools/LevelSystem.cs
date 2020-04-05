using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Text;
using System.Text.RegularExpressions;

public static class LevelSystem 
{
    /// <summary>
    /// 加载关卡数据
    /// </summary>
    /// <returns></returns>
    public static List<LevelCard> LoadLevels()
    {
        string path = Application.streamingAssetsPath + "/LevelData.Json";
        if (!File.Exists(path))
        {
            return null;
        }
        using(StreamReader file=new StreamReader(path))
        {
            string fileContents = file.ReadToEnd();
            LevelCardData levelCardData = JsonMapper.ToObject<LevelCardData>(fileContents);
            return levelCardData.LevelList;
        }
    }
    /// <summary>
    /// 写入关卡数据
    /// </summary>
    /// <param name="levelID"></param>
    /// <param name="unlock"></param>
    public static void SetLevelsStatus(int levelID, bool unlock)
    {
        LevelCardData levelCardData = new LevelCardData();
        levelCardData.LevelList = LoadLevels();
        if (unlock)
        {
            levelCardData.LevelList[levelID - 1].Unlock = 1;
        }
        else
        {
            levelCardData.LevelList[levelID - 1].Unlock = 0;
        }
        string jsonStr=JsonMapper.ToJson(levelCardData);
        string json = Regex.Unescape(jsonStr);
        // Debug.Log(json);
        string path = Application.streamingAssetsPath + "/LevelData.Json";
        WriteFile(path, json);
    }

    private static void WriteFile(string path,string str)
    {
        using(StreamWriter file=new StreamWriter(path, false))
        {
            file.Write(str);
        }
    }

}
