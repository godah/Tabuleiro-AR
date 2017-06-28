using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundClick : MonoBehaviour {


	public AudioSource audioAranha;
	public AudioSource audioTiger;
	public AudioSource audioGorila;

	void Start () {
		
	}

	void Update () {
		
	}

	public void playAranha(){
		audioAranha.Play ();
	}

	public void playTiger(){
		audioTiger.Play ();
	}

	public void playGorila(){
		audioGorila.Play ();
	}


}
