using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBot : MonoBehaviour
{
  public GameObject Target;
  public GameObject Bullet;
  public float SphereOfInflucence = 420;
  public GameObject FireSound;
  public float firepitch = 0;
  public Vector3 startVelocity;

  public float RotationSpeed = 2;
  public float reloadTime = 0.5f;
  public float bullletStartDistance = 10;
  public float bulletStartSpeed = 30;

  private bool Active = false;
  private bool ReadyToShoot = true;
  public Color bulletColor = Color.magenta;

  // Start is called before the first frame update
  void Start()
  {
    Target = GameObject.Find("Player");
    GetComponent<Rigidbody2D>().velocity = startVelocity;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (Target == null) return;

    Active = (Target.transform.position - transform.position).magnitude < SphereOfInflucence;
    //Debug.Log((Target.transform.position - transform.position).magnitude);
    if (!Active)
    {
      //transform.rotation = Quaternion.identity;
      return;
    }
    Vector3 vectorToTarget = Target.transform.position - transform.position;
    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, RotationSpeed);


    float He = AngleBetween(Target.transform.position - transform.position, new Vector2(0, 1));
    float Me = 360 - (transform.eulerAngles.z) + 90;
    if (Me > 180) Me -= 360;
    if (He < -180) He += 360;

    float diff = Mathf.Abs(Me - He);
    
    //Debug.Log(diff);
    if ((diff < 5) && ReadyToShoot)
    {
      ReadyToShoot = false;
      GameObject bullet = Instantiate(Bullet);
      Vector2 dir = new Vector2(Mathf.Sin(Mathf.Deg2Rad * Me), Mathf.Cos(Mathf.Deg2Rad * Me));
      bullet.transform.position = (Vector2)transform.position + dir  * bullletStartDistance;
      bullet.GetComponent<Rigidbody2D>().velocity = (dir * bulletStartSpeed);
      bullet.transform.GetChild(1).GetComponent<SpriteRenderer>().color = bulletColor;
      ParticleSystem.MainModule settings = bullet.transform.GetChild(0).GetComponent<ParticleSystem>().main;
      settings.startColor = new ParticleSystem.MinMaxGradient(bulletColor);
      if (FireSound != null)
      {
        GameObject g = Instantiate(FireSound);
        g.GetComponent<AudioSource>().pitch = firepitch;
      }
      StartCoroutine(Reload());
    }

  }

  IEnumerator Reload()
  {
    yield return new WaitForSeconds(reloadTime);
    ReadyToShoot = true;
  }

  //https://stackoverflow.com/questions/13458992/angle-between-two-vectors-2d
  public static float AngleBetween(Vector2 vector1, Vector2 vector2)
  {
    float sin = vector1.x * vector2.y - vector2.x * vector1.y;
    float cos = vector1.x * vector2.x + vector1.y * vector2.y;

    return Mathf.Atan2(sin, cos) * (180 / Mathf.PI);
  }
}
