using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboOnDestroy : MonoBehaviour
{
  bool isQuitting = false;
  void OnApplicationQuit()
  {
    isQuitting = true;
  }
  private void OnDestroy()
  {
    if (isQuitting) return;
    GameObject.Find("Universe/Robo Planet").GetComponent<BossStatus>().bossDefeated = true;
    }
}
