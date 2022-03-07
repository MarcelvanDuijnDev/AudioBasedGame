using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _HighScoresText = null;
    [SerializeField] private Json_Score[] _Scores = new Json_Score[5];

    [SerializeField] private SaveLoad_JSON _SaveFile = null;

    private string _ScoreString = "";

    void Start()
    {
        OrganizeData();
    }

    void OrganizeData()
    {
        List<Json_Score> scores = _SaveFile.SaveData.ScoreBoard[_SaveFile.SaveData.ScoreBoard.Count - 1].Scores;

        _ScoreString = "";
        for (int i = 0; i < _Scores.Length; i++)
        {
            if (scores.Count > i)
                _ScoreString += (i + 1).ToString() + ". " + scores[i].Score.ToString();
            else
                _ScoreString += (i + 1).ToString() + ". ---";

            _ScoreString += "\n";
        }

        _HighScoresText.text = _ScoreString;
    }
}
