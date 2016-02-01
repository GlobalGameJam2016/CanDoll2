using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public Player script;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			script.hasButtons = true;
			Destroy (GameObject.Find ("Buttons"));
		}
	}
}