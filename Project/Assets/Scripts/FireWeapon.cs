using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
  public float reloadTime;
  public GameObject Bullet;
  public float bullletStartDistance = 10;
  public float bulletStartSpeed = 30;

  private bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void spawn(float Me, float dist, float angle)
    {
        GameObject bullet = Instantiate(Bullet);
        Vector2 dir = new Vector2(Mathf.Sin(Mathf.Deg2Rad * (Me + angle)), Mathf.Cos(Mathf.Deg2Rad * (Me + angle)));
        bullet.transform.position = (Vector2)transform.position + dir * dist * bullletStartDistance;
        bullet.GetComponent<Rigidbody2D>().velocity = (dir * bulletStartSpeed) + GetComponent<Rigidbody2D>().velocity;
        bullet.GetComponent<CollisionDamage>().shotByPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && canFire)
        {
            float Me = (transform.eulerAngles.z);

            canFire = false;
            StartCoroutine(reload());
            int level = GameObject.Find("Player").GetComponent<Systems>().WeaponLvL;

            //Debug.Log("weapon level: " + level.ToString());

            switch (level)
            {
                case 1:
                    spawn(Me, 1f, 0f);
                    break;
                case 2:
                    spawn(Me, 1f, 0f);
                    spawn(Me, 2f, 0f);
                    spawn(Me, 3f, 0f);
                    break;
                case 3:
                    spawn(Me, 1f, 0f);
                    spawn(Me, 1f, -10f);
                    spawn(Me, 1f, +10f);
                    break;
                case 4:
                    spawn(Me, 1f, 0f);
                    spawn(Me, 1f, -10f);
                    spawn(Me, 1f, +10f);
                    spawn(Me, 2f, 0f);
                    spawn(Me, 2f, -10f);
                    spawn(Me, 2f, +10f);
                    spawn(Me, 3f, 0f);
                    spawn(Me, 3f, -10f);
                    spawn(Me, 3f, +10f);
                    break;
            }
            
        }
    }

    IEnumerator reload()
    {
      yield return new WaitForSeconds(reloadTime);
      canFire = true;
    }

  //https://stackoverflow.com/questions/13458992/angle-between-two-vectors-2d
  public static float AngleBetween(Vector2 vector1, Vector2 vector2)
  {
    float sin = vector1.x * vector2.y - vector2.x * vector1.y;
    float cos = vector1.x * vector2.x + vector1.y * vector2.y;

    return Mathf.Atan2(sin, cos) * (180 / Mathf.PI);
  }
}
