using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBossInfoLila : MonoBehaviour
{
    IEnumerator showBossInfo()
    {
        GameObject bossSpawnInfo = GameObject.Find("UICanvas").transform.Find("BossSpawn").gameObject;
        bossSpawnInfo.GetComponentInChildren<Text>().text = "WbgrlWbdrba, mother of WbgrlWbdrba is annoyed. Defeat her by poking her eyes!";
        bossSpawnInfo.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        bossSpawnInfo.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showBossInfo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
