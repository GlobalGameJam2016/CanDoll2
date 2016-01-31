using UnityEngine;
using System.Collections;

public class ViewCone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Player player = GameObject.Find("Player").GetComponentInChildren<Player>();
            player.hide();
        }
    }
           

	// Update is called once per frame
	void Update () {
    }
}
