using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour 
{
    [SerializeField] private Text _SongInfo;
    [SerializeField] private AudioSource _AudioSource;

    private string sName, sDuration;
    private float audioLength;

    void FixedUpdate()
    {
        sName = _AudioSource.clip.name.ToString();
        audioLength = _AudioSource.clip.length / 60;
        sDuration = audioLength.ToString("F0");
        _SongInfo.text = sName + "        " + sDuration;
    }
}
