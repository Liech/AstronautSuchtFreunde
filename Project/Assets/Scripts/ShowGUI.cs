using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowGUI : MonoBehaviour
{

    public void showME()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(transform.GetChild(1).gameObject);
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
