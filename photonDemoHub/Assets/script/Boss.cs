using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
	public GameObject canvasBoss;
	public Text txtResp1;
	public Text txtResp2;
	public Text txtResp3;
	public Text txtResp4;
	public Text txtBoss;
	public GameObject Gorilla;
	public GameObject Tiger;
	public GameObject Spider;
	public GameObject PanelAjuda;
	public GameObject acertou;
	public GameObject errou;

	//Respostas da pergutna em contexo
	public static bool A;
	public static bool B;
	public static bool C;
	public static bool D;
	public static int voltar;

	public static Chefe[] chefes = new Chefe[3];

	void Start () {


		//=======================================================================================================
		//					BOSS SPIDER 0
		//=======================================================================================================
		//chefe Spider 0
		chefes[0] = new Chefe();
		chefes [0].nome = "Spider";
		chefes [0].casa = 10;
		chefes [0].penalidade = -4;

		//pergunta 1 Spider 0
		chefes [0].perguntas [0].txtPergunta = "Pergunta 1 SPIDER";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [0].respostas [0].txtResp = "Resposta 1 SPIDER";
		chefes [0].perguntas [0].respostas [0].resp = true;

		chefes [0].perguntas [0].respostas [1].txtResp = "Resposta 2 SPIDER";
		chefes [0].perguntas [0].respostas [1].resp = false;

		chefes [0].perguntas [0].respostas [2].txtResp = "Resposta 3 SPIDER";
		chefes [0].perguntas [0].respostas [2].resp = false;

		chefes [0].perguntas [0].respostas [3].txtResp = "Resposta 4 SPIDER";
		chefes [0].perguntas [0].respostas [3].resp = false;


		//pergunta 2 Spider 0
		chefes [0].perguntas [1].txtPergunta = "Pergunta 2 SPIDER";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [1].respostas [0].txtResp = "Resposta 1 SPIDER";
		chefes [0].perguntas [1].respostas [0].resp = true;

		chefes [0].perguntas [1].respostas [1].txtResp = "Resposta 2 SPIDER";
		chefes [0].perguntas [1].respostas [1].resp = false;

		chefes [0].perguntas [1].respostas [2].txtResp = "Resposta 3 SPIDER";
		chefes [0].perguntas [1].respostas [2].resp = false;

		chefes [0].perguntas [1].respostas [3].txtResp = "Resposta 4 SPIDER";
		chefes [0].perguntas [1].respostas [3].resp = false;


		//pergunta 3 Spider 0
		chefes [0].perguntas [2].txtPergunta = "Pergunta 3 SPIDER";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [2].respostas [0].txtResp = "Resposta 1 SPIDER";
		chefes [0].perguntas [2].respostas [0].resp = true;

		chefes [0].perguntas [2].respostas [1].txtResp = "Resposta 2 SPIDER";
		chefes [0].perguntas [2].respostas [1].resp = false;

		chefes [0].perguntas [2].respostas [2].txtResp = "Resposta 3 SPIDER";
		chefes [0].perguntas [2].respostas [2].resp = false;

		chefes [0].perguntas [2].respostas [3].txtResp = "Resposta 4 SPIDER";
		chefes [0].perguntas [2].respostas [3].resp = false;


		//pergunta 4 Spider 0
		chefes [0].perguntas [3].txtPergunta = "Pergunta 4 SPIDER";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [3].respostas [0].txtResp = "Resposta 1 SPIDER";
		chefes [0].perguntas [3].respostas [0].resp = true;

		chefes [0].perguntas [3].respostas [1].txtResp = "Resposta 2 SPIDER";
		chefes [0].perguntas [3].respostas [1].resp = false;

		chefes [0].perguntas [3].respostas [2].txtResp = "Resposta 3 SPIDER";
		chefes [0].perguntas [3].respostas [2].resp = false;

		chefes [0].perguntas [3].respostas [3].txtResp = "Resposta 4 SPIDER";
		chefes [0].perguntas [3].respostas [3].resp = false;


		//pergunta 5 Spider 0
		chefes [0].perguntas [4].txtPergunta = "Pergunta 5 SPIDER";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [4].respostas [0].txtResp = "Resposta 1 SPIDER";
		chefes [0].perguntas [4].respostas [0].resp = true;
		
		chefes [0].perguntas [4].respostas [1].txtResp = "Resposta 2 SPIDER";
		chefes [0].perguntas [4].respostas [1].resp = false;

		chefes [0].perguntas [4].respostas [2].txtResp = "Resposta 3 SPIDER";
		chefes [0].perguntas [4].respostas [2].resp = false;

		chefes [0].perguntas [4].respostas [3].txtResp = "Resposta 4 SPIDER";
		chefes [0].perguntas [4].respostas [3].resp = false;


		//=======================================================================================================
		//					BOSS TIGER 1
		//=======================================================================================================

		//chefe Tiger 1
		chefes[1] = new Chefe();
		chefes [1].nome = "Tiger";
		chefes [1].casa = 20;
		chefes [1].penalidade = -3;

		//pergunta 1 Tiger 1
		chefes [1].perguntas [0].txtPergunta = "Pergunta 1 TIGER";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [0].respostas [0].txtResp = "Resposta 1 TIGER";
		chefes [1].perguntas [0].respostas [0].resp = true;

		chefes [1].perguntas [0].respostas [1].txtResp = "Resposta 2 TIGER";
		chefes [1].perguntas [0].respostas [1].resp = false;

		chefes [1].perguntas [0].respostas [2].txtResp = "Resposta 3 TIGER";
		chefes [1].perguntas [0].respostas [2].resp = false;

		chefes [1].perguntas [0].respostas [3].txtResp = "Resposta 4 TIGER";
		chefes [1].perguntas [0].respostas [3].resp = false;


		//pergunta 2 Tiger 1
		chefes [1].perguntas [1].txtPergunta = "Pergunta 2 TIGER";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [1].respostas [0].txtResp = "Resposta 1 TIGER";
		chefes [1].perguntas [1].respostas [0].resp = true;

		chefes [1].perguntas [1].respostas [1].txtResp = "Resposta 2 TIGER";
		chefes [1].perguntas [1].respostas [1].resp = false;

		chefes [1].perguntas [1].respostas [2].txtResp = "Resposta 3 TIGER";
		chefes [1].perguntas [1].respostas [2].resp = false;

		chefes [1].perguntas [1].respostas [3].txtResp = "Resposta 4 TIGER";
		chefes [1].perguntas [1].respostas [3].resp = false;


		//pergunta 3 Tiger 1
		chefes [1].perguntas [2].txtPergunta = "Pergunta 3 TIGER";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [2].respostas [0].txtResp = "Resposta 1 TIGER";
		chefes [1].perguntas [2].respostas [0].resp = true;

		chefes [1].perguntas [2].respostas [1].txtResp = "Resposta 2 TIGER";
		chefes [1].perguntas [2].respostas [1].resp = false;

		chefes [1].perguntas [2].respostas [2].txtResp = "Resposta 3 TIGER";
		chefes [1].perguntas [2].respostas [2].resp = false;

		chefes [1].perguntas [2].respostas [3].txtResp = "Resposta 4 TIGER";
		chefes [1].perguntas [2].respostas [3].resp = false;


		//pergunta 4 Tiger 1
		chefes [1].perguntas [3].txtPergunta = "Pergunta 4 TIGER";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [3].respostas [0].txtResp = "Resposta 1 TIGER";
		chefes [1].perguntas [3].respostas [0].resp = true;

		chefes [1].perguntas [3].respostas [1].txtResp = "Resposta 2 TIGER";
		chefes [1].perguntas [3].respostas [1].resp = false;

		chefes [1].perguntas [3].respostas [2].txtResp = "Resposta 3 TIGER";
		chefes [1].perguntas [3].respostas [2].resp = false;

		chefes [1].perguntas [3].respostas [3].txtResp = "Resposta 4 TIGER";
		chefes [1].perguntas [3].respostas [3].resp = false;


		//pergunta 5 Tiger 1
		chefes [1].perguntas [4].txtPergunta = "Pergunta 5 TIGER";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [4].respostas [0].txtResp = "Resposta 1 TIGER";
		chefes [1].perguntas [4].respostas [0].resp = true;

		chefes [1].perguntas [4].respostas [1].txtResp = "Resposta 2 TIGER";
		chefes [1].perguntas [4].respostas [1].resp = false;

		chefes [1].perguntas [4].respostas [2].txtResp = "Resposta 3 TIGER";
		chefes [1].perguntas [4].respostas [2].resp = false;

		chefes [1].perguntas [4].respostas [3].txtResp = "Resposta 4 TIGER";
		chefes [1].perguntas [4].respostas [3].resp = false;



		//=======================================================================================================
		//					BOSS GORILLA 2 FINAL
		//=======================================================================================================

		//chefe Tiger 1
		chefes[2] = new Chefe();
		chefes [2].nome = "Gorilla";
		chefes [2].casa = 30;
		chefes [2].penalidade = -5;

		//pergunta 1 Tiger 1
		chefes [2].perguntas [0].txtPergunta = "Pergunta 1 GORILLA";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [0].respostas [0].txtResp = "Resposta 1 GORILLA";
		chefes [2].perguntas [0].respostas [0].resp = true;

		chefes [2].perguntas [0].respostas [1].txtResp = "Resposta 2 GORILLA";
		chefes [2].perguntas [0].respostas [1].resp = false;

		chefes [2].perguntas [0].respostas [2].txtResp = "Resposta 3 GORILLA";
		chefes [2].perguntas [0].respostas [2].resp = false;

		chefes [2].perguntas [0].respostas [3].txtResp = "Resposta 4 GORILLA";
		chefes [2].perguntas [0].respostas [3].resp = false;


		//pergunta 2 Tiger 1
		chefes [2].perguntas [1].txtPergunta = "Pergunta 2 GORILLA";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [1].respostas [0].txtResp = "Resposta 1 GORILLA";
		chefes [2].perguntas [1].respostas [0].resp = true;

		chefes [2].perguntas [1].respostas [1].txtResp = "Resposta 2 GORILLA";
		chefes [2].perguntas [1].respostas [1].resp = false;

		chefes [2].perguntas [1].respostas [2].txtResp = "Resposta 3 GORILLA";
		chefes [2].perguntas [1].respostas [2].resp = false;

		chefes [2].perguntas [1].respostas [3].txtResp = "Resposta 4 GORILLA";
		chefes [2].perguntas [1].respostas [3].resp = false;


		//pergunta 3 Tiger 1
		chefes [2].perguntas [2].txtPergunta = "Pergunta 3 GORILLA";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [2].respostas [0].txtResp = "Resposta 1 GORILLA";
		chefes [2].perguntas [2].respostas [0].resp = true;
		
		chefes [2].perguntas [2].respostas [1].txtResp = "Resposta 2 GORILLA";
		chefes [2].perguntas [2].respostas [1].resp = false;

		chefes [2].perguntas [2].respostas [2].txtResp = "Resposta 3 GORILLA";
		chefes [2].perguntas [2].respostas [2].resp = false;

		chefes [2].perguntas [2].respostas [3].txtResp = "Resposta 4 GORILLA";
		chefes [2].perguntas [2].respostas [3].resp = false;


		//pergunta 4 Tiger 1
		chefes [2].perguntas [3].txtPergunta = "Pergunta 4 GORILLA";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [3].respostas [0].txtResp = "Resposta 1 GORILLA";
		chefes [2].perguntas [3].respostas [0].resp = true;

		chefes [2].perguntas [3].respostas [1].txtResp = "Resposta 2 GORILLA";
		chefes [2].perguntas [3].respostas [1].resp = false;

		chefes [2].perguntas [3].respostas [2].txtResp = "Resposta 3 GORILLA";
		chefes [2].perguntas [3].respostas [2].resp = false;

		chefes [2].perguntas [3].respostas [3].txtResp = "Resposta 4 GORILLA";
		chefes [2].perguntas [3].respostas [3].resp = false;


		//pergunta 5 Tiger 1
		chefes [2].perguntas [4].txtPergunta = "Pergunta 5 GORILLA";
		
		//adiciona respostas a lista de respostas
		chefes [2].perguntas [4].respostas [0].txtResp = "Resposta 1 GORILLA";
		chefes [2].perguntas [4].respostas [0].resp = true;

		chefes [2].perguntas [4].respostas [1].txtResp = "Resposta 2 GORILLA";
		chefes [2].perguntas [4].respostas [1].resp = false;

		chefes [2].perguntas [4].respostas [2].txtResp = "Resposta 3 GORILLA";
		chefes [2].perguntas [4].respostas [2].resp = false;

		chefes [2].perguntas [4].respostas [3].txtResp = "Resposta 4 GORILLA";
		chefes [2].perguntas [4].respostas [3].resp = false;



	}
	
	void Update () {
		//Teste
//		Debug.Log ("chefe "+chefes[0].nome+" casa"+chefes[0].casa.ToString()+" penalidade"+ chefes[0].penalidade.ToString());
//		Debug.Log ("pergunta 1 "+chefes[0].perguntas[0].txtPergunta);
//		Debug.Log ("pergunta 3 "+chefes[0].perguntas[2].txtPergunta);
//		Debug.Log ("resposta 1 "+chefes[2].perguntas[4].respostas[3].txtResp+" "+chefes[2].perguntas[4].respostas[3].resp);


	}

	public void btnA(){
		if (A) {
			acertou.SetActive (true);
			txtBoss.text = "Você errou!!! Volte "+voltar+" casas.";
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
		} else {
			errou.SetActive (true);
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
		}
	}

	public void btnB(){
		if (B) {
			acertou.SetActive (true);
			txtBoss.text = "Você errou!!! Volte "+voltar+" casas.";
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
		} else {
			errou.SetActive (true);
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
		}
	}


	public void btnC(){
		if (C) {
			acertou.SetActive (true);
			txtBoss.text = "Você errou!!! Volte "+voltar+" casas.";
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
		} else {
			errou.SetActive (true);
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
		}
	}

	public void btnD(){
		if (D) {
			acertou.SetActive (true);
			txtBoss.text = "Você errou!!! Volte "+voltar+" casas.";
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
		} else {
			errou.SetActive (true);
			waitClear (5);
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
		}
	}

	/// <summary>
	/// Aguarda para limpar tela
	/// </summary>
	IEnumerator waitClear(float time){
		yield return new WaitForSeconds (time);
		acertou.SetActive (false);
		acertou.SetActive (false);
		PanelAjuda.SetActive (false);
		canvasBoss.SetActive (false);
	}
}

public class Chefe{
	public string nome;
	public int casa;
	public int penalidade;
	public Pergunta[] perguntas = new Pergunta[5];

	public Chefe(){
		nome = null;
		casa = 0;
		penalidade = 0;
		perguntas[0]= new Pergunta();
		perguntas[1]= new Pergunta();
		perguntas[2]= new Pergunta();
		perguntas[3]= new Pergunta();
		perguntas[4]= new Pergunta();
	}
}

public class Pergunta{
	public string txtPergunta;
	public Resposta[] respostas = new Resposta[4];

	public Pergunta(){
		txtPergunta = null;
		respostas [0] = new Resposta ();
		respostas [1] = new Resposta ();
		respostas [2] = new Resposta ();
		respostas [3] = new Resposta ();
	}
}

public class Resposta{
	public string txtResp;
	public bool resp;

	public Resposta(){
		txtResp = null;
		resp = false;
	}
}

