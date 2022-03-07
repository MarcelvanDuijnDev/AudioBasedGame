using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public float Score;

    [SerializeField] private TextMeshProUGUI _ScoreText;
    [SerializeField] private SaveLoad_JSON _SaveLoadScript;

    public static GameHandler HANDLER;

    private void Awake()
    {
        HANDLER = this;
    }

    void Update()
    {
        _ScoreText.text = "Score: " + Score.ToString();

        if (Input.GetKeyDown(KeyCode.P))
            GameOver();
    }

    public void GameOver()
    {
        _SaveLoadScript.Insert_Score(Score);
        SceneManager.LoadScene("Menu");
    }
}
