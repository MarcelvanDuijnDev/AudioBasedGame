using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    [SerializeField] private float _Range;

    private LineRenderer _LineR;

	void Start () 
    {
        _LineR = GetComponent<LineRenderer>();
	}
	
	void Update () 
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                _LineR.enabled = true;
                _LineR.SetPosition(0, transform.position);
                _LineR.SetPosition(1, hit.point);
                if (hit.transform.gameObject.GetComponent<Enemy>() != null)
                    hit.transform.gameObject.GetComponent<Enemy>().DoDamage(1);
            }
        }
        else
        {
            _LineR.enabled = false;
        }
	}
}
