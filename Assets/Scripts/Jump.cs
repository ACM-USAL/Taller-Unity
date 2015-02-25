using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	
	public float force = 100f;
	
	public bool onGround = true;
	public Transform checkGround;
	public float checkRadius = 0.07f;
	public LayerMask groundMask;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		onGround = Physics2D.OverlapCircle(checkGround.position, checkRadius, groundMask);

		if (Input.GetKey (KeyCode.W) && onGround) {
			rigidbody2D.AddForce(new Vector2(0, force));
		}
	}
}
