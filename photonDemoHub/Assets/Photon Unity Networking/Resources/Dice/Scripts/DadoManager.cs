using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DadoManager : MonoBehaviour {
	public Text txtlado;
	public Transform diceSpawn;
	GameObject dado;
	public GameObject Status;
	public GameObject btnJogar;
	public GameObject btnConfirmar;
	public GameObject canvasTexto;
	public Text textoLabel;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		


	}

	/// <summary>
	/// Joga dado
	/// </summary>
	public void jogarDado(){
		Dice.Roll("d6", "d6-red-dots", diceSpawn.transform.position, Force());
		btnJogar.SetActive (false);
		StartCoroutine (waitRolling (4));

	}

	public void btnOK(){
		canvasTexto.SetActive (false);
		textoLabel.text = ("").ToString();
		//evento
		Dice.Clear ();
		TurnosGerenciador.photonViewRpc.RPC ("removerDado",PhotonTargets.All);

		TurnosGerenciador.photonViewRpc.RPC ("andarEvento",PhotonTargets.All,GerenteEventos.eventosCasas[PhotonNetwork.player.casa],PhotonNetwork.player.NickName);

		TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);
	}



	// dertermine random rolling force
	private GameObject spawnPoint = null;
	private Vector3 Force()
	{
		Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
		return Vector3.Lerp(diceSpawn.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20);
	}

	/// <summary>
	/// Aguarda o dado terminar de rolar
	/// </summary>
	IEnumerator waitRolling(float time){
		yield return new WaitForSeconds (time);

		//TurnosGerenciador.photonViewRpc.RPC ("mostrarValorDado",PhotonTargets.All,Dice.Value(""),PhotonNetwork.player.NickName);
		TurnosGerenciador.photonViewRpc.RPC ("andar",PhotonTargets.All,Dice.Value(""),PhotonNetwork.player.NickName);
	}


}
