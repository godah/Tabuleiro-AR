using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScriptJoinRoom : MonoBehaviour {
	public GameObject btnNomeSala;
	public GameObject SalaPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void entrarNaSala(){
		Debug.Log ("joinRoomOrCreate");
		//Debug.Log (btnNomeSala.text);
		//PhotonNetwork.JoinRoom ("aa"); 

		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		string sala = btnNomeSala.gameObject.GetComponentInChildren<Text> ().text;
		if (sala == null) {
			sala = "Sala " + PhotonNetwork.countOfRooms + 1;
		}
		PhotonNetwork.JoinOrCreateRoom (sala, ro, TypedLobby.Default);

	}
	public void joinSala1(){
		Debug.Log ("join Sala01");
		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom ("sala1", ro, TypedLobby.Default);
	}
	public void joinSala2(){
		Debug.Log ("join Sala02");
		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom ("sala2", ro, TypedLobby.Default);
	}
	public void joinSala3(){
		Debug.Log ("join Sala03");
		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom ("sala3", ro, TypedLobby.Default);
	}
	public void joinSala4(){
		Debug.Log ("join Sala04");
		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom ("sala4", ro, TypedLobby.Default);
	}
	public void joinSala5(){
		Debug.Log ("join Sala05");
		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom ("sala5", ro, TypedLobby.Default);
	}
}
