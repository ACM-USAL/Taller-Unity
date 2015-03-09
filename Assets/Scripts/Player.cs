using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 1.0f; //velocidad del jugador
    public float force = 100f; //fuerza del salto
    public bool onGround = true; //Determina si el jugador está en el suelo para evitar que salte en el aire
    public Transform checkGround; 
    public float checkRadius = 0.07f;
	public LayerMask groundMask; //Capa del suelo para saber sobre qué queremos saltar

	public GameObject life;
	private int nlifes;
	private int score;
	public AudioSource audio;
	public AudioClip[] clips;

    private RaycastHit hit; 
    private Vector3 move;
    
    private Animator animator;
    public float moveTime = 0.1f;
    private GameController gameController;

    void Start()
    {
        gameController = GameController.instance;
        animator = GetComponent<Animator>();
    }

    // se llama en cada intervención de las físicas
    void FixedUpdate()
    {
        if (gameController.nlifes == 0)
            return;
        /***MOVIMIENTO***/
        move = new Vector2(Input.GetAxis("Horizontal"), 0);
        Vector3 newPosition = transform.position + (move * speed * Time.deltaTime);

        double aux = transform.position.x - newPosition.x;
       
        if (aux < 0)
            transform.rotation = new Quaternion(0, 0, 0, 0);
        else if (aux>0)
            transform.rotation = new Quaternion(0, 180, 0, 0);

        if (transform.position != newPosition)
        {
            transform.position += move * speed * Time.deltaTime;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
              
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Vector3 objectForward = transform.InverseTransformDirection(Vector3.forward);
            transform.rotation = Quaternion.LookRotation(objectForward, hit.normal);            
        }

        /***SALTO***/
        onGround = Physics2D.OverlapCircle(checkGround.position, checkRadius, groundMask);

        if (Input.GetKey(KeyCode.W) && onGround)
        {
            animator.SetTrigger("isJumping");
            rigidbody2D.AddForce(new Vector2(0, force));  
			if (!audio.isPlaying){
				audio.clip = clips[2];
				audio.Play();
			}

        }

		/***CAIDA***/
		if (rigidbody2D.velocity.y < -18.5) {
			gameController.ChangeLifes(false);
			rigidbody2D.AddForce(new Vector2(0, force));
			CheckIfGameOver();
			if (!audio.isPlaying){
				audio.clip = clips[3];
				audio.Play();
			}
		}
    }

    /***COLISIONES***/
    void OnTriggerEnter2D(Collider2D other)
    {
        /***MONEDAS***/
        if (other.gameObject.tag == "Coin")
        {
            gameController.score += 10;
            Destroy(other.gameObject);
			if (!audio.isPlaying || audio.clip != clips[0]){
				audio.clip = clips[0];
				audio.Play();
			}
        }
        /***VIDAS***/
        else if (other.gameObject.tag == "Life")
        {
                       
            Destroy(other.gameObject);

            if (gameController.nlifes < 3) //Sólo incrementamos las vidas si tenemos menos de 3
            {
                gameController.ChangeLifes(true);          
            }

			if (!audio.isPlaying){
				audio.clip = clips[4];
				audio.Play();
			}
        }
        /***PUERTA***/
        else if (other.gameObject.tag == "Door")
        {
            ChangeLevel();            
        }
    }

    /***ENEMIGOS***/
    void OnCollisionEnter2D(Collision2D other)
    {       
        if (other.gameObject.tag == "Enemy")
        {
            Vector2 vFinal = other.rigidbody.mass * other.relativeVelocity / (rigidbody2D.mass + other.rigidbody.mass);

            if (vFinal.y < -0.5)
            {
				int numero=Random.Range(0, 101);

				if(numero>=40 && numero<=75)
				{
					Instantiate (life, other.transform.position, other.transform.rotation);
				}
                Destroy(other.gameObject);
                rigidbody2D.AddForce(new Vector2(0, -vFinal.y * 100));
				if (!audio.isPlaying){
					audio.clip = clips[1];
					audio.Play();
				}
            }
            else
            {
                Enemy o = other.gameObject.GetComponent<Enemy>();
                o.ChangeDirection();
                gameController.ChangeLifes(false);
                CheckIfGameOver();
				if (!audio.isPlaying){
					audio.clip = clips[3];
					audio.Play();
				}
            }
        }   
    }

    void CheckIfGameOver()
    {
        if (gameController.nlifes == 0)
        {
            animator.SetTrigger("isDead");
        }
    }

    void ChangeLevel()
    {
        gameController.ChangeLevel();
    }

}

