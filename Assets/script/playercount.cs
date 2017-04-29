//Mudar texto de componente 3dText
//anexar este script ao componente
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercount : MonoBehaviour {
	public Text txt;
	void Start () {
		
	}
	
	void Update () {
		txt = gameObject.GetComponent<Text>(); 
		txt.text=PhotonNetwork.room.PlayerCount.ToString();

	}
}
