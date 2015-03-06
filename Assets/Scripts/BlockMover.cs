using UnityEngine;
using System.Collections;

/** IMPORTANTE 
 * Las posiciones iniciales deben ser menores que las posiciones 
 * finales para el correcto funcionamiento del script. Ademas es necesario
 * que el objeto no se encuentre en una posicion relativa hacia otro objeto.
*/

public class BlockMover : MonoBehaviour {

	public Vector2 startPosition;
	public Vector2 endPosition;

	public float smoothValorX = 2f;
	public float smoothValorY = 2f;

	// Use this for initialization
	void Start () {

		if (startPosition == null || endPosition == null) {
			startPosition = transform.position;
			endPosition = transform.position;
		}

		transform.position = startPosition;


	}
	
	// Update is called once per frame
	void Update () {

		//Movimiento en el eje X
		if (startPosition.x != endPosition.x) {

			transform.Translate(smoothValorX * Time.deltaTime,0,0);

			if (transform.position.x <= startPosition.x || transform.position.x >= endPosition.x){
				smoothValorX = -smoothValorX;
			}
		}

		//Movimiento en el eje Y
		if (startPosition.y != endPosition.y) {
			
			transform.Translate(0, smoothValorY * Time.deltaTime, 0);
			
			if (transform.position.y <= startPosition.y || transform.position.y >= endPosition.y){
				smoothValorY = -smoothValorY;
			}
		}


	}
}
