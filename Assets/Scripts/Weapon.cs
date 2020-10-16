using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    private LineRenderer lr;

    [SerializeField]private float range;
	void Start () 
    {
        lr = GetComponent<LineRenderer>();
	}
	
	void Update () 
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, hit.point);
                if(hit.transform.gameObject.GetComponent<enemy>() != null)
                hit.transform.gameObject.GetComponent<enemy>().health -= 1 * Time.deltaTime;
            }
        }
        else
        {
            lr.enabled = false;
        }
	}
}
