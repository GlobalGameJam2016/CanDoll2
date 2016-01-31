using UnityEngine;
using System.Collections;

public class AI1 : MonoBehaviour {

	public Transform target;
	public float speed;
	public float chaseRadius;
	private float distance;
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (transform.position, target.transform.position);
		if (distance < chaseRadius) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
//
//	void OnCollisionEnter2D (Collision2D obj)
//	{
//	}
//

}
