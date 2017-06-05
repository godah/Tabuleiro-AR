using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteHUD : MonoBehaviour {
	public Text player1;
	public Text casa1;
	public GameObject label1;

	public Text player2;
	public Text casa2;
	public GameObject label2;

	public Text player3;
	public Text casa3;
	public GameObject label3;

	public Text player4;
	public Text casa4;
	public GameObject label4;

	public Text txtEstrela;

	public GameObject allready;

	public Text message;

	int nPlayers;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.inRoom) {
			txtEstrela.text = PhotonNetwork.player.estrelas.ToString ();

			nPlayers = PhotonNetwork.room.PlayerCount;
			Debug.Log ("Quantidade de pessoas na Room "+ PhotonNetwork.room.PlayerCount);
			switch (nPlayers) {

			case 1:
				label1.SetActive (true);	
				label2.SetActive (false);
				label3.SetActive (false);
				label4.SetActive (false);
				player1.text = PhotonNetwork.playerList [0].NickName;
				casa1.text = PhotonNetwork.playerList [0].casa.ToString ();
				break;

			case 2:
				label1.SetActive (true);	
				label2.SetActive (true);
				label3.SetActive (false);
				label4.SetActive (false);
				player1.text = PhotonNetwork.playerList [0].NickName;
				casa1.text = PhotonNetwork.playerList [0].casa.ToString ();

				player2.text = PhotonNetwork.playerList [1].NickName;
				casa2.text = PhotonNetwork.playerList [1].casa.ToString ();
				break;

			case 3:
				label1.SetActive (true);	
				label2.SetActive (true);
				label3.SetActive (true);
				label4.SetActive (false);
				player1.text = PhotonNetwork.playerList [0].NickName;
				casa1.text = PhotonNetwork.playerList [0].casa.ToString ();

				player2.text = PhotonNetwork.playerList [1].NickName;
				casa2.text = PhotonNetwork.playerList [1].casa.ToString ();

				player3.text = PhotonNetwork.playerList [2].NickName;
				casa3.text = PhotonNetwork.playerList [2].casa.ToString ();
				break;

			case 4:
				label1.SetActive (true);	
				label2.SetActive (true);
				label3.SetActive (true);
				label4.SetActive (true);

				player1.text = PhotonNetwork.playerList [0].NickName;
				casa1.text = PhotonNetwork.playerList [0].casa.ToString ();

				player2.text = PhotonNetwork.playerList [1].NickName;
				casa2.text = PhotonNetwork.playerList [1].casa.ToString ();

				player3.text = PhotonNetwork.playerList [2].NickName;
				casa3.text = PhotonNetwork.playerList [2].casa.ToString ();

				player4.text = PhotonNetwork.playerList [3].NickName;
				casa4.text = PhotonNetwork.playerList [3].casa.ToString ();
				break;
			}

		}
	}
}

