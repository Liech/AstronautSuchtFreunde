using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboOnDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        GameObject.Find("Universe/Robo Planet").GetComponent<BossStatus>().bossDefeated = true;
    }
}
