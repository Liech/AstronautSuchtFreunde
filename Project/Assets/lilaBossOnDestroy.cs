using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilaBossOnDestroy : MonoBehaviour
{
  bool isQuitting = false;
  void OnApplicationQuit()
  {
    isQuitting = true;
  }
  private void OnDestroy()
  {
    GameObject.Find("Universe/lila Planet").GetComponent<BossStatus>().bossDefeated = true;
    }
}
