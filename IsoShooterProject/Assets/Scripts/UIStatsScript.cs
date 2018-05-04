using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatsScript : MonoBehaviour {

	public Transform meeple;
	public GameObject guns;
	public GameObject childWeapon;

	public Text healthNumber;
	public Slider grandchild;

	public Text ammoText;

	public Text scoreText;

	public float knownAmmo;

	public int selectedWeapon = 0;



	// Use this for initialization
	void Start () {
		StartCoroutine (DetectGun());
	}

	IEnumerator DetectGun()
	{
		while (true) {
			childWeapon = guns.gameObject.transform.GetChild (0).gameObject;


			yield return new WaitForSeconds (0.1f);
		}	
	}
	
	// Update is called once per frame
	void Update () {

//		GameObject access = GameObject.Find (childWeapon);
		childWeapon.GetComponent<GunScript> ();
//		GunScript.ammoCount	= knownAmmo;



		
	}
}
