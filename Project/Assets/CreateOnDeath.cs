using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDeath : MonoBehaviour
{
  bool isQuitting = false;
  public GameObject Obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  void OnApplicationQuit()
  {
    isQuitting = true;
  }
  private void OnDestroy()
  {
    if (isQuitting) return;
    GameObject g= Instantiate(Obj);
    g.transform.position = transform.position;
  }
  // Update is called once per frame
  void Update()
    {
        
    }
}
