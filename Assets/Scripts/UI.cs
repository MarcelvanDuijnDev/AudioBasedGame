using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour 
{
    public Text songInfo;
    public AudioSource audioSource;

    private string sName, sDuration;
    private float audioLength;
	
    void Start () 
    {
		
	}
	
	void Update () 
    {
		
	}

    void FixedUpdate()
    {
        sName = audioSource.clip.name.ToString();
        audioLength = audioSource.clip.length / 60;
        sDuration = audioLength.ToString("F0");
        songInfo.text = sName + "        " + sDuration;
    }
}
