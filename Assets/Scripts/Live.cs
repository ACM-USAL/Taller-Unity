using UnityEngine;
using System.Collections;

public class Live : MonoBehaviour {


	private int nlifes = 3;
	public GUITexture[] lifes = new GUITexture[3]; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			lifes[nlifes-1].enabled = false;
			nlifes--;
			Destroy(coll.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Life" && nlifes < 3) {
			nlifes++;
			lifes[nlifes-1].enabled = true;
			Destroy(other.gameObject);
		}
	}
}
