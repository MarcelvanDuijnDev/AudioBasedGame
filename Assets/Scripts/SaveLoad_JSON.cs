using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class SaveLoad_JSON : MonoBehaviour
{
    [SerializeField] private string _Version = "0.0.0";

    public Json_SaveData SaveData = new Json_SaveData();

    void Awake()
    {
        LoadFile();
    }

    public void SaveFile()
    {
        string jsonData = JsonUtility.ToJson(SaveData, true);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonData);
    }
    public void LoadFile()
    {
        try
        {
            string dataAsJson = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
            SaveData = JsonUtility.FromJson<Json_SaveData>(dataAsJson);
        }
        catch
        {
            //Board
            Json_ScoreBoard newboard = new Json_ScoreBoard();
            newboard.Version = _Version;
            newboard.Scores = new List<Json_Score>();
            SaveData.ScoreBoard.Add(newboard);

            SaveFile();
        }
    }
    public Json_SaveData GetSaveData()
    {
        return SaveData;
    }
    public void CreateNewSave()
    {
        Json_Score newsave = new Json_Score();
        newsave.Score = 0;
        SaveData.ScoreBoard[SaveData.ScoreBoard.Count-1].Scores.Add(newsave);
    }

    public void Insert_Score(float score)
    {
        Json_Score newscore = new Json_Score();
        newscore.Score = score;
        newscore.Date = new Vector4(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, (float)DateTime.Now.TimeOfDay.TotalSeconds);

        if (SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Version == _Version)
        {
            bool check = false;
            for (int i = 0; i < SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Scores.Count; i++)
            {
                if (newscore.Score > SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Scores[i].Score)
                {
                    SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Scores.Insert(i, newscore);
                    check = true;
                    break;
                }
            }

            if(SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Scores.Count == 0 || !check)
                SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Scores.Add(newscore);
        }
        else
        {
            Json_ScoreBoard newboard = new Json_ScoreBoard();
            newboard.Version = _Version;
            newboard.Scores = new List<Json_Score>();
            SaveData.ScoreBoard.Add(newboard);

            SaveData.ScoreBoard[SaveData.ScoreBoard.Count - 1].Scores.Add(newscore);
        }

        SaveFile();
    }
}

[System.Serializable]
public class Json_SaveData
{
    public List<Json_ScoreBoard> ScoreBoard = new List<Json_ScoreBoard>();
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
