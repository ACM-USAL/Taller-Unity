using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject scoreGUI; //Texto con la puntuación
    public int score; //Puntuación (Monedas)
	private GUITexture coin; //Textura para representar las monedas del jugador

    public int nlifes = 3; //Número de vidas iniciales del jugador 
	private GUITexture[] lifes; //Texturas para representar las vidas del jugador

    public static GameController instance = null;
    public int level;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

	// Use this for initialization
	void Start ()
    {
        score = 0;
        scoreGUI = GameObject.FindWithTag("Score");        

        lifes = GameObject.FindWithTag("GuiLife").GetComponentsInChildren<GUITexture>();
        //coin = GameObject.FindWithTag("GuiCoin").GetComponentInChildren<GUITexture>();
        level = 0;
    }
	
	// Update is called once per frame
	void Update () 
    {
		if (scoreGUI == null)
			scoreGUI = GameObject.FindWithTag("Score"); 
		if (lifes[0] == null)
			lifes = GameObject.FindWithTag("GuiLife").GetComponentsInChildren<GUITexture>();
		if (Input.GetKey(KeyCode.Q))
			Application.Quit();
		if (Input.GetKey (KeyCode.R)) {
			level = -1;
			ChangeLevel();
			nlifes = 3;
			for (int i = 0; i < lifes.Length; i++){
				lifes[i].enabled = true;
			}
			score = 0;
		}

        scoreGUI.guiText.guiText.text = "" + score;
	}

    public void ChangeLifes(bool a)
    {
        if (nlifes == 0)
            return;
        if (a)
        {
            lifes[nlifes].enabled = a;
            nlifes++;
        }
        else
        {
            lifes[nlifes - 1].enabled = a;
            nlifes--;
        }
    }

    public void ChangeLevel()
    {
        //print("Cargando Level1");
        level++;
        Application.LoadLevel(level);
    }
}
