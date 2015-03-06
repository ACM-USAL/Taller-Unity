using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private Vector3 move;
    public float speed;
    private int n = 1;
    private float alpha = 0;

    void Update()
    {
        move = new Vector3(n, 0, 0);
        transform.position += move * speed * Time.deltaTime;        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Enemycollider")
        {            
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        n *= -1;
        alpha = (alpha == 180) ? 0 : 180;
        transform.rotation = new Quaternion(0, alpha, 0, 0);
    }
}
