using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboBossBehavior : MonoBehaviour
{
  public float rotationSpeed = 1;
  float rot = 0;

  public Sprite AwakeSprite;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void WakeUp()
  {
    GetComponent<SpriteRenderer>().sprite = AwakeSprite;
  }
}
