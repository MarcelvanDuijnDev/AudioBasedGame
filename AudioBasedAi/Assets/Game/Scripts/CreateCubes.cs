using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour 
{
    public GameObject prefab_Cube;
    private GameObject[] cubes = new GameObject[512];
    public float maxScale;

    public Vector3 objSize;
    public float distance;
    public float height;

	void Start () 
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(prefab_Cube);
            obj.transform.position = this.transform.position;
            obj.transform.parent = this.transform;
            obj.name = "Cube: " + i.ToString();
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            obj.transform.position = Vector3.forward * distance;
            Vector3 pos = obj.transform.position;
            pos.y += height;


            obj.transform.position = pos;
            cubes[i] = obj;
        }
	}
	
	void Update () 
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(objSize.x,(ReadAudioFile.samples[i] * maxScale) + objSize.y,objSize.z);
            }
        }
	}
}
