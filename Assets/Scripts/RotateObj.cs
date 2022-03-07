using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour {

    [SerializeField] private Vector3 _RotateSpeed;
    [SerializeField] private bool _RotationBasedOnAudio;
	
	void Update () 
    {
        if (!_RotationBasedOnAudio)
        {
            this.transform.Rotate(_RotateSpeed.x * Time.deltaTime, _RotateSpeed.y * Time.deltaTime, _RotateSpeed.z * Time.deltaTime);
        }
        else
        {
            float rotSpeed = 0;
            for (int i = 0; i < 8; i++)
            {
                rotSpeed += ReadAudioFile._BandBuffer[i];
            }
            this.transform.Rotate(_RotateSpeed.x * rotSpeed * Time.deltaTime, _RotateSpeed.y * rotSpeed * Time.deltaTime, _RotateSpeed.z * rotSpeed * Time.deltaTime);
        }
	}
}
