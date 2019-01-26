using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilaBossBehavior : MonoBehaviour
{
  public GameObject Eye1;
  public GameObject Eye2;
  public float rotationSpeed = 1;
  float rot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Eye1 == null && Eye2 == null)
        Destroy(gameObject);
    rot += rotationSpeed;
    transform.parent.eulerAngles = new Vector3(0,0,rot);
    }
}
