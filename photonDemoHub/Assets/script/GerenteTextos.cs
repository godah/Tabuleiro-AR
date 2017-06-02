using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteTextos : MonoBehaviour {
	public static string[] textosCasas = new string[31];

	void Start () {
		carregaTextos ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void carregaTextos(){
		textosCasas [0] = "Inicio";
		textosCasas [1] = "1";
		textosCasas [2] = "2";
		textosCasas [3] = "3";
		textosCasas [4] = "4";
		textosCasas [5] = "5";
		textosCasas [6] = "6";
		textosCasas [7] = "7";
		textosCasas [8] = "8";
		textosCasas [9] = "9";
		textosCasas [10] = "Boss SPIDER";
		textosCasas [11] = "11";
		textosCasas [12] = "12";
		textosCasas [13] = "13";
		textosCasas [14] = "14";
		textosCasas [15] = "15";
		textosCasas [16] = "0";
		textosCasas [17] = "1";
		textosCasas [18] = "2";
		textosCasas [19] = "3";
		textosCasas [20] = "Boss TIGER";
		textosCasas [21] = "5";
		textosCasas [22] = "6";
		textosCasas [23] = "7";
		textosCasas [24] = "8";
		textosCasas [25] = "9";
		textosCasas [26] = "10";
		textosCasas [27] = "11";
		textosCasas [28] = "12";
		textosCasas [29] = "13";
		textosCasas [30] = "Boss GORILLA";


	}
}
