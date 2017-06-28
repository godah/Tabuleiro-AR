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
		PhotonNetwork.player.emjogo = true;
		StartCoroutine (waitRolling (5));

	}

	/// <summary>
	/// Função do botão OK do texto após jogada
	/// </summary>
	public void btnOK(){
		canvasTexto.SetActive (false);
		textoLabel.text = ("").ToString();
		//verifica se é a vez ou se apenas deve fechar o texto.
		if (PhotonNetwork.player.isTurn && PhotonNetwork.player.emjogo) {
			//evento
			Dice.Clear ();
			TurnosGerenciador.photonViewRpc.RPC ("removerDado", PhotonTargets.All);

			//PhotonNetwork.player.casa += GerenteEventos.eventosCasas [PhotonNetwork.player.casa];

			//se for passar ou cair encima do boss 10 SPIDER 
			if ((PhotonNetwork.player.casa < 10 && PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] > 10) ||
				(PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] == 10)) {

				PhotonNetwork.player.sequenciaBoss = PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa];
				//Caso for encima do boss exato ao passar vai para proxima casa
				if (PhotonNetwork.player.sequenciaBoss == 10) {
					PhotonNetwork.player.sequenciaBoss++;
				}
				TurnosGerenciador.photonViewRpc.RPC ("andarBoss",PhotonTargets.All,10,PhotonNetwork.player.NickName);

			}


			//se for passar ou cair encima do boss 20 TIGER
			if ((PhotonNetwork.player.casa < 20 && PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] > 20) ||
				(PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] == 20)) {

				PhotonNetwork.player.sequenciaBoss = PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa];
				//Caso for encima do boss exato ao passar vai para proxima casa
				if (PhotonNetwork.player.sequenciaBoss == 20) {
					PhotonNetwork.player.sequenciaBoss++;
				}
				TurnosGerenciador.photonViewRpc.RPC ("andarBoss",PhotonTargets.All,20,PhotonNetwork.player.NickName);
			}


			//se for passar ou cair encima do boss 30 GORILLA
			if ((PhotonNetwork.player.casa < 30 && PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] > 30) ||
				(PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] == 30)) {

				//sequenciaBoss do Gorilla e sempre final 31
				PhotonNetwork.player.sequenciaBoss = 31;

				TurnosGerenciador.photonViewRpc.RPC ("andarBoss",PhotonTargets.All,30,PhotonNetwork.player.NickName);
			}


			//se nao passar pelo boss nem parar no boss ande normal
