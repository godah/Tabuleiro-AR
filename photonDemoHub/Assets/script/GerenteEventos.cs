using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteEventos : MonoBehaviour {
	public static int[] eventosCasas = new int[31];
	// Use this for initialization
	void Start () {
		carregaEventos ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void carregaEventos(){
		eventosCasas [0] = 0;
		eventosCasas [1] = 16;
		eventosCasas [2] = 17;
		eventosCasas [3] = 11;
		eventosCasas [4] = 11;
		eventosCasas [5] = 12;
		eventosCasas [6] = 11;
		eventosCasas [7] = 16;
		eventosCasas [8] = 13;
		eventosCasas [9] = 12;
		eventosCasas [10] = 0;
		eventosCasas [11] = 10;
		eventosCasas [12] = 10;
		eventosCasas [13] = 11;
		eventosCasas [14] = 12;
		eventosCasas [15] = 11;
		eventosCasas [16] = 13;
		eventosCasas [17] = 12;
		eventosCasas [18] = 14;
		eventosCasas [19] = 12;
		eventosCasas [20] = 0;
		eventosCasas [21] = 11;
		eventosCasas [22] = 11;
		eventosCasas [23] = 11;
		eventosCasas [24] = 15;
		eventosCasas [25] = 12;
		eventosCasas [26] = 13;
		eventosCasas [27] = 14;
		eventosCasas [28] = 16;
		eventosCasas [29] = 12;
		eventosCasas [30] = 0;

	}
}
