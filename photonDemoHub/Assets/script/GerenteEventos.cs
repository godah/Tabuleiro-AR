using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteEventos : MonoBehaviour {
	public static int[] eventosCasas = new int[32];
	// Use this for initialization
	void Start () {
		carregaEventos ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void carregaEventos(){
		eventosCasas [0] = 0; // inicio
		eventosCasas [1] = 1; //
		eventosCasas [2] = 2;//
		eventosCasas [3] = 0;//
		eventosCasas [4] = 1;//
		eventosCasas [5] = 4;//
		eventosCasas [6] = 0;//
		eventosCasas [7] = 5;//
		eventosCasas [8] = 0;//
		eventosCasas [9] = 0;//
		eventosCasas [10] = 0;//boss
		eventosCasas [11] = 0;//pos boss
		eventosCasas [12] = 3; //
		eventosCasas [13] = -1;//
		eventosCasas [14] = 3;//
		eventosCasas [15] = 0;//
		eventosCasas [16] = -2;//
		eventosCasas [17] = 4;//
		eventosCasas [18] = -2;//
		eventosCasas [19] = 2;//
		eventosCasas [20] = 0;//boss
		eventosCasas [21] = 0;//pos boss
		eventosCasas [22] = -1;//
		eventosCasas [23] = -2;//
		eventosCasas [24] = 3;//
		eventosCasas [25] = -4;//
		eventosCasas [26] = 1;//
		eventosCasas [27] = -2;//
		eventosCasas [28] = 0;//
		eventosCasas [29] = -5;//
		eventosCasas [30] = 0;//boss
		eventosCasas [31] = 0;//final

	}
}
