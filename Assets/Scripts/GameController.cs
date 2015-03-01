﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject scoreGUI; //Texto con la puntuación
    public int score; //Puntuación (Monedas)
    private GUITexture coin; //Textura para representar las monedas del jugador

    public int nlifes = 3; //Número de vidas iniciales del jugador 
    private GUITexture[] lifes; //Texturas para representar las vidas del jugador

    public static GameController instance = null;

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
        coin = GameObject.FindWithTag("GuiCoin").GetComponentInChildren<GUITexture>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        scoreGUI.guiText.text = "" + score;                 
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
        print("Cargando Level1");
        Application.LoadLevel(1);
    }
}
