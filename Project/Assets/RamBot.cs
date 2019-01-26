using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamBot : MonoBehaviour
{
  public GameObject Target;
  public Collider2D SphereOfInflucence;
  public Transform home;
  public float speed = 10;
  public float maxHomeDist = 50;
  public float minHomeDist = 10;
  public bool draw = false;

  bool Active = false;
  // Start is called before the first frame update
  void Start()
  {
    Target = GameObject.Find("Player");
    SphereOfInflucence = GameObject.Find("Universe/Robo Planet").GetComponent<Collider2D>();
    home = GameObject.Find("Universe/Robo Planet").transform;

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    //if (!Active) return;
    //if (!Target) return;
    if (Target == null) return;
    Vector2 diff = Target.transform.position - transform.position;

    Vector2 homeDistance = home.transform.position - transform.position;
    if (homeDistance.magnitude > maxHomeDist)
      GetComponent<Rigidbody2D>().AddForce(homeDistance.normalized * speed);
    else if (homeDistance.magnitude < minHomeDist)
      GetComponent<Rigidbody2D>().AddForce(-homeDistance.normalized * speed);
    else if (Active)
      GetComponent<Rigidbody2D>().AddForce(diff.normalized * speed);
  }


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject == Target)
      Active = true;
  }

  void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject == Target)
      Active = false;
  }

  //https://stackoverflow.com/questions/13458992/angle-between-two-vectors-2d
  public static float AngleBetween(Vector2 vector1, Vector2 vector2)
  {
    float sin = vector1.x * vector2.y - vector2.x * vector1.y;
    float cos = vector1.x * vector2.x + vector1.y * vector2.y;

    return Mathf.Atan2(sin, cos) * (180 / Mathf.PI);
  }

  public void OnDrawGizmos()
  {
    if (!draw) return;
    Gizmos.color = new Color(0, 1, 0, 0.3f);
    Gizmos.DrawSphere(home.transform.position, minHomeDist);
    Gizmos.color = new Color(0, 0, 1, 0.3f);
    Gizmos.DrawSphere(home.transform.position, maxHomeDist);
  }

}
