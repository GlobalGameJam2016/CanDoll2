using UnityEngine;
using System.Collections;

public class Shoes : MonoBehaviour {

	public Player script;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			script.hasShoe = true;
			Destroy (GameObject.Find ("Shoes"));
		}
	}
}
