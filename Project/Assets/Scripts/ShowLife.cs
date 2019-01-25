using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour {
    public List<Sprite> Lifes;
    public Life Target;

	// Use this for initialization
	void Start () {
    Target = GameObject.Find("Player").GetComponent<Life>();
	}
	
	// Update is called once per frame
	void Update () {    
    int Index = (int)(10.0f*((float)Target.currentLife / (float)Target.MaxLife));
    if (Index < 0) Index = 0;    
    GetComponent<Image>().sprite = Lifes[Index];
 	}
}
