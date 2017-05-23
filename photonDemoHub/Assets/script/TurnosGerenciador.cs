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
		for (int i = 0; i < PhotonNetwork.playerList.Length ; i++) {
			if (PhotonNetwork.playerList [i].NickName == nick) {
				//se for o ultimo da lista
				if (i == PhotonNetwork.playerList.Length - 1) {
					PhotonNetwork.playerList [i].isTurn = false;
					PhotonNetwork.playerList [0].isTurn = true;
				} else {
					PhotonNetwork.playerList [i].isTurn = false;
					PhotonNetwork.playerList [i + 1].isTurn = true;
				}
			}
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
		Debug.Log ("removerDado");
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
	public void andarEvento(int lado, string nick){
		Debug.Log ("andarEvento");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				if (PhotonNetwork.playerList [i].casa + lado > 30) {
					PhotonNetwork.playerList [i].casa = 30;
				} else {
					PhotonNetwork.playerList [i].casa = PhotonNetwork.playerList [i].casa + lado;
				}
				PhotonNetwork.playerList [i].andeEvento = true;
			}
		}
	}



	[PunRPC]
	public void mostrarTexto(string texto){
		canvasTexto.SetActive (true);
		textoLabel.text = texto.ToString ();
	}


}