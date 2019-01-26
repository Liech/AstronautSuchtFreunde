using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillate : MonoBehaviour
{
    public float speed = 1f;
    private Light l;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        l.intensity = 6f + Mathf.Sin(Time.time * speed) * 5f;
    }
}
