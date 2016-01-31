using UnityEngine;
using System.Collections;

public class Glasses : MonoBehaviour {

	public Player script;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			script.hasGlasses = true;
			Destroy (GameObject.Find ("Glasses"));
		}
	}
}