using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameTime : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int duration = (int)(Time.time - Systems.start_time);
        string str = (duration / 60).ToString("D2") + ":" + (duration % 60).ToString("D2");
        GetComponent<Text>().text = str;
    }
}
