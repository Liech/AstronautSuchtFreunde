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
      Destroy(gameObject);
  }
}
