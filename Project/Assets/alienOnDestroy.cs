using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienOnDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        GameObject.Find("Universe/grüner Planet").GetComponent<BossStatus>().bossDefeated = true;
    }
}
