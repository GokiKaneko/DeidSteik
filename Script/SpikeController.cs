using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] float _Spikespeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        bool SetActive;    
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.up * _Spikespeed * Time.deltaTime);
    }
}
