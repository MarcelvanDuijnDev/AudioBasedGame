using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour 
{
    public int band;
    public float startScale, scaleMulti;
    public bool useBuffer;

	void Start () {
		
	}
	
	void Update () 
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (ReadAudioFile.bandBuffer[band] * scaleMulti) + startScale, transform.localScale.x);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (ReadAudioFile.freqBand[band] * scaleMulti) + startScale, transform.localScale.x);
        }
	}
}
