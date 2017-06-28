using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sindico : MonoBehaviour{ 
	//texto dos botoes para alteração
	public Text textoStatus;
	public Text btnConnectar;
	public Text txtProcurando;
	public Text nomeSala;
	public Text nomePlayer;
	public GameObject ctnLista;
	public GameObject ctnSalas;
	public Button btnConectar;
	public Button btnCriar;
	public Scrollbar scroolDeSalas;
	private RectTransform rt;
	public GameObject prefabSalas;
	public GameObject canvasLooby;
	public GameObject canvasConectando;
	public GameObject canvasModel;
	public GameObject canvasHUD;
	public GameObject canvasJogadaDaVez;
	public GameObject canvasTexto;
	public GameObject ModelMask1;
	public GameObject ModelMask2;
	public GameObject ModelMask3;
	public GameObject ModelMask4;
	public GameObject btnReady;
	public GameObject btnUnready;
	public GameObject btnJogar;
	public Transform spawn;
	public GameObject canvasReady;
	int numeroAtualDeSalas;
	int numeroAnteriorDeSalas;
	string model ="knight";
	string nick = " ";
	public Text message;


	// Use this for initialization
	void Start () {
		numeroAtualDeSalas = 0;
		numeroAnteriorDeSalas = 0;

		rt = ctnLista.GetComponent<RectTransform>();

		botaoConectar ();
	}

	// Update is called once per frame
	void Update () {
		
		//exibe na tela
		message.text = PhotonNetwork.playerList.Length.ToString ();
		//Debug.Log (PhotonNetwork.player.NickName+" isTurn:"+PhotonNetwork.player.isTurn +" ID:"+PhotonNetwork.player.ID);

		//verifica se esta conectado no photon
		if (PhotonNetwork.connected) {
			textoStatus.text = "Conectado";
			btnConnectar.text = "Desconectar";
			listarSalas ();
		} else {
			textoStatus.text = "Desconectado";
			btnConnectar.text = "Conectar";
		}

		//Debug.Log ("start "+ PhotonNetwork.player.start);

		if (PhotonNetwork.playerList.Length > 0 && PhotonNetwork.player.start ) {
			Debug.Log ("Entrou if len > 0 && start");
			canvasReady.SetActive (false);
			btnReady.SetActive (false);
			btnUnready.SetActive (false);
			Debug.Log (PhotonNetwork.player.NickName+" isturn "+PhotonNetwork.player.isTurn +" emjogo "+ !PhotonNetwork.player.emjogo);
			if (PhotonNetwork.player.isTurn && !PhotonNetwork.player.emjogo) {
				canvasJogadaDaVez.SetActive (true);
				btnJogar.SetActive (true);
				canvasTexto.SetActive (false);

			} else {
				canvasJogadaDaVez.SetActive (false);
				btnJogar.SetActive (false);
			}

//			for (int i = 0; i < PhotonNetwork.playerList.Length ; i++) {
//				Debug.Log ("Entrou for");
//				if (PhotonNetwork.playerList [i].NickName.Equals (nick)) {
//					Debug.Log ("encontrou meu proprio nick");
//					message.text = "Start "+PhotonNetwork.playerList[i].start.ToString();
//					if (PhotonNetwork.playerList [i].isTurn) {
//						canvasJogadaDaVez.SetActive (true);
//					} else {
//						canvasJogadaDaVez.SetActive (false);
//					}
//				}
//			}
		}
	}





		
	void listarSalas(){

		numeroAtualDeSalas = PhotonNetwork.countOfRooms;

		if (numeroAtualDeSalas != numeroAnteriorDeSalas) {
			for (int i = 0; i < rt.childCount; i++) {
				GameObject.Destroy(rt.GetChild(0).gameObject);
			}
			foreach (Transform child in transform) {
				GameObject.Destroy (child.gameObject);
			}
			PhotonNetwork.JoinLobby ();
			if (PhotonNetwork.insideLobby) {
				inserirSala (numeroAtualDeSalas); 
				numeroAnteriorDeSalas = PhotonNetwork.countOfRooms;
			}
		}
	}

	void OnConnectedToPhoton(){
		//Ativar Conteiner desativado
		canvasConectando.SetActive(false);
		canvasLooby.SetActive(true);
		ctnSalas.SetActive (true);
		ctnLista.SetActive (true);


		//Ativar botao Criar
		btnCriar.gameObject.SetActive (true);
		//habilita botao de criar sala
		btnCriar.interactable = true;

	}

	void OnDisconnectedFromPhoton(){
		//Ao desconectar desativa o container de salas
		ctnSalas.SetActive (false);	
		ctnLista.SetActive (false);
		canvasLooby.SetActive (false);
		canvasConectando.SetActive(true);

		//desativa botao Criar
		btnCriar.gameObject.SetActive(false);

		botaoConectar ();

	}

	public void botaoConectar(){
		//metodo linkado ao botao conectar
		//se nao estiver conectado conectar com settings 1 ( versao )
		if (!PhotonNetwork.connected) {
			PhotonNetwork.ConnectUsingSettings ("1");

			//desabilita botao de criar sala ao conectar
			btnCriar.interactable = true;
		} else {
			//se estiver conectado desconectar
			PhotonNetwork.Disconnect();
		}
	}

	void inserirSala(int nSalass){
		//chama função para ajustar container
		txtProcurando.gameObject.SetActive (false);
		adaptarContainer (nSalass);
		Text t;

		RoomInfo[] sala = PhotonNetwork.GetRoomList();
		for (int i = 0; i < nSalass ; i++) {
			//instancia prefab de sala
			RectTransform T = ((GameObject)Instantiate (prefabSalas, Vector3.zero, Quaternion.identity)).GetComponent<RectTransform> ();
			//seta prefab de sala parent da lista

			T.SetParent (rt);
			t = T.GetChild (0).GetComponentInChildren<Text> ();
			t.text = sala [i].Name;
			t = T.GetChild (1).GetComponentInChildren<Text> ();
			t.text = sala [i].PlayerCount +" / " +sala[i].MaxPlayers;

		}


	}

	//função ajusta container deacordo com numero de salas
	void adaptarContainer(int nSala){
		RectTransform T = ((GameObject)Instantiate (prefabSalas, Vector3.zero, Quaternion.identity)).GetComponent<RectTransform> ();

		T.SetParent (rt);
		T.localScale = new Vector3 (1,1,1);
		T.offsetMax = Vector2.zero;
		T.offsetMin = Vector2.zero;

		rt.sizeDelta = new Vector2 (0, nSala * 0.1f * T.rect.height);

		Destroy (T.gameObject);
	}

	public void botaoCriarSala(){

		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		if (nomeSala.text.ToString ().Equals ("")) {
			PhotonNetwork.CreateRoom ("Sala"+PhotonNetwork.countOfRooms + 1,ro,TypedLobby.Default);
		}else{
			PhotonNetwork.CreateRoom (nomeSala.text,ro,TypedLobby.Default);

		}
		PhotonNetwork.player.masterPlayer = true;
		canvasLooby.SetActive (false);
		canvasModel.SetActive (true);

	}

	public void botaoModel1(){
		ModelMask1.SetActive (true);
		ModelMask2.SetActive (false);
		ModelMask3.SetActive (false);
		ModelMask4.SetActive (false);
		model = "knight";
	}
	public void botaoModel2(){
		ModelMask1.SetActive (false);
		ModelMask2.SetActive (true);
		ModelMask3.SetActive (false);
		ModelMask4.SetActive (false);
		model = "mago";
	}
	public void botaoModel3(){
		ModelMask1.SetActive (false);
		ModelMask2.SetActive (false);
		ModelMask3.SetActive (true);
		ModelMask4.SetActive (false);
		model = "anao";
	}
	public void botaoModel4(){
		ModelMask1.SetActive (false);
		ModelMask2.SetActive (false);
		ModelMask3.SetActive (false);
		ModelMask4.SetActive (true);
		model = "amazona";
	}

	public void confirmaModel(){
		canvasHUD.SetActive(true);
		canvasModel.SetActive (false);
		PhotonNetwork.Instantiate (model,spawn.position, Quaternion.identity,0);
		canvasReady.SetActive (true);
		btnReady.SetActive (true);
		addPlayer ();

	}

	void addPlayer(){
		if (nomePlayer.text.ToString ().Equals ("")) {
			nick = "Player " + PhotonNetwork.room.PlayerCount;
		}else{
			nick = nomePlayer.text;
		}
		PhotonNetwork.player.NickName = nick;

		PhotonNetwork.player.casa = 0;
		PhotonNetwork.player.estrelas = 2;
		PhotonNetwork.player.isTurn = false;
		PhotonNetwork.player.start = false;
		PhotonNetwork.player.Ready = false;
		PhotonNetwork.player.model = model + "(Clone)";
		PhotonNetwork.player.ande = false;
		PhotonNetwork.player.andeEvento = false;
		PhotonNetwork.player.emjogo = false;

	}




	public void botaoExit(){
		canvasJogadaDaVez.SetActive (false); 
		btnJogar.SetActive (false);
		canvasReady.SetActive (false);
		btnReady.SetActive (false);
		btnUnready.SetActive (false);
		botaoConectar ();


	}




	public void botaoPassarTurno(){
		passarVez ();
		//TurnosGerenciador.photonViewRpc.RPC ("passarVez",PhotonTargets.All,nick);

	}



	public void botaoReady(){
		btnUnready.SetActive (true);
		btnReady.SetActive (false);

		TurnosGerenciador.photonViewRpc.RPC ("isReady",PhotonTargets.All,nick);
		TurnosGerenciador.photonViewRpc.RPC ("checkAllReady",PhotonTargets.All);
		TurnosGerenciador.photonViewRpc.RPC ("resetTurns",PhotonTargets.All);
	}

	public void botaoUnready(){
		
		btnUnready.SetActive (false);
		btnReady.SetActive (true);

		TurnosGerenciador.photonViewRpc.RPC ("isUnready",PhotonTargets.All,nick);

	}


	public void botaoFinishTurn(){
		canvasJogadaDaVez.SetActive (false);
	}

	void OnCreatedRoom(){

	}

	void OnPhotonCreateRoomFailed(){
		
	}

	void OnJoinedRoom(){
		canvasLooby.SetActive (false);
		canvasModel.SetActive(true);

	}

	void OnLeftRoom(){
		canvasLooby.SetActive (true);
		canvasHUD.SetActive (false);

	}

	void OnPhotonPlayerConnected(){

	}


	public static void passarVez(){
		string proximo="";
		//encontra jogador atual e seta isTurn = false.


		PhotonNetwork.player.inBossFight = false;
		PhotonNetwork.player.emjogo = false;
		PhotonNetwork.player.isTurn = false;

		//procura jogador com proximo id e passa o Turno
		bool ultimo = true;
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			//if (id > 0 && PhotonNetwork.playerList [i].ID > id) {
			if (PhotonNetwork.playerList [i].ID > PhotonNetwork.player.ID) {
				Debug.Log ("encontrou proximo");
				proximo = PhotonNetwork.playerList [i].NickName;
				ultimo = false; //caso encontre
				i = PhotonNetwork.playerList.Length;
			}
		}

		//caso nao houver jogador com id maior pasas o turno para o primeiro
		if (ultimo) {
			int menor = 0;
			for (int i = 1; i < PhotonNetwork.playerList.Length; i++) {
				if (PhotonNetwork.playerList [i].ID < PhotonNetwork.playerList[menor].ID) {
					menor = i;
				}
			}
			proximo = PhotonNetwork.playerList [menor].NickName;
		}


		TurnosGerenciador.photonViewRpc.RPC ("passarVez",PhotonTargets.All,proximo);

	}
}