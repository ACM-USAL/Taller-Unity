using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	
	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            print("Cargando Level1");
            Application.LoadLevel("Level1");
        }
    }
}
