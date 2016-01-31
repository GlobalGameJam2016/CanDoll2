using UnityEngine;
using System.Collections;

public class CandleScript : MonoBehaviour {

	public Player script;
	public GameObject player;
	public GameManager gameManager;
	public bool alreadyCSharper;
	public bool alreadySped = false;
	void OnTriggerEnter2D(Collider2D obj){

		if (obj.gameObject.tag == "Player") {
			
			if (!alreadySped && script.hasShoe) {
				alreadySped = true;
				script.speed = script.speed * 2;
				gameManager.game = false;
				gameManager.items [1].transform.position = gameManager.originalPosition [1];
				gameManager.level++;
			} else if (!alreadyCSharper && script.hasGlasses) {
				alreadyCSharper = true;
			
				script.GetComponentInChildren<Light> ().intensity = 1.8f;
				script.GetComponentInChildren<Light> ().range = 50;
				gameManager.level++;
				Debug.Log ("Touched the candle with glasses");

			} else if (script.hasHair) {
				Debug.Log ("Grabbed the hair");
				gameManager.level++;

			}
		}
	}
}
