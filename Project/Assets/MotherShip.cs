using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
  private GameObject Target;
  public float Speed = 10;
  // Start is called before the first frame update
  void Start()
  {
    Target = GameObject.Find("Player");
  }
  
  // Update is called once per frame
  void Update()
    {

      if (Target == null) return;

      Vector2 diff = Target.transform.position - transform.position;

      GetComponent<Rigidbody2D>().AddForce(diff.normalized * Speed);
    
  }
}
