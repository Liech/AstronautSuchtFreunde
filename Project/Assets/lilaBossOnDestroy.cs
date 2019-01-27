using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilaBossOnDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        GameObject.Find("Universe/lila Planet").GetComponent<BossStatus>().bossDefeated = true;
    }
}
