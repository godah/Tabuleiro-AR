using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sindico : MonoBehaviour{ 
	//public static PhotonView photonViewRpc;
	//cria lista playerGroup
	//public List<TurnClass> playersGroup;
	//TurnClass player;
	//texto dos botoes para alteração
	public Text textoStatus;
	public Text btnConnectar;
	public Text txtProcurando;
	public Text nomeSala;
	public Text nomePlayer;
	//objeto ctnsalas para ativar e desativar
	public GameObject ctnLista;
	public GameObject ctnSalas;
	//objeto botoes para ativar e desativar
	public Button btnConectar;
	public Button btnCriar;
	public Scrollbar scroolDeSalas;
	private RectTransform rt;
	public GameObject prefabSalas;
	public GameObject prefabPlayer;
	public GameObject canvasLooby;
	public GameObject canvasModel;
	public GameObject canvasHUD;
	public GameObject canvasJogadaDaVez;
	public GameObject ModelMask1;
	public GameObject ModelMask2;
	public GameObject ModelMask3;
	public GameObject ModelMask4;
	public GameObject btnReady;
	public GameObject btnUnready;
	public GameObject btnPassarTurno;
	public Transform spawn;
	public GameObject canvasReady;
	int numeroAtualDeSalas;
	int numeroAnteriorDeSalas;
	string model ="kile";
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

		//verifica se esta conectado no photon
		if (PhotonNetwork.connected) {
			textoStatus.text = "Conectado";
			btnConnectar.text = "Desconectar";
			listarSalas ();
		} else {
			textoStatus.text = "Desconectado";
			btnConnectar.text = "Conectar";
		}


		//informações
		for (int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			//Debug.Log ("allready "+PhotonNetwork.playerList [i].start);
			//Debug.Log ("nick "+PhotonNetwork.playerList [i].NickName);
			//Debug.Log ("id "+PhotonNetwork.playerList [i].ID);
			//Debug.Log ("Ready"+PhotonNetwork.playerList [i].Ready);
			if (PhotonNetwork.playerList [i].isTurn) {
				Debug.Log ("isTurn " + PhotonNetwork.playerList [i].NickName);
			}
		}

		//checa se todos estao prontos




		if (PhotonNetwork.playerList.Length > 0 && PhotonNetwork.player.start ) {
			canvasReady.SetActive (false);
			btnReady.SetActive (false);
			btnUnready.SetActive (false);


			//Debug.Log ("ListaExiste and AllReady");
			//Debug.Log ("Meu nick "+nick);
			for (int i = 0; i < PhotonNetwork.playerList.Length ; i++) {
				Debug.Log(PhotonNetwork.playerList [i].NickName.Equals (nick) +" "+ PhotonNetwork.playerList[i].isTurn);
				if (PhotonNetwork.playerList [i].NickName.Equals (nick)) {
					message.text = "Start "+PhotonNetwork.playerList[i].start.ToString();
					if (PhotonNetwork.playerList [i].isTurn) {
						Debug.Log ("Minha Vez - "+nick);
						canvasJogadaDaVez.SetActive (true);
					} else {
						canvasJogadaDaVez.SetActive (false);
					}
				}
			}
		}
	}





		
	void listarSalas(){

		numeroAtualDeSalas = PhotonNetwork.countOfRooms;

		//Debug.Log ("numero atual"+numeroAtualDeSalas + " numero ant " + numeroAnteriorDeSalas);
		if (numeroAtualDeSalas != numeroAnteriorDeSalas) {
			//Debug.Log ("entrou if");
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
		canvasLooby.SetActive (true);

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
		//Debug.Log("inserirSala");
		txtProcurando.gameObject.SetActive (false);
		adaptarContainer (nSalass);
		Text t;

		RoomInfo[] sala = PhotonNetwork.GetRoomList();
		for (int i = 0; i < nSalass ; i++) {
			//isntancia prefab de sala
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
		model = "kile";
	}
	public void botaoModel2(){
		ModelMask1.SetActive (false);
		ModelMask2.SetActive (true);
		ModelMask3.SetActive (false);
		ModelMask4.SetActive (false);
		model = "robo";
	}
	public void botaoModel3(){
		ModelMask1.SetActive (false);
		ModelMask2.SetActive (false);
		ModelMask3.SetActive (true);
		ModelMask4.SetActive (false);
		model = "kile";
	}
	public void botaoModel4(){
		ModelMask1.SetActive (false);
		ModelMask2.SetActive (false);
		ModelMask3.SetActive (false);
		ModelMask4.SetActive (true);
		model = "robo";
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

	}




	public void botaoExit(){
		canvasJogadaDaVez.SetActive (false); 
		btnPassarTurno.SetActive (false);
		canvasReady.SetActive (false);
		btnReady.SetActive (false);
		btnUnready.SetActive (false);
		botaoConectar ();


	}




	public void botaoPassarTurno(){
		TurnosGerenciador.photonViewRpc.RPC ("passarVez",PhotonTargets.All,nick);
	}



	public void botaoReady(){
		//Debug.Log ("Botao ready");
		btnUnready.SetActive (true);
		btnReady.SetActive (false);

		TurnosGerenciador.photonViewRpc.RPC ("isReady",PhotonTargets.All,nick);
		TurnosGerenciador.photonViewRpc.RPC ("checkAllReady",PhotonTargets.All);
		TurnosGerenciador.photonViewRpc.RPC ("resetTurns",PhotonTargets.All);
	}

	public void botaoUnready(){
		
		//Debug.Log ("Botao unready");
		btnUnready.SetActive (false);
		btnReady.SetActive (true);

		TurnosGerenciador.photonViewRpc.RPC ("isUnready",PhotonTargets.All,nick);

	}


	public void botaoFinishTurn(){
		//Debug.Log ("botaoFinishTurn()");
		canvasJogadaDaVez.SetActive (false);
	}

	void OnCreatedRoom(){
		//Debug.Log ("A sala foi criada com sucesso.");

	}

	void OnPhotonCreateRoomFailed(){
		//Debug.Log ("Não foi possível criar a sala.");
	}
	void OnJoinedRoom(){
		canvasLooby.SetActive (false);
		canvasModel.SetActive(true);

		//Debug.Log ("Entrou na sala com sucesso."); 
	}

	void OnLeftRoom(){
		canvasLooby.SetActive (true);
		canvasHUD.SetActive (false);

		//Debug.Log ("Saiu da sala.");
	}

	void OnPhotonPlayerConnected(){
		//Debug.Log ("OnPhotonPlayerConnected");



	}


}