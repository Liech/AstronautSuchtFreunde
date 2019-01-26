using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CollisionDamage : MonoBehaviour
{
  public float DamageFactor = 1;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    float diff = collision.relativeVelocity.magnitude;
    if (diff > 20f)
        diff = 20f;

    GetComponent<Life>().getDamage((int)(diff * DamageFactor));
  }
}
