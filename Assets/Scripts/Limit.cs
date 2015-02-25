using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			other.transform.position = GameObject.FindWithTag("Spawn").transform.position;
		}
		if (other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
		}
	}
}
