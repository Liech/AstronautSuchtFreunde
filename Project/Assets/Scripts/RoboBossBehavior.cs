using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboBossBehavior : MonoBehaviour
{
  public float rotationSpeed = 1;
  float rot = 0;
  bool awake = false;
  public Sprite AwakeSprite;
  public float ocillationspeed = 4;
  public float oscillationdistance = 45;
  public float spawnrate = 5;
  public GameObject Minions;
  public float bullletStartDistance = 60;
  public float bulletStartSpeed = 70;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if (!awake) return;
    //float perc = ((float)GetComponent<Life>().currentLife / (float)GetComponent<Life>().MaxLife);
    //GetComponent<SpriteRenderer>().color = new Color(1, perc, perc);
    transform.parent.GetComponent<fixedOrbitMovement>().radius = orbit + Mathf.Sin(Time.time* ocillationspeed) * oscillationdistance;
  }
  float orbit = 0;
  public void WakeUp()
  {
    GetComponent<SpriteRenderer>().sprite = AwakeSprite;
    //Life l = gameObject.AddComponent<Life>();
    //l.currentLife = 700;
    //l.MaxLife = 700;
    awake = true;
    transform.parent.GetComponent<fixedOrbitMovement>().orbitSpeed *= 5;
    orbit = transform.parent.GetComponent<fixedOrbitMovement>().radius;
    StartCoroutine(spawnMinions());
  }

  IEnumerator spawnMinions()
  {

    yield return new WaitForSeconds(spawnrate);
    Debug.Log("spawn");
    float Me = 360 - (transform.eulerAngles.z) + 90;
    if (Me > 180) Me -= 360;
    GameObject bullet = Instantiate(Minions, GameObject.Find("Universe/Robo Planet").transform);
    Vector2 dir = new Vector2(Mathf.Sin(Mathf.Deg2Rad * Me), Mathf.Cos(Mathf.Deg2Rad * Me));
    bullet.transform.position = (Vector2)transform.position + dir * bullletStartDistance;
    bullet.GetComponent<Rigidbody2D>().velocity = (dir * bulletStartSpeed);
    StartCoroutine(spawnMinions());
  }
}
