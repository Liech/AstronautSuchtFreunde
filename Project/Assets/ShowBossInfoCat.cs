using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBossInfoCat : MonoBehaviour
{
    IEnumerator showBossInfo()
    {
        GameObject bossSpawnInfo = GameObject.Find("UICanvas").transform.Find("BossSpawn").gameObject;
        bossSpawnInfo.GetComponentInChildren<Text>().text = "Fluffotron, defender of Fluffington challenges you. Defeat him!";
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
