using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour 
{
    public GameObject player;
    public float speed;
    public float health;
    public float healthReset;
    public float multi;
    public GameObject deathEffectPrefab;

    private Vector3 scaleObj;

	void Start () 
    {
        healthReset = health;
        scaleObj = this.gameObject.transform.localScale;
	}

    void OnDisable()
    {
        health = healthReset;
    }
	
	void Update () 
    {
        float audioIntensity = 0;
        for (int i = 0; i < 8; i++)
        {
            audioIntensity += ReadAudioFile.bandBuffer[i];
        }
        scaleObj = new Vector3(audioIntensity * multi,audioIntensity * multi,audioIntensity * multi);
        this.gameObject.transform.localScale = scaleObj;


        if (health <= 0)
        {
            GameObject obj = Instantiate(deathEffectPrefab);
            obj.transform.position = this.transform.position;
            this.gameObject.SetActive(false);
        }
         
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}
}
