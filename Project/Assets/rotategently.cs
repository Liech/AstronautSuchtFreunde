using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotategently : MonoBehaviour
{
  public float startrot = 0;
  public float range = 10;
  public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
    startrot = transform.localEulerAngles.z;
    } 

    // Update is called once per frame
    void Update()
    {
    transform.localEulerAngles = new Vector3(0, 0, startrot + Mathf.Sin(Time.time * speed) * range);
    }
}
