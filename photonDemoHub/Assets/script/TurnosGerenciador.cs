using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnosGerenciador : Photon.MonoBehaviour {
	public static PhotonView photonViewRpc;
	public GameObject btnReady;
	public GameObject btnUnready;
	public bool allReadys;


	void Start () {
		photonViewRpc = GetComponent<PhotonView> ();
		
	}
	
	// Update is called once per frame

	void Update () {
		//Debug.Log ("allready "+allReady);

	}



	//checa se todos estao prontos
	[PunRPC]
	public void checkAllReady(){
		//Debug.Log ("checkallReady()");
		allReadys = false;
		//Debug.Log ("entrada "+ allReady);
		if (PhotonNetwork.playerList.Length > 1) {
			allReadys = true;
			//Debug.Log ("if "+ allReady);
			for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
				if (!PhotonNetwork.playerList [i].Ready) {
					allReadys = false;
					//Debug.Log ("achou false "+ allReadys); 
				}
			}
		}

		if (allReadys) {
			this.photonView.photonView.RPC ("allReady",PhotonTargets.All,true);
			this.photonView.photonView.RPC ("resetTurns",PhotonTargets.All);
		} else {
			this.photonView.RPC ("allReady",PhotonTargets.All,false);
		}
		//Debug.Log ("fim "+ allReady);
	}


	[PunRPC]
	public void resetTurns(){
		Debug.Log ("resetTurns()");
//		PhotonNetwork.playerList [0].isTurn = true;
//		for (int i = 1; i < PhotonNetwork.playerList.Length; i++) {
//			PhotonNetwork.playerList [i].isTurn = false;
//		}
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
		//Debug.Log ("passar a vez");
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
		//Debug.Log (" ID isReady " + nick);
		for(int i = 0; i < PhotonNetwork.playerList.Length ; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].Ready = true;
			}
		}
	}



	[PunRPC]
	public void isUnready(string nick){
		//Debug.Log (" ID isUnready " + nick);
		allReadys = false;
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if (PhotonNetwork.playerList [i].NickName == nick) {
				PhotonNetwork.playerList [i].Ready = false;
			}
		}
	}


}