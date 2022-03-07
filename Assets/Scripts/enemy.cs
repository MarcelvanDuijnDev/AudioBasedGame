using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [Header("Settings")]
    [SerializeField] private float _Speed = 3;
    [SerializeField] private float _Health = 100;
    [SerializeField] private float _HealthMax = 100;
    [SerializeField] private float _Multi = 1;
    [SerializeField] private GameObject _DeathEffectPrefab = null;

    private Vector3 _ScaleObj;
    private Transform _PlayerObj;

    void Start () 
    {
        _PlayerObj = GameObject.Find("Player").transform;
        _HealthMax = _Health;
        _ScaleObj = this.gameObject.transform.localScale;
	}

    void OnDisable()
    {
        _Health = _HealthMax;
    }
	
	void Update () 
    {
        float audioIntensity = 0;
        for (int i = 0; i < 8; i++)
        {
            audioIntensity += ReadAudioFile._BandBuffer[i];
        }
        _ScaleObj = new Vector3(audioIntensity * _Multi,audioIntensity * _Multi,audioIntensity * _Multi);
        this.gameObject.transform.localScale = _ScaleObj;


        if (_Health <= 0)
        {
            GameObject obj = Instantiate(_DeathEffectPrefab);
            obj.transform.position = this.transform.position;
            this.gameObject.SetActive(false);
        }
         
        transform.position = Vector3.MoveTowards(transform.position, _PlayerObj.position, _Speed * Time.deltaTime);
	}

    public void DoDamage(float amount)
    {
        _Health -= amount;
    }
}
