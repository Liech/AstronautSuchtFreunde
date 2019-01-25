﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellit : MonoBehaviour
{
  public GameObject Target;
  public GameObject Turret;
  public GameObject Bullet;
  public Collider2D SphereOfInflucence;

  public float RotationSpeed = 2;
  public float reloadTime = 0.5f;
  public float bullletStartDistance = 10;

  private bool Active = false;
  private bool ReadyToShoot = true;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (!Active)
      return;

    Vector3 vectorToTarget = Target.transform.position - Turret.transform.position;
    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
    Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, q, Time.deltaTime * RotationSpeed);

    float He = AngleBetween(Target.transform.position - transform.position, new Vector2(0, 1));
    float Me = 360 - (Turret.transform.eulerAngles.z) + 90;
    if (Me > 180) Me -= 360;
    if (He < -180) He += 360;

    float diff = Mathf.Abs(Me - He);
    
    Debug.Log(diff);
    if ((diff < 5) && ReadyToShoot)
    {
      ReadyToShoot = false;
      GameObject bullet = Instantiate(Bullet);
      Vector2 dir = new Vector2(Mathf.Sin(Mathf.Deg2Rad * Me), Mathf.Cos(Mathf.Deg2Rad * Me));
      bullet.transform.position = (Vector2)Turret.transform.position + dir  * bullletStartDistance;
      bullet.GetComponent<Rigidbody2D>().velocity = (dir * 10);
      StartCoroutine(Reload());
    }

  }

  IEnumerator Reload()
  {
    yield return new WaitForSeconds(reloadTime);
    ReadyToShoot = true;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject == Target)
      Active = true;
  }

  void OnTriggerExit2D(Collider2D collision)
  {
    Active = false;
  }

  //https://stackoverflow.com/questions/13458992/angle-between-two-vectors-2d
  public static float AngleBetween(Vector2 vector1, Vector2 vector2)
  {
    float sin = vector1.x * vector2.y - vector2.x * vector1.y;
    float cos = vector1.x * vector2.x + vector1.y * vector2.y;

    return Mathf.Atan2(sin, cos) * (180 / Mathf.PI);
  }
}