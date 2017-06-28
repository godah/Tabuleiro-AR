using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnosGerenciador : Photon.MonoBehaviour {
	public static PhotonView photonViewRpc;
	public GameObject btnReady;
	public GameObject btnUnready;
	public bool allReadys;
	public Text txtlado;
	public GameObject DadoStatus;
	public GameObject canvasTexto;
	public Text textoLabel;
	//boss
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
	public GameObject PanelBtn;
	public GameObject acertou;
	public GameObject errou;
	public GameObject canvasFinal;
	public Text txtFinal;
	public AudioSource audioTiger;
	public AudioSource audioSpider;
	public AudioSource audioGorila;
	public AudioSource audioAplause;



	void Start () {
		photonViewRpc = GetComponent<PhotonView> ();
		
	}
	
	void Update () {
		

	}



	//checa se todos estao prontos
	[PunRPC]
	public void checkAllReady(){
		allReadys = false;
		if (PhotonNetwork.playerList.Length > 1) {
			allReadys = true;
			for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
				if (!PhotonNetwork.playerList [i].Ready) {
					allReadys = false;
				}
			}
		}

		if (allReadys) {
			this.photonView.photonView.RPC ("allReady",PhotonTargets.All,true);
			this.photonView.photonView.RPC ("resetTurns",PhotonTargets.All);
		} else {
			this.photonView.RPC ("allReady",PhotonTargets.All,false);
		}
	}


	[PunRPC]
	public void resetTurns(){
		//passa o turno para o masterplayer
		for(int i = 0; i < PhotonNetwork.playerList.Length ; i++){
			if (PhotonNetwork.playerList [i].masterPlayer) {
				PhotonNetwork.playerList [i].isTurn = true;
			} else {
				PhotonNetwork.playerList [i].isTurn = false;
			}
		}
	}


	[PunRPC]
	public void allReady(bool pronto){
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			PhotonNetwork.playerList [i].start = pronto;
		}
	}

	[PunRPC]
	public void passarVez(string proximo){
		Debug.Log ("passarVez PunRPC");
		canvasTexto.SetActive (false);
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			if(PhotonNetwork.playerList[i].NickName == proximo){
				PhotonNetwork.playerList [i].isTurn = true;
				PhotonNetwork.playerList [i].emjogo = false;
				PhotonNetwork.playerList [i].inBossFight = false;
				i = PhotonNetwork.playerList.Length;
			}
		}

	}


//	[PunRPC]
//	public static void passarVez(string nick){
//		//Debug.Log ("passarVez");
//		canvasTexto.SetActive (false);
//		//encontra jogador atual e seta isTurn = false.
//		int id = 0;
//		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
//			if (PhotonNetwork.playerList [i].NickName == nick) {
//				//Debug.Log ("isTurn = false");
//				PhotonNetwork.playerList [i].inBossFight = false;
//				PhotonNetwork.playerList [i].emjogo = false;
//				PhotonNetwork.playerList [i].isTurn = false;
//				id = PhotonNetwork.playerList [i].ID;
//			}
//		}
//
//		//procura jogador com proximo id e passa o Turno
//		bool ultimo = true;
//		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
//			//if (id > 0 && PhotonNetwork.playerList [i].ID > id) {
//			if (PhotonNetwork.playerList [i].ID > id) {
//				//Debug.Log ("encontrou proximo");
//				PhotonNetwork.playerList [i].isTurn = true;
//				ultimo = false; //caso encontre
//				i = PhotonNetwork.playerList.Length;
//			}
//		}
//
//		//caso nao houver jogador com id maior pasas o turno para o primeiro
//		if (ultimo) {
//			int menor = 0;
//			for (int i = 1; i < PhotonNetwork.playerList.Length; i++) {
//				if (PhotonNetwork.playerList [i].ID < PhotonNetwork.playerList[menor].ID) {
//					menor = i;
//				}
//			}
//			PhotonNetwork.playerList [menor].isTurn = true;
//		}
//	}



	[PunRPC]
	public void isReady(string nick){
		for(int i = 0; i < PhotonNetwork.playerList.Length ; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].Ready = true;
			}
		}
	}



	[PunRPC]
	public void isUnready(string nick){
		allReadys = false;
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].Ready = false;
			}
		}
	}

//	[PunRPC]
//	public void mostrarValorDado(int lado,string nick){
//		DadoStatus.SetActive (true);
//		txtlado.text = lado.ToString();	
//		this.photonView.RPC ("andar",PhotonTargets.All,lado,nick);
//	}

	[PunRPC]
	public void removerDado(){
		//Debug.Log ("removerDado");
		GameObject dado = GameObject.Find ("d6(Clone)");
		Destroy (dado);
		DadoStatus.SetActive (false);
		txtlado.text = ("").ToString ();
		
	}

