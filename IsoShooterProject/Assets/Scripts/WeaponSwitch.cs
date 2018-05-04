using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

//	public int selectedWeapon = 0;

	public List <GameObject> guns = new List<GameObject> ();

	public GameObject currentGun;

	// Use this for initialization
	void Start () {
		currentGun = guns [0];
		currentGun = guns [1];
		currentGun = guns [2];
		currentGun = guns [3];
		currentGun = guns [4];
		currentGun = guns [5];
		currentGun = guns [6];
		currentGun = guns [7];
		currentGun = guns [8];
		currentGun = guns [0];


	}

	void Check()
	{
		


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("1")) 
			currentGun = guns [0];

		if (Input.GetKeyDown ("2")) 
			currentGun = guns [1];

		if (Input.GetKeyDown ("3"))
			currentGun = guns [2];

		if (Input.GetKeyDown ("4"))
			currentGun = guns [3];

		if (Input.GetKeyDown ("5"))
			currentGun = guns [4];

		if (Input.GetKeyDown ("6"))
			currentGun = guns [5];

		if (Input.GetKeyDown ("7"))
			currentGun = guns [6];

		if (Input.GetKeyDown ("8"))
			currentGun = guns [7];

		if (Input.GetKeyDown ("9"))
			currentGun = guns [8];
//
//		int previousSelectedWeapon = selectedWeapon;
//
//		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
//		{
//			if (selectedWeapon >= transform.childCount - 1)
//				selectedWeapon = 0;
//			else
//				selectedWeapon++;
//		}
//
//		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
//		{
//			if (selectedWeapon <= transform.childCount - 1)
//				selectedWeapon = 0;
//			else
//				selectedWeapon--;
//		}
//
//		if (previousSelectedWeapon != selectedWeapon)
//		{
//			SelectWeapon ();
//		}
//
//		if (Input.GetKeyDown (KeyCode.Alpha1)) 
//		{
//			selectedWeapon = 0;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha2) && transform.childCount >= 2) 
//		{
//			selectedWeapon = 1;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha3) && transform.childCount >= 3) 
//		{
//			selectedWeapon = 2;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha4) && transform.childCount >= 4) 
//		{
//			selectedWeapon = 3;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha5) && transform.childCount >= 5) 
//		{
//			selectedWeapon = 4;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha6) && transform.childCount >= 6) 
//		{
//			selectedWeapon = 5;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha7) && transform.childCount >= 7) 
//		{
//			selectedWeapon = 6;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha8) && transform.childCount >= 8) 
//		{
//			selectedWeapon = 7;
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha9) && transform.childCount >= 9) 
//		{
//			selectedWeapon = 8;
//		}
//		SelectWeapon();

	}

//	void SelectWeapon()
//	{
//		int i = 0;
//		foreach (Transform weapon in transform) 
//		{
//			if (i == selectedWeapon)
//				weapon.gameObject.SetActive (true);
//			else
//				weapon.gameObject.SetActive (false);
//			i++;
//
//		}
//
//	}
}
