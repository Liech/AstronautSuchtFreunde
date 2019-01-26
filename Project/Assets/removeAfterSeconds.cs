using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeAfterSeconds : MonoBehaviour
{
  public float deleteAfterSeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(rem());
    }

  IEnumerator rem()
  {
    yield return new WaitForSeconds(deleteAfterSeconds);
    Destroy(gameObject);
  }

  // Update is called once per frame
  void Update()
  {
        
  }
}
