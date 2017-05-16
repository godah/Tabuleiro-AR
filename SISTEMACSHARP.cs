using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SISTEMACSHARP : MonoBehaviour {

	//var casas : Transform[];
	public Transform[] casas = new Transform[30];
	//public List<Transform> casas = new List<Transform>();

	//private var casaAtual : int = 0;
	private int casaAtual = 0;

	//var dado : int;
	public int dado;

	//30
	//var isCasa : boolean[];
	public bool[] isCasa = new bool[30] { false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false };
	//isCasa = [];

	//var isCasaVoltar : boolean = false;
	public bool isCasaVoltar = false;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}



	void OnGUI()
	{
		if(!isCasaVoltar)
		{
			if(GUI.Button(new Rect(10,10,150,50), "RODAR DADO"))
			{
				dado = Random.Range(1,6);
				
				//print("print do btn p/ rodar dado. casa atual: " + casaAtual + " dado: " + dado);

				VerificarCasa();
			}
		}
		
		//Casas com boss

		//Casas que fazem voltar
		if(isCasa[7])
		{
			isCasaVoltar = true;

			if(GUI.Button(new Rect(100,100,300,150), "Você voltará 3 casas"))
			{
				casaAtual -= 3;

				transform.position = casas[casaAtual].position;

				//print("casa atual: " + casaAtual + " dado: " + dado);

				isCasa[7] = false;
				isCasaVoltar = false;
			}
		}

		if(isCasa[13])
		{
			isCasaVoltar = true;

			if(GUI.Button(new Rect(100,100,300,150), "Você voltará 2 casas"))
			{
				casaAtual -= 2;

				transform.position = casas[casaAtual].position;

				//print("casa atual: " + casaAtual + " dado: " + dado);

				isCasa[13] = false;
				isCasaVoltar = false;
			}
		}

	}

	//               <   !							   !							 !
	// 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29
	void VerificarCasa()
	{
		//Veirifica se a casa para a qual o jogador vai é de algum boss
		for(int i=0; i < dado; i++)
		{
			casaAtual++;

			if(casaAtual == 9)
			{
				
			}

			if(casaAtual == 19)
			{
				
			}

			if(casaAtual == 29)
			{
				
			}
		}

		//print("casa atual: " + casaAtual + " dado: " + dado);
		//print(casas.length + "" + casas[casaAtual].position);

		//Veirifica se a casa para a qual o jogador vai é uma casa que faz voltar
		if(casaAtual == 7)
		{
			transform.position = casas[casaAtual].position;
			//print("casa atual: " + casaAtual + " dado: " + dado);
			isCasa[7] = true;

			return;
		}

		if(casaAtual == 13)
		{
			transform.position = casas[casaAtual].position;
			//print("casa atual: " + casaAtual + " dado: " + dado);
			isCasa[13] = true;

			return;
		}

		if(casaAtual < casas.Length) //casas.length
		{	
			
			transform.position = casas[casaAtual].position;
			
			//print("casa atual: " + casaAtual + " dado: " + dado);
		}
		else
			casaAtual -= dado;



	}



}