using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float t = Systems.score_time;
        int minutes = (int)(t / 60.0);
        int seconds = (int)(t - minutes * 60);
        GetComponent<Text>().text = string.Format("{0:00}m:{1:00}s", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
