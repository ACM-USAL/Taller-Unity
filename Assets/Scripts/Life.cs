using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {


	private int nlifes = 3;
	private GUITexture[] lifes;

	// Use this for initialization
	void Start () {
		lifes = GameObject.FindWithTag("GuiLife").GetComponentsInChildren<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {

			Vector2 vFinal = coll.rigidbody.mass * coll.relativeVelocity / (rigidbody2D.mass + coll.rigidbody.mass);

			//Debug.Log ("Velocidad X;Y -> " + vFinal.x + ";" + vFinal.y);

			if (vFinal.y < -0.5){
				Destroy(coll.gameObject);
				rigidbody2D.AddForce(new Vector2(0,-vFinal.y*100));
			} else {
				lifes[nlifes-1].enabled = false;
				nlifes--;
				Destroy(coll.gameObject);
			}
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
