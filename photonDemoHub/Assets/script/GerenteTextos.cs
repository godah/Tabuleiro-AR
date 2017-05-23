using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteTextos : MonoBehaviour {
	public static string[] textosCasas = new string[31];

	void Start () {
		carregaTextos ();

	}
	
	void Update () {
		
	}


	void carregaTextos(){
		//aqui neste vetor colocar os textos
		//exemplo textosCasas[x] = "Você encontrou o caminho livre corra mais duas casas!";
		//exemplo textosCasas[x] = "Escorregou na lama, volte 1 casa!";
		textosCasas [0] = "Inicio";//inicio não tem texto
		textosCasas [1] = "1";
		textosCasas [2] = "2";
		textosCasas [3] = "3";
		textosCasas [4] = "4";
		textosCasas [5] = "5";
		textosCasas [6] = "6";
		textosCasas [7] = "7";
		textosCasas [8] = "8";
		textosCasas [9] = "9";
		textosCasas [10] = "boss";//boss
		textosCasas [11] = "11";
		textosCasas [12] = "12";
		textosCasas [13] = "13";
		textosCasas [14] = "14";
		textosCasas [15] = "15";
		textosCasas [16] = "0";
		textosCasas [17] = "1";
		textosCasas [18] = "2";
		textosCasas [19] = "3";
		textosCasas [20] = "boss";//boss
		textosCasas [21] = "5";
		textosCasas [22] = "6";
		textosCasas [23] = "7";
		textosCasas [24] = "8";
		textosCasas [25] = "9";
		textosCasas [26] = "10";
		textosCasas [27] = "11";
		textosCasas [28] = "12";
		textosCasas [29] = "13";
		textosCasas [30] = "boss";//boss final


	}
}
