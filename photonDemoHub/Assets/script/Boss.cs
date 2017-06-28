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
	public GameObject PanelBtn;

	//Respostas da pergutna em contexo
	public static bool A;
	public static bool B;
	public static bool C;
	public static bool D;
	public static int voltar;

	public static Chefe[] chefes = new Chefe[3];

	void Start () {


		//=======================================================================================================
		//					BOSS SPIDER 0 Matemática
		//=======================================================================================================
		//chefe Spider 0
		chefes [0] = new Chefe();
		chefes [0].nome = "Spider";
		chefes [0].casa = 10;
		chefes [0].penalidade = 6;

		//pergunta 1 Spider 0
		chefes [0].perguntas [0].txtPergunta = "Frações! Uma Barra de chocolate possui 4 camadas , pedro comeu 2 dessas camadas , qual a medida fracionária que corresponde a parte do chocolate que pedro comeu?";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [0].respostas [0].txtResp = "1/3";
		chefes [0].perguntas [0].respostas [0].resp = false;

		chefes [0].perguntas [0].respostas [1].txtResp = "1/2";
		chefes [0].perguntas [0].respostas [1].resp = true;

		chefes [0].perguntas [0].respostas [2].txtResp = "1/4";
		chefes [0].perguntas [0].respostas [2].resp = false;

		chefes [0].perguntas [0].respostas [3].txtResp = "1/5";
		chefes [0].perguntas [0].respostas [3].resp = false;


		//pergunta 2 Spider 0
		chefes [0].perguntas [1].txtPergunta = "Operações Básicas! Por ocasião das Olimpíadas de Pequim, o jornalzinho de um colégio publicou uma notícia com a seguinte manchete: “População da China é a maior do mundo com 1,307 bilhão de habitantes”. De acordo com essa informação, a população da China supera 1 bilhão de habitantes em:";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [1].respostas [0].txtResp = "307 mil";
		chefes [0].perguntas [1].respostas [0].resp = false;

		chefes [0].perguntas [1].respostas [1].txtResp = " 3,07 milhões";
		chefes [0].perguntas [1].respostas [1].resp = false;

		chefes [0].perguntas [1].respostas [2].txtResp = "307 milhões";
		chefes [0].perguntas [1].respostas [2].resp = true;

		chefes [0].perguntas [1].respostas [3].txtResp = "3,07 bilhões";
		chefes [0].perguntas [1].respostas [3].resp = false;


		//pergunta 3 Spider 0
		chefes [0].perguntas [2].txtPergunta = "Operações Básicas! O litoral brasileiro tem cerca de 7.500 quilômetros de extensão. Esse número possui quantas centenas?";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [2].respostas [0].txtResp = "5";
		chefes [0].perguntas [2].respostas [0].resp = false;

		chefes [0].perguntas [2].respostas [1].txtResp = "75";
		chefes [0].perguntas [2].respostas [1].resp = true;

		chefes [0].perguntas [2].respostas [2].txtResp = "500";
		chefes [0].perguntas [2].respostas [2].resp = false;

		chefes [0].perguntas [2].respostas [3].txtResp = "7500";
		chefes [0].perguntas [2].respostas [3].resp = false;


		//pergunta 4 Spider 0
		chefes [0].perguntas [3].txtPergunta = "Números e operações! Beatriz encontrou, na loja pague pouco, a seguinte promoção: leve 4 pague 3  , ela aproveitou e pagou 12 canetas sendo assim quantas canetas Beatriz levou?";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [3].respostas [0].txtResp = "12";
		chefes [0].perguntas [3].respostas [0].resp = false;

		chefes [0].perguntas [3].respostas [1].txtResp = "14";
		chefes [0].perguntas [3].respostas [1].resp = false;

		chefes [0].perguntas [3].respostas [2].txtResp = "16";
		chefes [0].perguntas [3].respostas [2].resp = true;

		chefes [0].perguntas [3].respostas [3].txtResp = "20";
		chefes [0].perguntas [3].respostas [3].resp = false;


		//pergunta 5 Spider 0
		chefes [0].perguntas [4].txtPergunta = "Números e operações! Dentre os números abaixo, aquele que é múltiplos de 4 e 7 é o: ";

		//adiciona respostas a lista de respostas
		chefes [0].perguntas [4].respostas [0].txtResp = "14";
		chefes [0].perguntas [4].respostas [0].resp = false;
		
		chefes [0].perguntas [4].respostas [1].txtResp = "48";
		chefes [0].perguntas [4].respostas [1].resp = false;

		chefes [0].perguntas [4].respostas [2].txtResp = "56";
		chefes [0].perguntas [4].respostas [2].resp = true;

		chefes [0].perguntas [4].respostas [3].txtResp = "74";
		chefes [0].perguntas [4].respostas [3].resp = false;


		//=======================================================================================================
		//					BOSS TIGER 1 Geografia
		//=======================================================================================================

		//chefe Tiger 1
		chefes [1] = new Chefe();
		chefes [1].nome = "Tiger";
		chefes [1].casa = 20;
		chefes [1].penalidade = 17;

		//pergunta 1 Tiger 1
		chefes [1].perguntas [0].txtPergunta = "O fenômeno que envolve o desgaste, o transporte e a deposição dos solos e das partículas de rochas. é conhecido como: ";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [0].respostas [0].txtResp = "Erosão";
		chefes [1].perguntas [0].respostas [0].resp = true;

		chefes [1].perguntas [0].respostas [1].txtResp = "Corrosão";
		chefes [1].perguntas [0].respostas [1].resp = false;

		chefes [1].perguntas [0].respostas [2].txtResp = "Corrupção";
		chefes [1].perguntas [0].respostas [2].resp = false;

		chefes [1].perguntas [0].respostas [3].txtResp = "Devastação";
		chefes [1].perguntas [0].respostas [3].resp = false;


		//pergunta 2 Tiger 1
		chefes [1].perguntas [1].txtPergunta = "A maior floresta tropical do mundo e banhada por um rio cujo nome é :";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [1].respostas [0].txtResp = "Rio Nilo";
		chefes [1].perguntas [1].respostas [0].resp = false;

		chefes [1].perguntas [1].respostas [1].txtResp = "Rio Amazonas";
		chefes [1].perguntas [1].respostas [1].resp = true;

		chefes [1].perguntas [1].respostas [2].txtResp = "Rio Negro";
		chefes [1].perguntas [1].respostas [2].resp = false;

		chefes [1].perguntas [1].respostas [3].txtResp = "Rio São Francisco";
		chefes [1].perguntas [1].respostas [3].resp = false;


		//pergunta 3 Tiger 1
		chefes [1].perguntas [2].txtPergunta = "Se chegou até aqui voce já sabe um poco sobre os continentes e sabe também que o clima e diferente entre eles , sendo assim o continente mais frio do mundo é o(a): ";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [2].respostas [0].txtResp = "Antártida";
		chefes [1].perguntas [2].respostas [0].resp = true;

		chefes [1].perguntas [2].respostas [1].txtResp = "Europeu";
		chefes [1].perguntas [2].respostas [1].resp = false;

		chefes [1].perguntas [2].respostas [2].txtResp = "Africa ";
		chefes [1].perguntas [2].respostas [2].resp = false;

		chefes [1].perguntas [2].respostas [3].txtResp = "Asia";
		chefes [1].perguntas [2].respostas [3].resp = false;


		//pergunta 4 Tiger 1
		chefes [1].perguntas [3].txtPergunta = "O desaparecimento completo ou parcial das florestas e conhecido como  é conhecido?";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [3].respostas [0].txtResp = "Assoreamento";
		chefes [1].perguntas [3].respostas [0].resp = false;

		chefes [1].perguntas [3].respostas [1].txtResp = "Desmatamento";
		chefes [1].perguntas [3].respostas [1].resp = true;

		chefes [1].perguntas [3].respostas [2].txtResp = "Erosão";
		chefes [1].perguntas [3].respostas [2].resp = false;

		chefes [1].perguntas [3].respostas [3].txtResp = "Corrosão";
		chefes [1].perguntas [3].respostas [3].resp = false;


		//pergunta 5 Tiger 1
		chefes [1].perguntas [4].txtPergunta = "Estados Unidos , Canadá México e Groenlândia compõem um sub-continente chamado: ";

		//adiciona respostas a lista de respostas
		chefes [1].perguntas [4].respostas [0].txtResp = "América do Sul";
		chefes [1].perguntas [4].respostas [0].resp = false;

		chefes [1].perguntas [4].respostas [1].txtResp = "América Do Norte";
		chefes [1].perguntas [4].respostas [1].resp = true;

		chefes [1].perguntas [4].respostas [2].txtResp = "Oceania America";
		chefes [1].perguntas [4].respostas [2].resp = false;

		chefes [1].perguntas [4].respostas [3].txtResp = "Guiana Americana";
		chefes [1].perguntas [4].respostas [3].resp = false;



		//=======================================================================================================
		//					BOSS GORILLA 2 FINAL História
		//=======================================================================================================

		//chefe Tiger 1
		chefes [2] = new Chefe();
		chefes [2].nome = "Gorilla";
		chefes [2].casa = 30;
		chefes [2].penalidade = 24;

		//pergunta 1 Tiger 1
		chefes [2].perguntas [0].txtPergunta = "Tiradentes foi uma grande personalidade Brasileira que liderou um movimento chamado?";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [0].respostas [0].txtResp = "Guerra dos Bandeirantes";
		chefes [2].perguntas [0].respostas [0].resp = false;

		chefes [2].perguntas [0].respostas [1].txtResp = "Inconfidência Mineira";
		chefes [2].perguntas [0].respostas [1].resp = true;

		chefes [2].perguntas [0].respostas [2].txtResp = "Republica do cafe com leite";
		chefes [2].perguntas [0].respostas [2].resp = false;

		chefes [2].perguntas [0].respostas [3].txtResp = "Revolta das Minas Gerais";
		chefes [2].perguntas [0].respostas [3].resp = false;


		//pergunta 2 Tiger 1
		chefes [2].perguntas [1].txtPergunta = "Quem foi o primeiro Presidente do Brasil?";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [1].respostas [0].txtResp = "Marechal Deodoro da Fonseca";
		chefes [2].perguntas [1].respostas [0].resp = true;

		chefes [2].perguntas [1].respostas [1].txtResp = "Pedro Álvares Cabral";
		chefes [2].perguntas [1].respostas [1].resp = false;

		chefes [2].perguntas [1].respostas [2].txtResp = "Marechal Floriano Peixoto";
		chefes [2].perguntas [1].respostas [2].resp = false;

		chefes [2].perguntas [1].respostas [3].txtResp = "Dom pedro I";
		chefes [2].perguntas [1].respostas [3].resp = false;


		//pergunta 3 Tiger 1
		chefes [2].perguntas [2].txtPergunta = "Qual o nome da lei que Aboliu a escravidão?";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [2].respostas [0].txtResp = "Lei Eusébio de Queirós";
		chefes [2].perguntas [2].respostas [0].resp = false;
		
		chefes [2].perguntas [2].respostas [1].txtResp = "Lei dos Sexagenários";
		chefes [2].perguntas [2].respostas [1].resp = false;

		chefes [2].perguntas [2].respostas [2].txtResp = "Lei do Ventre Livre";
		chefes [2].perguntas [2].respostas [2].resp = false;

		chefes [2].perguntas [2].respostas [3].txtResp = "Lei Áurea";
		chefes [2].perguntas [2].respostas [3].resp = true;


		//pergunta 4 Tiger 1
		chefes [2].perguntas [3].txtPergunta = "Nelson mandela foi um importante presidente de qual país?";

		//adiciona respostas a lista de respostas
		chefes [2].perguntas [3].respostas [0].txtResp = "África do Sul";
		chefes [2].perguntas [3].respostas [0].resp = true;

		chefes [2].perguntas [3].respostas [1].txtResp = "Moçambique";
		chefes [2].perguntas [3].respostas [1].resp = false;

		chefes [2].perguntas [3].respostas [2].txtResp = "Portugal";
		chefes [2].perguntas [3].respostas [2].resp = false;

		chefes [2].perguntas [3].respostas [3].txtResp = "Japão";
		chefes [2].perguntas [3].respostas [3].resp = false;


		//pergunta 5 Tiger 1
		chefes [2].perguntas [4].txtPergunta = "Quem foi o compositor do Hino Nacional Brasileiro?";
		
		//adiciona respostas a lista de respostas
		chefes [2].perguntas [4].respostas [0].txtResp = "Moacyr Franco";
		chefes [2].perguntas [4].respostas [0].resp = false;

		chefes [2].perguntas [4].respostas [1].txtResp = "Gilberto Gil";
		chefes [2].perguntas [4].respostas [1].resp = false;

		chefes [2].perguntas [4].respostas [2].txtResp = "Joaquim Osório Duque Estrada";
		chefes [2].perguntas [4].respostas [2].resp = true;

		chefes [2].perguntas [4].respostas [3].txtResp = "Dom pedro II";
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
		string resp;
		PanelBtn.SetActive (false);
		if (A) {
			acertou.SetActive (true);
			resp = "Resposta A. Parabéns "+ PhotonNetwork.player.NickName+" você acertou a resposta!!!";
			TurnosGerenciador.photonViewRpc.RPC ("respostaCorreta", PhotonTargets.All, resp);
			//txtBoss.text = "Parabéns você acertou!!! Agora já pode seguir o seu caminho!";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		} else {
			errou.SetActive (true);
			resp = "Resposta A. "+ PhotonNetwork.player.NickName+" você errou, volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("respostaErrada", PhotonTargets.All, resp);
			//txtBoss.text = "Você errou!!! Volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		}
		//TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);
	}

	public void btnB(){
		string resp;
		PanelBtn.SetActive (false);
		if (B) {
			acertou.SetActive (true);
			resp = "Resposta B. Parabéns "+ PhotonNetwork.player.NickName+" você acertou a resposta!!!";
			TurnosGerenciador.photonViewRpc.RPC ("respostaCorreta", PhotonTargets.All, resp);
			//txtBoss.text = "Parabéns você acertou!!! Agora já pode seguir o seu caminho!";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		} else {
			errou.SetActive (true);
			resp = "Resposta B. "+ PhotonNetwork.player.NickName+" você errou, volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("respostaErrada", PhotonTargets.All, resp);
			//txtBoss.text = "Você errou!!! Volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		}
		//TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);
	}


	public void btnC(){
		string resp;
		PanelBtn.SetActive (false);
		if (C) {
			acertou.SetActive (true);
			resp = "Resposta C. Parabéns "+ PhotonNetwork.player.NickName+" você acertou a resposta!!!";
			TurnosGerenciador.photonViewRpc.RPC ("respostaCorreta", PhotonTargets.All, resp);
			//txtBoss.text = "Parabéns você acertou!!! Agora já pode seguir o seu caminho!";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		} else {
			errou.SetActive (true);
			resp = "Resposta C. "+ PhotonNetwork.player.NickName+" você errou, volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("respostaErrada", PhotonTargets.All, resp);
			///txtBoss.text = "Você errou!!! Volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		}
		//TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);
	}

	public void btnD(){
		string resp;
		PanelBtn.SetActive (false);
		if (D) {
			acertou.SetActive (true);
			resp = "Resposta D. Parabéns "+ PhotonNetwork.player.NickName+" você acertou a resposta!!!";
			TurnosGerenciador.photonViewRpc.RPC ("respostaCorreta", PhotonTargets.All, resp);
			//txtBoss.text = "Parabéns você acertou!!! Agora já pode seguir o seu caminho!";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,PhotonNetwork.player.sequenciaBoss,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		} else {
			errou.SetActive (true);
			resp = "Resposta D. "+ PhotonNetwork.player.NickName+" você errou, volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("respostaErrada", PhotonTargets.All, resp);
			//txtBoss.text = "Você errou!!! Volte para a casa "+voltar+".";
			TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,voltar,PhotonNetwork.player.NickName);
			StartCoroutine (waitClear (3));
		}
		//TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);

	}

	IEnumerator waitClear(float time){
		yield return new WaitForSeconds (time);
		TurnosGerenciador.photonViewRpc.RPC ("bossClearScreen", PhotonTargets.All);
		if (PhotonNetwork.player.casa > 30) {
			TurnosGerenciador.photonViewRpc.RPC ("final", PhotonTargets.All, PhotonNetwork.player.NickName);	
			StartCoroutine (videoFinal (3));
		} else {
			//TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);
			Sindico.passarVez();
		}
	}

	IEnumerator videoFinal(float time){
		yield return new WaitForSeconds (time);
		TurnosGerenciador.photonViewRpc.RPC ("videoFinal", PhotonTargets.All,PhotonNetwork.player.model);
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

