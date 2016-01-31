using UnityEngine;
using System.Collections;

public class DetectCone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //    Player player = (Player)other;
            Player player = GameObject.Find("Player").GetComponentInChildren<Player>();
            player.detect();
        }
    }


	// Update is called once per frame
	void Update () {
	
	}
}
