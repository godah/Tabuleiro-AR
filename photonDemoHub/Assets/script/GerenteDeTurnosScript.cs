using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteDeTurnosScript : NetworkBehaviour{
	static PhotonView photonNetworkRpc;
	public GameObject btnReady;
	public GameObject btnUnready;
	PhotonPlayer[] players;

	// Use this for initialization
	void Start () {

		photonNetworkRpc = GetComponent<PhotonView> ();
		if (!GetComponent<PhotonView> ().isMine) {
			this.enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		players = PhotonNetwork.playerList;

		for (int i = 0; i < players.Length; i++) {
			Debug.Log (i + " ready" + players [i].Ready);
		}

		
	}

	public void botaoReady(){
		btnUnready.SetActive (true);
		btnReady.SetActive (false);
		PhotonNetwork.player.Ready = true;
		players = PhotonNetwork.playerList;
	}

	public void botaoUnready(){
		btnUnready.SetActive (false);
		btnReady.SetActive (true);
		PhotonNetwork.player.Ready = false;
		players = PhotonNetwork.playerList;
	}
}
