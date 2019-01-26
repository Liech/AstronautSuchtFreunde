using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [Range(-0.5f,0.5f)]
    public float strength = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = - GameObject.Find("Player").GetComponent<Transform>().position * strength;
    }
}
