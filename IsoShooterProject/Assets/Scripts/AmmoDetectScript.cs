using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDetectScript : MonoBehaviour {

	public Text ammoDisplay;

	public float currentAmmo;

	// Use this for initialization
	void Start () {

		this.gameObject.GetComponent<GunScript>().ammoCount = currentAmmo;

		ammoDisplay.text = currentAmmo.ToString ("F0");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
