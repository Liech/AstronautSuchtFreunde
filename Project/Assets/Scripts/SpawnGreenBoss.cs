using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(gravityInfluence))]
public class SpawnGreenBoss : MonoBehaviour
{
  public GameObject boss;
    public float radius;
  public bool showradius = false;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
    Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius);
    for(int i = 0;i < col.Length;i++)
    {
      if (col[i].gameObject.GetComponent<GreenShip>() != null)
        return;
    }
    boss.SetActive(true);
    GameObject g = Instantiate(Resources.Load("BossEntry", typeof(GameObject))) as GameObject;
    Destroy(this);
    }

  public void OnDrawGizmos()
  {
    if (showradius)
    Gizmos.DrawSphere(transform.position, radius);
  }
}
