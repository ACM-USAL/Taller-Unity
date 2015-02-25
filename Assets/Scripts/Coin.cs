using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private GameObject scoreGUI;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreGUI = GameObject.FindWithTag("Score");
	}
	
	// Update is called once per frame
	void Update () {
		scoreGUI.guiText.text = "Score: " + score;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Coin") {
			score += 10;
			Destroy(other.gameObject);
		}
	}
}
