using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour 
{
    [SerializeField] private Light[] _Lights;
    [SerializeField] private bool _InvertRGB;
	
	void Update () 
    {
        float audioIntensity = 0;
        float audioIntensity_r = ReadAudioFile._BandBuffer[0] + ReadAudioFile._BandBuffer[1];
        float audioIntensity_g = ReadAudioFile._BandBuffer[2] + ReadAudioFile._BandBuffer[3];
        float audioIntensity_b = ReadAudioFile._BandBuffer[4] + ReadAudioFile._BandBuffer[5];
        for (int i = 0; i < 8; i++)
        {
            audioIntensity += ReadAudioFile._BandBuffer[i];
        }
        for (int i = 0; i < _Lights.Length; i++)
        {
            //Intensity
            _Lights[i].intensity = 1000 * audioIntensity *0.2f;

            //Color
            float r = audioIntensity_r*0.05f;
            float g = audioIntensity_g*0.05f;
            float b = audioIntensity_b*0.05f;

            if (r < 0)
                r = 0;
            if (g < 0)
                g = 0;
            if (b < 0)
                b = 0;

            if (r > 1)
                r = 1;
            if (g > 1)
                g = 1;
            if (b > 1)
                b = 1;

            //Debug.Log("r: " + r + " | " + "g: " + g + " | " + "b: " + b);

            if (!_InvertRGB)
            {
                _Lights[i].color = new Color(r, g, b);
            }
            else
            {
                _Lights[i].color = new Color(b, g, r);
            }
        }
	}
}
