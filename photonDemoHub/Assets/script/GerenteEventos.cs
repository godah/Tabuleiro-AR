using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenteEventos : MonoBehaviour {
	public static int[] eventosCasas = new int[31];
	// Use this for initialization
	void Start () {
		carregaEventos ();
	}

	void Update () {
		
	}

	void carregaEventos(){
		//Neste vetor abaixo coloque o que cada casa irá fazer
		//exemplo evento[x] = 2; para andar + duas casas
		//exemplo evento[x] = -3; para voltar tres casas
		eventosCasas [0] = 0;//inicio deixar zerado
		eventosCasas [1] = 3;
		eventosCasas [2] = 5;
		eventosCasas [3] = -1;
		eventosCasas [4] = -1;
		eventosCasas [5] = 2;
		eventosCasas [6] = 1;
		eventosCasas [7] = 6;
		eventosCasas [8] = 3;
		eventosCasas [9] = 2;
		eventosCasas [10] = 0;//boss
		eventosCasas [11] = 0;
		eventosCasas [12] = 0;
		eventosCasas [13] = -1;
		eventosCasas [14] = 2;
		eventosCasas [15] = 1;
		eventosCasas [16] = -3;
		eventosCasas [17] = 2;
		eventosCasas [18] = -4;
		eventosCasas [19] = 2;
		eventosCasas [20] = 0;//boss
		eventosCasas [21] = 1;
		eventosCasas [22] = 1;
		eventosCasas [23] = -1;
		eventosCasas [24] = -5;
		eventosCasas [25] = 2;
		eventosCasas [26] = 3;
		eventosCasas [27] = -4;
		eventosCasas [28] = -6;
		eventosCasas [29] = 2;
		eventosCasas [30] = 0;//boss final

	}
}
