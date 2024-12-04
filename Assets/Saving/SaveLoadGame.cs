using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour
{
    public GameObject exampleGO;
    public void SaveGame()
    {
        GameData data = new GameData();
        data.position.FromVector(exampleGO.transform.position);
        JsonSaveLoad.Save(data);
    }

    public void LoadGame()
    {
        GameData data = JsonSaveLoad.Load();
        Debug.Log(data.data);
        exampleGO.transform.position = data.position.ToVector();
    }
}
