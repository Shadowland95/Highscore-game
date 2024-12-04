using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonSaveLoad
{
#if UNITY_EDITOR
    //dataPath is for test purposes 
    public static string fileHS = Application.dataPath + "/saveHS.json";
    //in case it does not work take out Path.PathSeparator
    public static string filePos = Application.dataPath + "/savePos.json";
#else
    public static string file = Application.persistentDataPath + "/saveHS.json";
    public static string filePosition = Application.persistentDataPath + "/savePos.json";
#endif

    public static void SaveHighScore(HighScoreData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(fileHS, json);
    }

    public static HighScoreData LoadHighScore()
    {
        if (File.Exists(fileHS))
        {
            string json = File.ReadAllText(fileHS);
            return JsonUtility.FromJson<HighScoreData>(json);
        }

        return null;
    }


    public static void Save(GameData data)
    {
        //GameData data = new GameData();
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePos, json);
    }
    public static GameData Load()
    {
        if (File.Exists(filePos))
        {
            string json = File.ReadAllText(filePos);
            return JsonUtility.FromJson<GameData>(json);
        }

        return null;
    }

}