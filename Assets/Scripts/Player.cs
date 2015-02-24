using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 1.0f;

    private RaycastHit hit;
    private Vector3 move;
    //public Animator anim;
    //public Animation animat;

	// Update is called once per frame
	void Update () {
        //anim = GetComponent<Animator> ();
	    move = new Vector3(Input.GetAxis("Horizontal"), 10*Input.GetAxis("Vertical"),0);
        transform.position += move * speed * Time.deltaTime;
        //anim.SetTrigger("PlayerWalk");
        //animat.Start();
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Vector3 objectForward = transform.InverseTransformDirection(Vector3.forward);
            transform.rotation = Quaternion.LookRotation(objectForward, hit.normal);
        }
	}
}
