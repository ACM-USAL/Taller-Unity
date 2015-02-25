using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 1.0f;

    private RaycastHit hit;
    private Vector3 move;

	// Update is called once per frame
	void Update () {

	    move = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Vector3 objectForward = transform.InverseTransformDirection(Vector3.forward);
            transform.rotation = Quaternion.LookRotation(objectForward, hit.normal);
        }
	}
}
