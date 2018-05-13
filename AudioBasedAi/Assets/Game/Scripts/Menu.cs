using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour 
{
    public GameObject camera;
    public GameObject point1, point2;

    public Image songsObj;
    private bool changeImage;
    float aphaImage;

    void Start()
    {
        aphaImage = songsObj.color.a;
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
            if (camera.transform.position != point1.transform.position)
            {
                camera.transform.position = Vector3.MoveTowards(camera.transform.position,point1.transform.position,5 * Time.deltaTime);
            }
        }
        else
        {
            if (aphaImage >= 0)
            {
                aphaImage -= 1 * Time.deltaTime;
            }
            if (camera.transform.position != point2.transform.position)
            {
                camera.transform.position = Vector3.MoveTowards(camera.transform.position,point2.transform.position,5 * Time.deltaTime);
            }
        }
        songsObj.color = new Color(0,0,0,aphaImage);
    }

    public void Click_Start()
    {
        changeImage = true;
    }

    public void Click_LoadScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }

    public void Click_Quit()
    {
        Application.Quit();
    }
}
