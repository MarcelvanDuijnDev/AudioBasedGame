using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour 
{
    [SerializeField] private int _Band;
    [SerializeField] private float _StartScale, _ScaleMulti;
    [SerializeField] private bool _UseBuffer;

	void Update () 
    {
        if (_UseBuffer)
            transform.localScale = new Vector3(transform.localScale.x, (ReadAudioFile._BandBuffer[_Band] * _ScaleMulti) + _StartScale, transform.localScale.x);
        else
            transform.localScale = new Vector3(transform.localScale.x, (ReadAudioFile._FreqBand[_Band] * _ScaleMulti) + _StartScale, transform.localScale.x);
	}
}
