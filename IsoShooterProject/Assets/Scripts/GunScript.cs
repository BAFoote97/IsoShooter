using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

	//public IList <GameObject> bulletEmitter = new List<GameObject> (1);
	public GameObject gunHolder;

	public bool isCurrentWeapon;

	public GameObject bulletEmitter;
//	public GameObject bulletEmitter2;
//	public GameObject bulletEmitter3;
	public bool canShoot;
	public float shootDelay = 0.1f;
	public bool autoShoot;

	public bool infiniteAmmo;
	public float ammoCount;
	public float ammoMax;
	public float ammoSpend;
	public bool noAmmo;


	public Text ammoText;
	public Text maxText;
	public Text numberText;

	public GameObject Bullet;

	public float Bullet_Forward_Force;

	public float bulletLifetime = 5.0f;

	public AudioSource shootSFX;

	void AmmoCalc () {
		if (ammoCount <= 0)
		{
			ammoCount = 0;
			noAmmo = true;
		}

		if (ammoCount >= ammoMax) {
			ammoCount = ammoMax;
		}

		if (ammoCount >= 0) {
			noAmmo = false;
		}

	}

	// Use this for initialization
	void Start () {
		isCurrentWeapon = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gunHolder.GetComponent<WeaponSwitch> ().currentGun == gameObject) {
			isCurrentWeapon = true;
		} 
		else isCurrentWeapon = false;

		if (isCurrentWeapon == false) {
			ammoText.fontStyle = FontStyle.Normal;
			maxText.fontStyle = FontStyle.Normal;
			numberText.fontStyle = FontStyle.Normal;
		}
		
		if (isCurrentWeapon == true)
		{
			ammoText.fontStyle = FontStyle.BoldAndItalic;
			maxText.fontStyle = FontStyle.BoldAndItalic;
			numberText.fontStyle = FontStyle.BoldAndItalic;
		if (noAmmo == false) {
			canShoot = true;
		}

		if (noAmmo == true) {
			canShoot = false;
		}

		if (autoShoot == true) {
			if (canShoot) {
				if (Input.GetMouseButton (0)) {
					canShoot = false;

					StartCoroutine (fireDelay ());

					{
						//Debug.Log ("Player fired");

						//The Bullet Instantiation happens here.
						GameObject Temporary_Bullet_handler;

						Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
						//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
						Temporary_Bullet_handler.transform.Rotate (Vector3.left);

						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
						Rigidbody Temporary_RigidBody;
						Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();

						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
						Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
						Destroy (Temporary_Bullet_handler, bulletLifetime);

						canShoot = false;
						StartCoroutine (fireDelay ());

					}
//					{
//						//Debug.Log ("Player fired");
//
//						//The Bullet Instantiation happens here.
//						GameObject Temporary_Bullet_handler;
//
//						Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter2.transform.position, bulletEmitter2.transform.rotation) as GameObject;
//						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
//						//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
//						Temporary_Bullet_handler.transform.Rotate (Vector3.left);
//
//						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
//						Rigidbody Temporary_RigidBody;
//						Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();
//
//						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
//						Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);
//
//						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
//						Destroy (Temporary_Bullet_handler, bulletLifetime);
//
//
//
//					}
//					{
//						//Debug.Log ("Player fired");
//
//						//The Bullet Instantiation happens here.
//						GameObject Temporary_Bullet_handler;
//
//						Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter3.transform.position, bulletEmitter3.transform.rotation) as GameObject;
//						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
//						//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
//						Temporary_Bullet_handler.transform.Rotate (Vector3.left);
//
//						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
//						Rigidbody Temporary_RigidBody;
//						Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();
//
//						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
//						Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);
//
//						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
//						Destroy (Temporary_Bullet_handler, bulletLifetime);
//
//
//
//					}
//					if (infiniteAmmo == false) {
//						ammoCount -= ammoSpend * Time.deltaTime;
//
//					}

				}
			}
		}

		if (autoShoot == false) {
			if (canShoot) {
				
				if (Input.GetMouseButtonDown (0)) {
					StartCoroutine (fireDelay ());


					{
						//Debug.Log ("Player fired");

						//The Bullet Instantiation happens here.
						GameObject Temporary_Bullet_handler;

						Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
						//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
						Temporary_Bullet_handler.transform.Rotate (Vector3.left);

						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
						Rigidbody Temporary_RigidBody;
						Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();

						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
						Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);

						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
						Destroy (Temporary_Bullet_handler, bulletLifetime);



					}
//					{
//						//Debug.Log ("Player fired");
//
//						//The Bullet Instantiation happens here.
//						GameObject Temporary_Bullet_handler;
//
//						Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter2.transform.position, bulletEmitter2.transform.rotation) as GameObject;
//						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
//						//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
//						Temporary_Bullet_handler.transform.Rotate (Vector3.left);
//
//						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
//						Rigidbody Temporary_RigidBody;
//						Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();
//
//						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
//						Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);
//
//						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
//						Destroy (Temporary_Bullet_handler, bulletLifetime);
//
//
//
//					}
//					{
//						//Debug.Log ("Player fired");
//
//						//The Bullet Instantiation happens here.
//						GameObject Temporary_Bullet_handler;
//
//						Temporary_Bullet_handler = Instantiate (Bullet, bulletEmitter3.transform.position, bulletEmitter3.transform.rotation) as GameObject;
//						//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
//						//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
//						Temporary_Bullet_handler.transform.Rotate (Vector3.left);
//
//						//Retrieve the Rigidbody component from the instantiated Bullet and control it.
//						Rigidbody Temporary_RigidBody;
//						Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();
//
//						//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
//						Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force, ForceMode.Impulse);
//
//						//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
//						Destroy (Temporary_Bullet_handler, bulletLifetime);
//
//
//
//					}
					canShoot = false;



					if (infiniteAmmo == false) {
						ammoCount -= ammoSpend;

					}

				}
			}
		}
		ammoText.text = ammoCount.ToString ("F0");
		maxText.text = ammoMax.ToString ("F0");
	}
	}
		IEnumerator fireDelay ()
		{
			yield return new WaitForSeconds(shootDelay);
			canShoot = true;

		}
		
}
