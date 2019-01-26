using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.U2D;

public class Laser : MonoBehaviour
{
  GameObject start;
  GameObject end;
  GameObject img;
  public float distance = 5000;
  Vector2 direction = new Vector2(0,1);
  public LayerMask l;
  
    // Start is called before the first frame update
    void Start()
    {
    start = transform.gameObject;
    end = transform.GetChild(1).gameObject;
    img = transform.GetChild(0).gameObject;
  }

    // Update is called once per frame
    void Update()
    {
    direction = new Vector2(Mathf.Sin(-Mathf.Deg2Rad * transform.eulerAngles.z), Mathf.Cos(-Mathf.Deg2Rad * transform.eulerAngles.z));
      end.transform.localPosition = direction;
    RaycastHit2D[] d = Physics2D.RaycastAll(transform.position, direction, distance, ~LayerMask.GetMask( "Eye"));
    RaycastHit2D best = default(RaycastHit2D);
    foreach (RaycastHit2D h in d)
    {
      if (h.collider.isTrigger) continue;
      if (best == default(RaycastHit2D))
        best = h;
      else
        if (best.distance > h.distance)
        best = h;
    }

    if (best) end.transform.position = best.point;
    else
      end.transform.position = (Vector2)transform.position + direction * distance;

    if (best)
    if (best.collider.gameObject.GetComponent<Life>())
        best.collider.gameObject.GetComponent<Life>().getDamage(1);

      img.GetComponent<SpriteShapeController>().spline.SetPosition(0, new Vector3());
      img.GetComponent<SpriteShapeController>().spline.SetPosition(1,  end.transform.localPosition);
      img.GetComponent<SpriteShapeRenderer>().material.color = new Color(Random.value, Random.value, Random.value);

      
    }

  //https://stackoverflow.com/questions/13458992/angle-between-two-vectors-2d
  public static float AngleBetween(Vector2 vector1, Vector2 vector2)
    {
      float sin = vector1.x * vector2.y - vector2.x * vector1.y;
      float cos = vector1.x * vector2.x + vector1.y * vector2.y;

      return Mathf.Atan2(sin, cos) * (180 / Mathf.PI);
    }
}
