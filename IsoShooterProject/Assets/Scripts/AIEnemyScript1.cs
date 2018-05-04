using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyScript1 : MonoBehaviour {

	public bool chasePlayer;
	public PlayerController[] Players;
	public PlayerController closestPlayer;
	public float rotationSpeed;


	void FindPlayers(){
		Players = GameObject.FindObjectsOfType<PlayerController> ();
		closestPlayer = Players [0];

	}

	// Use this for initialization
	void Start () {
		chasePlayer = false;

	}


	
	// Update is called once per frame
	void Update () {
		if (chasePlayer == true) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (closestPlayer.transform.position - transform.position), rotationSpeed * Time.deltaTime);

		}
		
	}
}
