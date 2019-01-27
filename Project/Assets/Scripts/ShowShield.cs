using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShowShield : MonoBehaviour {
    public List<Sprite> Lifes;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        int level = GameObject.Find("Player").GetComponent<Systems>().healthLVL;
        GetComponent<Image>().sprite = Lifes[level];
 	}
}
