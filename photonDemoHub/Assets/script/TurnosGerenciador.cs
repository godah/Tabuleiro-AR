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
	public void passarVez(string nick){
		Debug.Log ("passarVez");
		canvasTexto.SetActive (false);
		//encontra jogador atual e seta isTurn = false.
		int id = 0;
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			if (PhotonNetwork.playerList [i].NickName == nick) {
				Debug.Log ("isTurn = false");
				PhotonNetwork.playerList [i].emjogo = false;
				PhotonNetwork.playerList [i].isTurn = false;
				id = PhotonNetwork.playerList [i].ID;
			}
		}

		//procura jogador com proximo id e passa o Turno
		bool ultimo = true;
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			if (id > 0 && PhotonNetwork.playerList [i].ID > id) {
				Debug.Log ("encontrou proximo");
				PhotonNetwork.playerList [i].isTurn = true;
				ultimo = false; //caso encontre
			}
		}

		//caso nao houver jogador com id maior pasas o turno para o primeiro
		if (ultimo) {
			int menor = 0;
			for (int i = 1; i < PhotonNetwork.playerList.Length; i++) {
				if (PhotonNetwork.playerList [i].ID < PhotonNetwork.playerList[menor].ID) {
					menor = i;
				}
			}
			PhotonNetwork.playerList [menor].isTurn = true;
		}
	}



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

	[PunRPC]
	public void andar(int lado, string nick){
		Debug.Log ("andar");
		DadoStatus.SetActive (true);
		txtlado.text = lado.ToString();	
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				if (PhotonNetwork.playerList [i].casa + lado > 30) {
					PhotonNetwork.playerList [i].casa = 30;
				} else {
					PhotonNetwork.playerList [i].casa = PhotonNetwork.playerList [i].casa + lado;
				}
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
				
				PhotonNetwork.playerList [i].casa = casa;
				PhotonNetwork.playerList [i].ande = true;
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

		//ativa canvasBoss
		canvasBoss.SetActive (true);
		//mostra opções para quem esta jogando.
		if (nick == PhotonNetwork.player.NickName) {
			//Carrega questão e respostas
			txtBoss.text = pergunta.ToString ();
			txtResp1.text = Resp1.ToString ();
			txtResp2.text = Resp2.ToString ();
			txtResp3.text = Resp3.ToString ();
			txtResp4.text = Resp4.ToString ();
		}

		//ativa foto do boss
		switch (boss) {
		case 10:
			Spider.SetActive (true);
			break;
		case 20:
			Tiger.SetActive (true);
			break;
		case 30:
			Gorilla.SetActive (true);
			break;
		}


	}



}