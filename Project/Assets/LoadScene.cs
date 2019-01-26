using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void loadMainScene()
    {
        SceneManager.LoadScene("Space",LoadSceneMode.Single);
        //scen.
    }

    public void Awake()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(gameObject);
    }

}
