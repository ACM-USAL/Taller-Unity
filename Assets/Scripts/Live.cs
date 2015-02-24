using UnityEngine;
using System.Collections;

public class Live : MonoBehaviour {
	private Vector3 move;
	public float speed;
	// Update is called once per frame
	void Update () {
		move = new Vector3(-1,0,0);
		transform.position += move * speed * Time.deltaTime;
	}
}
