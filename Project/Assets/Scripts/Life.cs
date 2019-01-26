using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
  public int currentLife;
  public int MaxLife;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if (currentLife <= 0)
    {      
      GameObject g = Instantiate(Resources.Load("DeathExplosion", typeof(GameObject))) as GameObject;
      g.transform.position = transform.position;
      Destroy(gameObject);
    }
  }
}
