using UnityEngine;
using System.Collections;

public class Live : MonoBehaviour {
	private Vector3 move;
	public float speed;
    private int n = -1;
    //public GameObject objetoColisionable;
	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "ColisionableIzq")
            n = 1;
        if (collider.gameObject.tag == "ColisionableDer")
            n = -1;
    }
	void Update () {
		move = new Vector3(n,0,0);
		transform.position += move * speed * Time.deltaTime;
	}
}
