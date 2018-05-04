using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

//	public int selectedWeapon = 0;


	public float moveSpeed;
	public float sprintSpeed;
	public Rigidbody myRigidbody;
	public float JumpForce;
	public GameObject camCenter;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	public Camera mainCamera;

	public float XSensitivity = 5.0f;
	public float YSensitivity = 5.0f;
	float RotX;
	float RotY;
	bool rightClicked;

	bool sprint;

	private bool m_isWalking;

	void ApplyForce(Rigidbody camCenter)
	{
		Vector3 direction = camCenter.transform.position - transform.position;
		camCenter.AddForceAtPosition(direction.normalized, transform.position);
	}

	void ApplyForce1(Rigidbody myRigidbody)
	{
		Vector3 direction = myRigidbody.transform.position - transform.position;
		myRigidbody.AddForceAtPosition(direction.normalized, transform.position);
	}

	// Use this for initialization
	void Start () {
		myRigidbody.GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();
		sprint = false;

//		SelectWeapon();

	}
	
	// Update is called once per frame
	void Update () {



		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput * moveSpeed;



		Ray cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayLength;

		if(groundPlane.Raycast(cameraRay, out rayLength))
		{
			Vector3 pointToLook = cameraRay.GetPoint(rayLength);
			Debug.DrawLine (cameraRay.origin,pointToLook,Color.blue);

			myRigidbody.transform.LookAt(new Vector3(pointToLook.x,transform.position.y, pointToLook.z));
			//mainCamera.transform.LookAt (new Vector3(pointToLook.x,transform.position.y, pointToLook.z));
		}

		this.transform.Translate (0, 0, 0);
		{
			if (Input.GetKey ("w"))
				transform.Translate (0, 0, moveSpeed);
			if (Input.GetKey ("s"))
				transform.Translate (0, 0, -moveSpeed);
			if (Input.GetKey ("a"))
				transform.Translate (-moveSpeed, 0, 0);
			if (Input.GetKey ("d"))
				transform.Translate (moveSpeed, 0, 0);
		}

		if (sprint) 
		{
			this.transform.Translate (0, 0, 0);
			{
				if (Input.GetKey ("w"))
					transform.Translate (0, 0, sprintSpeed);
				if (Input.GetKey ("s"))
					transform.Translate (0, 0, -sprintSpeed);
				if (Input.GetKey ("a"))
					transform.Translate (-sprintSpeed, 0, 0);
				if (Input.GetKey ("d"))
					transform.Translate (sprintSpeed, 0, 0);
			}
			
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			sprint = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			sprint = false;
		}

		//myRigidbody.transform.Translate (0, 0, 0);
		//{
		//	if (Input.GetKey ("w"))
		//		transform.Translate (0, 0, moveSpeed);
		//	if (Input.GetKey ("s"))
		//		transform.Translate (0, 0, -moveSpeed);
		//	if (Input.GetKey ("a"))
		//		transform.Translate (-moveSpeed, 0, 0);
		//	if (Input.GetKey ("d"))
		//		transform.Translate (moveSpeed, 0, 0);
		//}

//		if (Input.GetKeyDown (KeyCode.Space)) 
//		{
//			Debug.Log ("Jump");
//			myRigidbody.AddForce (Vector2.up * JumpForce, ForceMode.Impulse);
//		
//		}

		if (Input.GetMouseButtonDown (1)) 
		{
			rightClicked = true;

		}
		if (Input.GetMouseButtonUp(1))
		{
			rightClicked = false;
		}
		if (rightClicked == true)
		{
		RotX = Input.GetAxis ("Mouse X") * XSensitivity;
		this.gameObject.transform.Rotate (0, RotX, 0);
		
			RotY = Input.GetAxis ("Mouse Y") * YSensitivity;

		}


	}


	void FixedUpdate() {

		myRigidbody.velocity = moveVelocity;
	}
}
