using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManagerScript : Photon.MonoBehaviour{
	PhotonPlayer[] players;
	static PhotonView photonViewRpc;
	public GameObject canvasReady;
	public GameObject canvasJogadaDaVez;
	public GameObject btnReady;
	public GameObject btnUnready;
	bool allReady;

	void Start () {
		
		//Debug.Log ("start");
		allReady = false;
		//canvasReady.SetActive(true);
		//btnReady.SetActive (true);

		photonViewRpc = GetComponent<PhotonView> ();
//		if (!GetComponent<PhotonView> ().isMine) {
//			//this.enabled = false;
//		}


	}

	void Update ()
	{
		Debug.Log ("allready " + allReady);
		//players = PhotonNetwork.playerList;
		//checkReady ();
//		//photonViewRpc.RPC("checkReady",PhotonTargets.All);
//		for (int i = 0; i < players.Length; i++) {
//			Debug.Log (i + " ready" + players [i].Ready);


		if (allReady) {
			//Debug.Log ("allReady!!!");
			btnUnready.SetActive (false);
			canvasReady.SetActive (false);
			photonViewRpc.RPC ("ResetTurns", PhotonTargets.All);
			//ResetTurns();
		}

		//Debug.Log ("Minha vez " + PhotonNetwork.player.isTurn);
		if (PhotonNetwork.player.isTurn) {
			canvasJogadaDaVez.SetActive (true);
		} else {
			canvasJogadaDaVez.SetActive (false);
		}

	}

	[PunRPC]
	public void checkReady(){
		//percorre lista de players
		//Debug.Log("entra no checkReady");
		//players = PhotonNetwork.playerList;
		if (players.Length > 1) {
			//Debug.Log("detectou mais de um player na sala");
			for (int i = 0; i < players.Length; i++) {
				//Debug.Log("for index "+ i );
				Debug.Log (players [i].NickName + " isReady " + players [i].Ready);
				allReady = true;
				if (!players [i].Ready) {
					allReady = false;
					break; //critico
				} 
			}
		} 
		ResetTurns ();
	} 


	//reseta turnos
	[PunRPC]
	public void ResetTurns(){
		//percorre lista de players
		Debug.Log("ResetTurns()");
		//players = PhotonNetwork.playerList;

		for (int i = 0; i < players.Length; i++) {
			players [i].isTurn = false;
		}

		int menor = 0;
		for (int i = 0; i < players.Length - 1; i++) {
			if (players [i].ID > players [i + 1].ID) {
				menor = i + 1;
			}
		}
		players [menor].isTurn = true;
	} 


	void OnJoinedRoom(){

	}


	void OnCreatedRoom(){

	}

	[PunRPC]
	public void passaVez(){
		//players = PhotonNetwork.playerList;
		for (int i = 0; i < players.Length - 1; i++) {
			if (PhotonNetwork.player.ID == players [players.Length - 1].ID) {
				ResetTurns ();
				break;
			}

			if (PhotonNetwork.player.ID == players [i].ID) {
				players [i].isTurn = false;
				players [i + 1].isTurn = true;
				break;
			}

		}
	}

	public void botaoReady(){
//		PhotonNetwork.player.Ready = true;
		btnUnready.SetActive (true);
		btnReady.SetActive (false);
		PhotonNetwork.player.CustomProperties ["ready"] = 1;

	}

	public void botaoUnready(){
		//PhotonNetwork.player.Ready = false;
		btnUnready.SetActive (false);
		btnReady.SetActive (true);
		PhotonNetwork.player.CustomProperties ["ready"] = 0;

	}


}
