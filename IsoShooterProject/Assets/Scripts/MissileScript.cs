using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

	public float bulletDmg = 1f;

	public AudioSource bulletDestroySFX;
	public GameObject Projectile;
	public Rigidbody myRigidbody;
	public GameObject explosionArea;
	public GameObject explosionFX;
	public GameObject missileBoom;
	public ParticleSystem bulletFire;
	public float explosionTime;
	public bool canPassThru;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (canPassThru == false) {

			if (other.gameObject.tag == "ColObject") {
				
				//The Bullet Instantiation happens here.
				GameObject Temporary_Bullet_handler;

				Temporary_Bullet_handler = Instantiate (missileBoom, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and/or angle based on your particular mesh.
				Temporary_Bullet_handler.transform.Rotate (Vector3.left);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_handler.GetComponent<Rigidbody> ();

				Destroy (GetComponent<MeshRenderer>());
				Destroy (GetComponent<BoxCollider> ());
				Destroy (bulletFire);

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				SphereCollider boomCollider	= missileBoom.transform.GetComponent<SphereCollider>();
				boomCollider.radius += 1 * Time.deltaTime;

				//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
				Destroy (Temporary_Bullet_handler, explosionTime);
				//Debug.Log ("Bullet hit");
				//			bulletDestroySFX.PlayOneShot (bulletDestroySFX.clip);
				//Projectile.GetComponent<MeshRenderer> ().enabled = false;
				Destroy (bulletFire);
				//this.bulletDestroySFX.GetComponent<BoxCollider> ().enabled = false;

				GameObject FX_Handler;


				FX_Handler = Instantiate (explosionFX, explosionArea.transform.position, explosionArea.transform.rotation) as GameObject;

				Destroy (this.gameObject, 1f);
				Destroy (FX_Handler, explosionTime);
			}
		}
	}
}