//	[PunRPC]
//	public void andar(int lado, string nick){
//		Debug.Log ("andar");
//		DadoStatus.SetActive (true);
//		txtlado.text = lado.ToString();	
//		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
//			if (PhotonNetwork.playerList [i].NickName == nick) {
//				if (PhotonNetwork.playerList [i].casa + lado > 30) {
//					PhotonNetwork.playerList [i].casa = 30;
//				} else {
//					PhotonNetwork.playerList [i].casa = PhotonNetwork.playerList [i].casa + lado;
//				}
//				PhotonNetwork.playerList [i].ande = true;
//			}
//		}
//	}

	[PunRPC]
	public void andar(int casa, string nick){
		Debug.Log ("andar");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].casa = casa;
				PhotonNetwork.playerList [i].ande = true;
			}
		}
	}

	[PunRPC]
	public void andarEvento(int casa, string nick){
		Debug.Log ("andarEvento");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				
				PhotonNetwork.playerList [i].casa = casa;
				PhotonNetwork.playerList [i].andeEvento = true;
			}
		}
	}

	[PunRPC]
	public void andarBoss(int casa, string nick){
		Debug.Log ("andarBoss");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].inBossFight = true;
				PhotonNetwork.playerList [i].casa = casa;
				PhotonNetwork.playerList [i].ande = true;
			}
		}
	}

	[PunRPC]
	public void adicionaEstrela(string nick){
		Debug.Log ("adicionaEstrela");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].estrelas++;
			}
		}
	}

	[PunRPC]
	public void removeEstrela(string nick){
		Debug.Log ("removeEstrela");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].estrelas--;
			}
		}
	}

	[PunRPC]
	public void removeTodasEstrelas(string nick){
		Debug.Log ("removeTodasEstrela");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].estrelas = 0;
			}
		}
	}




	[PunRPC]
	public void mostrarTexto(string texto){
		canvasTexto.SetActive (true);
		textoLabel.text = texto.ToString ();
	}

	[PunRPC]
	public void mostrarTextoBoss(string nick, int boss, string pergunta, string Resp1, string Resp2,
		string Resp3, string Resp4){
		//desativa canvasTexto dos textos comuns para nao sobrepor
		canvasTexto.SetActive (false);
		//ativa canvasBoss
		canvasBoss.SetActive (true);

		//Carrega questão e respostas
		txtBoss.text = pergunta.ToString ();
		txtResp1.text = Resp1.ToString ();
		txtResp2.text = Resp2.ToString ();
		txtResp3.text = Resp3.ToString ();
		txtResp4.text = Resp4.ToString ();


		//mostra opções para quem esta jogando.
		if (nick == PhotonNetwork.player.NickName) {
			PanelBtn.SetActive (true);
		}

		Debug.Log ("RPC boss para foto "+ boss.ToString());
		//ativa foto do boss
		switch (boss) {
		case 10:
			Spider.SetActive (true);
			audioSpider.Play ();
			break;
		case 20:
			Tiger.SetActive (true);
			audioTiger.Play ();
			break;
		case 30:
			Gorilla.SetActive (true);
			audioGorila.Play ();
			break;
		}


	}

	[PunRPC]
	public void respostaCorreta(string txt){
		acertou.SetActive (true);
		txtBoss.text = txt.ToString ();
	}

	[PunRPC]
	public void respostaErrada(string txt){
		errou.SetActive (true);
		txtBoss.text = txt.ToString ();
	}

	[PunRPC]
	public void bossClearScreen(){
		//desabilita imagem de resposta correta ou errada
		acertou.SetActive (false);
		errou.SetActive (false);
		//desabilita paineis
		PanelAjuda.SetActive (false);
		PanelBtn.SetActive (false);
		//desabilita todas as fotos por padrao
		Spider.SetActive (false);
		Tiger.SetActive (false);
		Gorilla.SetActive (false);
		//desabilita canvas boss
		canvasBoss.SetActive (false);
		//Remove Dado
		Dice.Clear ();
		this.photonView.RPC("removerDado", PhotonTargets.All);
	}

	[PunRPC]
	public void final(string nick){
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				canvasFinal.SetActive (true);
				audioAplause.Play ();
				txtFinal.text = ("Parabéns " + nick + " você venceu!!!").ToString();
			}
		}
	}

	[PunRPC]
	public void videoFinal(string model){
		//chamar video pelo nome do model
	}



}