using UnityEngine;
using System.Collections;




[RequireComponent(typeof(Rigidbody))]

public class Movi : MonoBehaviour {

	float girar;

	public float speedMove = 4f;
	public float speedRot =  3f;
	public Rigidbody rb; //
	public Animator animator; // 


	void Awake (){
		
		rb = GetComponent <Rigidbody> ();  //
		animator = GetComponent <Animator> (); //
	}

	void FixedUpdate (){
	
		Vector3 moveDir = new Vector3 ();
		// moveDir.x = Input.GetAxis ("Horizontal");
		moveDir.z = Input.GetAxis ("Vertical");
		moveDir = transform.TransformDirection (moveDir);
		moveDir *= speedMove;
		rb.velocity = moveDir;
		girar = 60.0F;

		float rotate = (Input.GetAxis ("Horizontal") * girar) * Time.deltaTime;

		transform.Rotate (0, rotate, 0);

		animator.SetBool ("IsWalking", moveDir != Vector3.zero);


	}



	void Start () {
		
	}
	// Update is called once per frame
	void Update () {

	

	}
	
}