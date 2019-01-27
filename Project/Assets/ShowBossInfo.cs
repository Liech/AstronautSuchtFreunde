using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBossInfo : MonoBehaviour
{

    IEnumerator showBossInfo()
    {
        GameObject bossSpawnInfo = GameObject.Find("UICanvas").transform.Find("BossSpawn").gameObject;
        bossSpawnInfo.GetComponentInChildren<Text>().text = "FT, protector of Planet51 seaks revange. MUUUUUUUHHHH!";
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
