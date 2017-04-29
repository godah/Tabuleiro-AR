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
		Debug.Log ("joinRoom");
		//Debug.Log (nomeSala.text);
		PhotonNetwork.JoinRoom ("aa"); 

	}
}
