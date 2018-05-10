using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyScript1 : MonoBehaviour {

	public float healthValue = 1.0f;
	public float doDamage = 1.0f;

	public bool canDropSlime;
	public GameObject dropSlime;
	public GameObject slimeTrail;
	public float slimeTime;

	public bool chasePlayer;
	public PlayerController[] Players;
	public PlayerController closestPlayer;
	public float rotationSpeed = 1.0f;
	public float moveSpeed = 1.0f;

	public bool onFire = false;
	public GameObject fireEffect;
	public float onFireDmg;
	public float coolTime;

	public GameObject nosePoint;

	void FindPlayers(){
		Players = GameObject.FindObjectsOfType<PlayerController> ();
		closestPlayer = Players [0];

	}



	// Use this for initialization
	void Start () {
//		chasePlayer = false;

	}
	void OnTriggerEnter (Collider rangeTrigger){
		rangeTrigger = nosePoint.GetComponent<SphereCollider> ();
		if (rangeTrigger.gameObject.tag == "Player") {
			chasePlayer = true;
		}
//		if (rangeTrigger.gameObject.tag == "FlamethrowerFlame") {
//			onFire = true;
//			Debug.Log ("Fire hit");
//			}
	}



//	void OnTriggerEnter (Collider col)
//	{
//		if(col.gameObject.tag == "Bullet")
//		{
////			col.gameObject.GetComponent<BulletScript> ().bulletDmg;
//			Debug.Log ("Got a hit");
//			healthValue -= (col.gameObject.GetComponent<BulletScript>().bulletDmg);
//		}
//	}
	
	// Update is called once per frame
	void Update () {
		if (onFire == true) {
			fireEffect.SetActive (true);
			healthValue -= onFireDmg * Time.deltaTime;
//			StartCoroutine (FireCool());
		}

		if (canDropSlime == true)
		{
			GameObject Temporary_Bullet_handler;

			Temporary_Bullet_handler = Instantiate (slimeTrail, dropSlime.transform.position, dropSlime.transform.rotation) as GameObject;
			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
			Temporary_Bullet_handler.transform.Rotate (Vector3.left);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();


			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy (Temporary_Bullet_handler, slimeTime);

		}
		
		if (chasePlayer == true) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (closestPlayer.transform.position - transform.position), rotationSpeed * Time.deltaTime);
			transform.Translate (0, 0, moveSpeed);
		}
		if (healthValue <= 0)
			Destroy (gameObject);
		
	}
//	IEnumerator FireCool(){
//		fireEffect.SetActive (true);
//		healthValue -= onFireDmg * Time.deltaTime;
//		yield return new WaitForSeconds(coolTime);
//		onFire = false;
//		fireEffect.SetActive (false);
//
//	}

}
