using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class tentacle : MonoBehaviour
{
    public int numberOfPoints = 4;
  public float speed = 15;
  public GameObject target;
  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    if (target == null) return;

    for (int i = 0; i < numberOfPoints; i++)
    {
      //if (i!= 0)transform.GetChild(i).GetComponent<DistanceJoint2D>().distance = 3;
      //s.spline.SetPosition(i, transform.GetChild(i).localPosition);
      //if (i > 1)
      //  s.spline.SetLeftTangent(i, (transform.GetChild(i - 2).localPosition - transform.GetChild(i).localPosition).normalized);
      //else if (i != 0)
      //  s.spline.SetLeftTangent(i, (transform.GetChild(i - 1).localPosition - transform.GetChild(i).localPosition).normalized);
      //
      //if (i < numberOfPoints-2)
      //  s.spline.SetRightTangent(i, (transform.GetChild(i + 2).localPosition - transform.GetChild(i).localPosition).normalized );
      //if (i != numberOfPoints-1)
      //  s.spline.SetRightTangent(i, (transform.GetChild(i + 1).localPosition - transform.GetChild(i).localPosition).normalized) ;

      if (transform.GetChild(i).GetComponent<DistanceJoint2D>())
        transform.GetChild(i).GetComponent<DistanceJoint2D>().distance = 3;
    }
    Vector2 dist = (target.transform.position - transform.GetChild(numberOfPoints - 1).position);
    if (dist.magnitude > 1)
      dist.Normalize();
    transform.GetChild(numberOfPoints - 1).GetComponent<Rigidbody2D>().velocity = dist * speed;
  }
}
