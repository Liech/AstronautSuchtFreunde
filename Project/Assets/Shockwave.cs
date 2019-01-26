using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
  public float speed;
  public bool draw;
  public float shock = 1000;

  public float range = 10;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    transform.localScale = transform.localScale + new Vector3(speed,speed,speed);
    
    }

  private void OnDestroy()
  {
    Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, range);
    foreach(Collider2D c in col)
    {
      if (c.gameObject.GetComponent<Life>())
      {
        c.gameObject.GetComponent<Life>().currentLife -= 100;
        c.gameObject.GetComponent<Rigidbody2D>().velocity = (c.gameObject.transform.position - transform.position).normalized * shock;
      }
    }
  } 

  public void OnDrawGizmos()
  {
    if (draw)
      Gizmos.DrawSphere(transform.position, range);
  }


}
