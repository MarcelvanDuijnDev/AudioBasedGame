using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour 
{
    [Header("Settings")]
    [SerializeField] private GameObject _Prefab_Cube = null;
    [SerializeField] private float _MaxScale = 500;
    [SerializeField] private Vector3 _ObjSize = new Vector3(3,3,3);
    [SerializeField] private float _Distance = 180;
    [SerializeField] private float _Height = 0;

    private GameObject[] _Cubes = new GameObject[512];

    void Start () 
    {
        for (int i = 0; i < _Cubes.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(_Prefab_Cube);
            obj.transform.position = this.transform.position;
            obj.transform.parent = this.transform;
            obj.name = "Cube: " + i.ToString();
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            obj.transform.position = Vector3.forward * _Distance;
            Vector3 pos = obj.transform.position;
            pos.y += _Height;

            obj.transform.position = pos;
            _Cubes[i] = obj;
        }
	}
	
	void Update () 
    {
        for (int i = 0; i < _Cubes.Length; i++)
        {
            if (_Cubes != null)
                _Cubes[i].transform.localScale = new Vector3(_ObjSize.x,(ReadAudioFile._Samples[i] * _MaxScale) + _ObjSize.y,_ObjSize.z);
        }
	}
}