//			if (!(PhotonNetwork.player.casa < 10 && PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] > 10)&&
//				!(PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] == 10) &&
//				!(PhotonNetwork.player.casa < 20 && PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] > 20) &&
//				!(PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] == 20) &&
//				!(PhotonNetwork.player.casa < 30 && PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] > 30) &&
//				!(PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa] == 30)) {

			if(!PhotonNetwork.player.inBossFight){
				//eventos de adicionar e remover estrelas
				if (PhotonNetwork.player.casa == 15) {
					TurnosGerenciador.photonViewRpc.RPC ("adicionaEstrela", PhotonTargets.All, PhotonNetwork.player.NickName);
				}
				if (PhotonNetwork.player.casa == 28) {
					TurnosGerenciador.photonViewRpc.RPC ("removeTodasEstrelas", PhotonTargets.All, PhotonNetwork.player.NickName);
				}


				//TurnosGerenciador.photonViewRpc.RPC ("andar",PhotonTargets.All,Dice.Value("")+PhotonNetwork.player.casa,PhotonNetwork.player.NickName);
				TurnosGerenciador.photonViewRpc.RPC ("andarEvento", PhotonTargets.All, PhotonNetwork.player.casa + GerenteEventos.eventosCasas [PhotonNetwork.player.casa], PhotonNetwork.player.NickName);
				//TurnosGerenciador.photonViewRpc.RPC ("passarVez", PhotonTargets.All, PhotonNetwork.player.NickName);
				Sindico.passarVez();
			}

			//TurnosGerenciador.photonViewRpc.RPC ("andarEvento", PhotonTargets.All, PhotonNetwork.player.casa, PhotonNetwork.player.NickName);


		}
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
//		Debug.Log ("Casa atual " +PhotonNetwork.player.casa.ToString());
//		Debug.Log ("valor dado " +Dice.Value("").ToString());
//		Debug.Log ("soma " + (Dice.Value("") + PhotonNetwork.player.casa).ToString());

		//se for passar ou cair encima do boss 10 SPIDER 
		if ((PhotonNetwork.player.casa < 10 && PhotonNetwork.player.casa + Dice.Value ("") > 10) ||
			(PhotonNetwork.player.casa + Dice.Value("") == 10)) {

			PhotonNetwork.player.sequenciaBoss = PhotonNetwork.player.casa + Dice.Value ("");
			//Caso for encima do boss exato ao passar vai para proxima casa
			if (PhotonNetwork.player.sequenciaBoss == 10 || PhotonNetwork.player.sequenciaBoss == 20 || PhotonNetwork.player.sequenciaBoss == 30) {
				PhotonNetwork.player.sequenciaBoss++;
			}
			TurnosGerenciador.photonViewRpc.RPC ("andarBoss",PhotonTargets.All,10,PhotonNetwork.player.NickName);

		}


		//se for passar ou cair encima do boss 20 TIGER
		if ((PhotonNetwork.player.casa < 20 && PhotonNetwork.player.casa + Dice.Value ("") > 20) ||
			(PhotonNetwork.player.casa + Dice.Value("") == 20)) {

			PhotonNetwork.player.sequenciaBoss = PhotonNetwork.player.casa + Dice.Value ("");
			//Caso for encima do boss exato ao passar vai para proxima casa
			if (PhotonNetwork.player.sequenciaBoss == 10 || PhotonNetwork.player.sequenciaBoss == 20 || PhotonNetwork.player.sequenciaBoss == 30) {
				PhotonNetwork.player.sequenciaBoss++;
			}
			TurnosGerenciador.photonViewRpc.RPC ("andarBoss",PhotonTargets.All,20,PhotonNetwork.player.NickName);
		}


		//se for passar ou cair encima do boss 30 GORILLA
		if ((PhotonNetwork.player.casa < 30 && PhotonNetwork.player.casa + Dice.Value ("") > 30) ||
			(PhotonNetwork.player.casa + Dice.Value("") == 30)) {

			PhotonNetwork.player.sequenciaBoss = PhotonNetwork.player.casa + Dice.Value ("");
			//Caso for encima do boss exato ao passar vai para proxima casa
			if (PhotonNetwork.player.sequenciaBoss == 10 || PhotonNetwork.player.sequenciaBoss == 20 || PhotonNetwork.player.sequenciaBoss == 30) {
				PhotonNetwork.player.sequenciaBoss++;
			}
			TurnosGerenciador.photonViewRpc.RPC ("andarBoss",PhotonTargets.All,30,PhotonNetwork.player.NickName);
		}


		//se nao passar pelo boss nem parar no boss ande normal
//		if (!(PhotonNetwork.player.casa < 10 && PhotonNetwork.player.casa + Dice.Value ("") > 10) &&
//			!(PhotonNetwork.player.casa + Dice.Value("") == 10) &&
//			!(PhotonNetwork.player.casa < 20 && PhotonNetwork.player.casa + Dice.Value ("") > 20) &&
//			!(PhotonNetwork.player.casa + Dice.Value("") == 20) &&
//			!(PhotonNetwork.player.casa < 30 && PhotonNetwork.player.casa + Dice.Value ("") > 30) &&
//			!(PhotonNetwork.player.casa + Dice.Value("") == 30)) {

		if(!PhotonNetwork.player.inBossFight){
			TurnosGerenciador.photonViewRpc.RPC ("andar",PhotonTargets.All,Dice.Value("")+PhotonNetwork.player.casa,PhotonNetwork.player.NickName);
		}



	}


}
