using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedMechOnDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        GameObject.Find("Universe/Cat Planet").GetComponent<BossStatus>().bossDefeated = true;
    }
}
