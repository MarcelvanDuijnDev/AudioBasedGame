using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour 
{
    [Header("Settings")]
    [SerializeField] private Transform _CameraObj;
    [SerializeField] private GameObject _Point1, _Point2;
    [SerializeField] private Image _SongsObj;

    private bool changeImage;
    private float aphaImage;

    void Start()
    {
        aphaImage = _SongsObj.color.a;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changeImage = false;
        }

        if (!changeImage)
        {
            if (aphaImage <= 1)
            {
                aphaImage += 1 * Time.deltaTime;
            }
            if (_CameraObj.position != _Point1.transform.position)
            {
                _CameraObj.position = Vector3.MoveTowards(_CameraObj.position,_Point1.transform.position,5 * Time.deltaTime);
            }
        }
        else
        {
            if (aphaImage >= 0)
            {
                aphaImage -= 1 * Time.deltaTime;
            }
            if (_CameraObj.position != _Point2.transform.position)
            {
                _CameraObj.position = Vector3.MoveTowards(_CameraObj.position,_Point2.transform.position,5 * Time.deltaTime);
            }
        }
        _SongsObj.color = new Color(0,0,0,aphaImage);
    }

    public void Click_Start()
    {
        changeImage = true;
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
