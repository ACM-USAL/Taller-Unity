using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 1.0f;

    private RaycastHit hit;
    private Vector3 move;
    private float n;
    private float life = 100;

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Suelo")
            n = 10;
        if (colision.gameObject.tag == "Enemy")
        {
            life -= 100;
            print("Dead!!!!!");
            //Application.LoadLevel("Level0");
        }
    }
    void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Suelo")
            n = 0;
    }

	void Update () {
        //anim = GetComponent<Animator> ();
	    move = new Vector3(Input.GetAxis("Horizontal"), n*Input.GetAxis("Vertical"),0);
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
