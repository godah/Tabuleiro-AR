﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class mobamov : MonoBehaviour {
	public List<Vector3> enderecoCasas;
	private Vector3 destino;
	private NavMeshAgent ag;
	private Animator anim;
	private PhotonView pview;
	private Vector3 vectorCasa;
	GameObject trans;
	Vector3 tmp;


	// Use this for initialization
	void Start () {
		ag = this.GetComponent<NavMeshAgent> ();
		anim = this.GetComponent<Animator> ();
		pview = this.GetComponent<PhotonView> ();
		destino = transform.position;
		CarregaEnderecos ();
	}

	// Update is called once per frame
	void Update () {
		
		if (pview.isMine) {
			//jogada
			if (PhotonNetwork.player.ande) {
				destino = enderecoCasas[PhotonNetwork.player.casa];
				ag.SetDestination (destino);

			}

			if (Vector3.Distance (transform.position, destino) > 3f) {
				anim.SetBool ("Walk", true);
			} else {
				anim.SetBool ("Walk", false);
				if (PhotonNetwork.player.ande) {
					TurnosGerenciador.photonViewRpc.RPC ("mostrarTexto", PhotonTargets.All, GerenteTextos.textosCasas [PhotonNetwork.player.casa]);
					PhotonNetwork.player.ande = false;
				}
			}	

			//evento automatico
			if (PhotonNetwork.player.andeEvento) {
				destino = enderecoCasas[PhotonNetwork.player.casa];
				ag.SetDestination (destino);

			}

			if (Vector3.Distance (transform.position, destino) > 3f) {
				anim.SetBool ("Walk", true);
			} else {
				anim.SetBool ("Walk", false);
				if (PhotonNetwork.player.andeEvento) {
					//TurnosGerenciador.photonViewRpc.RPC ("mostrarTexto", PhotonTargets.All, GerenteTextos.textosCasas [PhotonNetwork.player.casa]);
					PhotonNetwork.player.andeEvento = false;
				}
			}	
		}

	}

	void CarregaEnderecos(){
		tmp.Set (96.643f,0f,51.754f);//0
		enderecoCasas.Add (tmp);
		tmp.Set (91.6f,0f,47.5f);//1
		enderecoCasas.Add (tmp);
		tmp.Set (89.29f,0f,42.66f);//2
		enderecoCasas.Add (tmp);
		tmp.Set (89.29f,0f,37f);//3
		enderecoCasas.Add (tmp);
		tmp.Set (88.4f,0f,31.9f);//4
		enderecoCasas.Add (tmp);
		tmp.Set (87.8f,0f,26.5f);//5
		enderecoCasas.Add (tmp);
		tmp.Set (85.16f,0f,20.42f);//6
		enderecoCasas.Add (tmp);
		tmp.Set (76.29f,0f,19.11f);//7
		enderecoCasas.Add (tmp);
		tmp.Set (70.4f,0f,22.22f);//8
		enderecoCasas.Add (tmp);
		tmp.Set (67.27f,0f,27.3f);//9
		enderecoCasas.Add (tmp);
		tmp.Set (65.6f,0f,32.5f);//10 boos SPIDER
		enderecoCasas.Add (tmp);
		tmp.Set (64.94f,0f,38.75f);//11
		enderecoCasas.Add (tmp);
		tmp.Set (64.94f,0f,43.9f);//12
		enderecoCasas.Add (tmp);
		tmp.Set (63.6f,0f,48.9f);//13
		enderecoCasas.Add (tmp);
		tmp.Set (60.1f,0f,55f);//14
		enderecoCasas.Add (tmp);
		tmp.Set (50.9f,0f,57.2f);//15
		enderecoCasas.Add (tmp);
		tmp.Set (45.9f,0f,51.8f);//16
		enderecoCasas.Add (tmp);
		tmp.Set (42.3f,0f,47.5f);//17
		enderecoCasas.Add (tmp);
		tmp.Set (41.1f,0f,43.2f);//18
		enderecoCasas.Add (tmp);
		tmp.Set (39.8f,0f,38.6f);//19
		enderecoCasas.Add (tmp);
		tmp.Set (39.5f,0f,34.7f);//20 boss TIGER
		enderecoCasas.Add (tmp);
		tmp.Set (37.8f,0f,28.9f);//21
		enderecoCasas.Add (tmp);
		tmp.Set (35.9f,0f,24.5f);//22
		enderecoCasas.Add (tmp);
		tmp.Set (33.4f,0f,20.8f);//23
		enderecoCasas.Add (tmp);
		tmp.Set (28.6f,0f,20.4f);//24
		enderecoCasas.Add (tmp);
		tmp.Set (21.8f,0f,20.9f);//25
		enderecoCasas.Add (tmp);
		tmp.Set (19f,0f,26.2f);//26
		enderecoCasas.Add (tmp);
		tmp.Set (16.6f,0f,31.5f);//27
		enderecoCasas.Add (tmp);
		tmp.Set (16.6f,0f,37.6f);//28
		enderecoCasas.Add (tmp);
		tmp.Set (16.6f,0f,43f);//29
		enderecoCasas.Add (tmp);
		tmp.Set (16.6f,0f,45.9f);//30 boss Gorilla Final
		enderecoCasas.Add (tmp);
	}

}