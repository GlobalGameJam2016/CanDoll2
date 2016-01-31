using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTransform;

	void OnTriggerEnter2D(Collider2D obj){
		Debug.Log ("Collided");
		obj.gameObject.transform.position = warpTransform.position;
	}

}
