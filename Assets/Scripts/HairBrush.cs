using UnityEngine;
using System.Collections;

public class HairBrush : MonoBehaviour {

	public Player script;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			script.hasHair = true;
			Destroy (GameObject.Find ("HairBrush"));
		}
	}
}