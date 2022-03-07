using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _SongInfoText;
    [SerializeField] private AudioSource _AudioSource;

    private string sName, sDuration;
    private float audioLength;

    void FixedUpdate()
    {
        sName = _AudioSource.clip.name.ToString();
        audioLength = _AudioSource.clip.length / 60;
        sDuration = audioLength.ToString("F0");
        _SongInfoText.text = sName + "        " + sDuration;
    }
}
