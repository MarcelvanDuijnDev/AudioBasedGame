using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad_JSON : MonoBehaviour
{
    [SerializeField] private string _Version = "0.0.0";

    private Json_SaveData _SaveData = new Json_SaveData();

    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(_SaveData, true);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonData);
    }
    public void LoadData()
    {
        try
        {
            string dataAsJson = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
            _SaveData = JsonUtility.FromJson<Json_SaveData>(dataAsJson);
        }
        catch
        {
            SaveData();
        }
    }
    public Json_SaveData GetSaveData()
    {
        return _SaveData;
    }
    public void CreateNewSave()
    {
        Json_Score newsave = new Json_Score();
        newsave.Score = 0;
        _SaveData.SaveData.Add(newsave);
    }
}

[System.Serializable]
public class Json_SaveData
{
    public List<Json_Score> SaveData = new List<Json_Score>();
}

[System.Serializable]
public class Json_ScoreBoard
{
    public string Version;
    public List<Json_Score> Scores = new List<Json_Score>();
}

[System.Serializable]
public class Json_Score
{
    public Vector4 Date = new Vector4(0,0,0,0);
    public float Score = 0;
}
