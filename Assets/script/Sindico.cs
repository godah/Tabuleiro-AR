using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sindico : MonoBehaviour {
	//texto dos botoes para alteração
	public Text textoStatus;
	public Text btnConnectar;
	public Text txtProcurando;
	public Text nomeSala;
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
	public GameObject ModelMask1;
	public GameObject ModelMask2;
	public GameObject ModelMask3;
	public GameObject ModelMask4;
	public Transform spawn;
	int numeroAtualDeSalas;
	int numeroAnteriorDeSalas;
	private string model ="kile";


	// Use this for initialization
	void Start () {
		
		numeroAtualDeSalas = 0;
		numeroAnteriorDeSalas = 0;
		
		//rt = ctnSalas.GetComponent<RectTransform> ();
		rt = ctnLista.GetComponent<RectTransform>();

		botaoConectar ();
	}
	
	// Update is called once per frame
	void Update () {
		//verifica se esta conectado no photon
		if (PhotonNetwork.connected) {
			textoStatus.text = "Conectado";
			btnConnectar.text = "Desconectar";
			listarSalas ();


		} else {
			textoStatus.text = "Desconectado";
			btnConnectar.text = "Conectar";
		}
			
	}



	void listarSalas(){
		
		//numeroAtualDeSalas = PhotonNetwork.GetRoomList ().Length;
		//numeroAtualDeSalas = PhotonNetwork.countOfRooms;

		numeroAtualDeSalas = PhotonNetwork.countOfRooms;

		Debug.Log ("numero atual"+numeroAtualDeSalas + " numero ant " + numeroAnteriorDeSalas);
		if (numeroAtualDeSalas != numeroAnteriorDeSalas) {
			Debug.Log ("entrou if");
			for (int i = 0; i < rt.childCount; i++) {
				//Destroy (rt.GetChild (0));			
				//Destroy(ctnLista.GetComponentInChildren<GameObject>());	
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
			//numeroAnteriorDeSalas = PhotonNetwork.countOfRooms;
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
		Debug.Log("inserirSala");
		txtProcurando.gameObject.SetActive (false);
		adaptarContainer (nSalass);
		Text t;
		//RoomInfo[] sala = PhotonNetwork.GetRoomList();
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

		//scroolDeSalas.value = 1f;
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
		
		//RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		Debug.Log (nomeSala.text.ToString().Equals(""));
		canvasLooby.SetActive (false);
		canvasModel.SetActive (true);
		//if (nomeSala.text.ToString ().Equals ("")) {
		//	PhotonNetwork.CreateRoom ("Sala"+PhotonNetwork.countOfRooms + 1,ro,TypedLobby.Default);
		//}else{
		//	
		//	PhotonNetwork.CreateRoom (nomeSala.text,ro,TypedLobby.Default);
		//	//PhotonNetwork.JoinLobby();
		//}
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
		RoomOptions ro = new RoomOptions () { IsVisible = true, MaxPlayers = 4 };
		if (nomeSala.text.ToString ().Equals ("")) {
			PhotonNetwork.CreateRoom ("Sala"+PhotonNetwork.countOfRooms + 1,ro,TypedLobby.Default);
		}else{
			PhotonNetwork.CreateRoom (nomeSala.text,ro,TypedLobby.Default);
			//PhotonNetwork.JoinLobby();
		}
	}

	public void botaoExit(){
		botaoConectar ();

	}

	void OnCreatedRoom(){
		//procura string "robo" na pasta resouces do photon junto com PhotonServerSettings
		//PhotonNetwork.Instantiate ("robo",spawn.position, Quaternion.identity,0);
		Debug.Log ("A sala foi criada com sucesso.");
	}

	void OnPhotonCreateRoomFailed(){
		Debug.Log ("Não foi possível criar a sala.");
	}
	void OnJoinedRoom(){
		//canvasLooby.SetActive (false);
		canvasModel.SetActive(false);
		canvasHUD.SetActive (true);
		//PhotonNetwork.Instantiate ("robo",spawn.position, Quaternion.identity,0);
		//PhotonNetwork.Instantiate ("kile",spawn.position, Quaternion.identity,0);
		PhotonNetwork.Instantiate (model,spawn.position, Quaternion.identity,0);
		Debug.Log ("Entrou na sala com sucesso."); 
	}

	void OnLeftRoom(){
		canvasLooby.SetActive (true);
		canvasHUD.SetActive (false);
		Debug.Log ("Saiu da sala.");
	}


}
