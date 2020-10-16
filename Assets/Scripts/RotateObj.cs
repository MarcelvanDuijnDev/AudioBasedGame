using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour {

    public Vector3 rotateSpeed;
    public bool rotationBasedOnAudio;

	void Start () 
    {
		
	}
	
	void Update () 
    {
        if (!rotationBasedOnAudio)
        {
            this.transform.Rotate(rotateSpeed.x * Time.deltaTime, rotateSpeed.y * Time.deltaTime, rotateSpeed.z * Time.deltaTime);
        }
        else
        {
            float rotSpeed = 0;
            for (int i = 0; i < 8; i++)
            {
                rotSpeed += ReadAudioFile.bandBuffer[i];
            }
            this.transform.Rotate(rotateSpeed.x * rotSpeed * Time.deltaTime, rotateSpeed.y * rotSpeed * Time.deltaTime, rotateSpeed.z * rotSpeed * Time.deltaTime);
        }
	}
}
