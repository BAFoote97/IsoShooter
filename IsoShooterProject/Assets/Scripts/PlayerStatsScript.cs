using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour {

	public float currentScore;
	public Text scoreText;

	public float healthCurrent;
	public float healthMax;
	float CalculateHealth(){
		return healthCurrent / healthMax;
	}
	public Text healthText;
	public Slider healthMeter;

	public GameObject gun1;
	public float ammo1;
	public float ammo1Max;
	float CalcAmmo1(){
		return ammo1 / ammo1Max;
	}

	public GameObject gun2;
	public float ammo2;
	public float ammo2Max;
	float CalcAmmo2(){
		return ammo2 / ammo2Max;
	}

	public GameObject gun3;
	public float ammo3;
	public float ammo3Max;
	float CalcAmmo3(){
		return ammo3 / ammo3Max;
	}

	public GameObject gun4;
	public float ammo4;
	public float ammo4Max;
	float CalcAmmo4(){
		return ammo4 / ammo4Max;
	}

	public GameObject gun5;
	public float ammo5;
	public float ammo5Max;
	float CalcAmmo5(){
		return ammo5 / ammo5Max;
	}

	public GameObject gun6;
	public float ammo6;
	public float ammo6Max;
	float CalcAmmo6(){
		return ammo6 / ammo6Max;
	}

	public GameObject gun7;
	public float ammo7;
	public float ammo7Max;
	float CalcAmmo7(){
		return ammo7 / ammo7Max;
	}

	public GameObject gun8;
	public float ammo8;
	public float ammo8Max;
	float CalcAmmo8(){
		return ammo8 / ammo8Max;
	}

	public GameObject gun9;
	public float ammo9;
	public float ammo9Max;
	float CalcAmmo9(){
		return ammo9 / ammo9Max;
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (healthCurrent > healthMax) {
			healthCurrent = healthMax;
		}
		healthText.text = healthCurrent.ToString ("F0");
//		healthMeter.value = healthCurrent.ToString;
//		healthMeter.maxValue = healthMax.ToString;


		scoreText.text = currentScore.ToString ("F0");

//		ammo1 = gun1.GetComponent<GunScript> ().ammoCount;
//		ammo1Max = gun1.GetComponent<GunScript> ().ammoMax;
//		if (ammo1 > ammo1Max) {
//			ammo1 = ammo1Max;
//		}
//
//		ammo2 = gun2.GetComponent<GunScript> ().ammoCount;
//		ammo2Max = gun2.GetComponent<GunScript> ().ammoMax;
//		if (ammo2 > ammo2Max) {
//			ammo2 = ammo2Max;
//		}
//
//		ammo3 = gun3.GetComponent<GunScript> ().ammoCount;
//		ammo3Max = gun3.GetComponent<GunScript> ().ammoMax;
//		if (ammo3 > ammo3Max) {
//			ammo3 = ammo3Max;
//		}
//
//		ammo4 = gun4.GetComponent<GunScript> ().ammoCount;
//		ammo4Max = gun4.GetComponent<GunScript> ().ammoMax;
//		if (ammo4 > ammo4Max) {
//			ammo4 = ammo4Max;
//		}
//
//		ammo5 = gun5.GetComponent<GunScript> ().ammoCount;
//		ammo5Max = gun5.GetComponent<GunScript> ().ammoMax;
//		if (ammo5 > ammo5Max) {
//			ammo5 = ammo5Max;
//		}
//
//		ammo6 = gun6.GetComponent<GunScript> ().ammoCount;
//		ammo6Max = gun6.GetComponent<GunScript> ().ammoMax;
//		if (ammo6 > ammo6Max) {
//			ammo6 = ammo6Max;
//		}
//
//		ammo7 = gun7.GetComponent<GunScript> ().ammoCount;
//		ammo7Max = gun7.GetComponent<GunScript> ().ammoMax;
//		if (ammo7 > ammo7Max) {
//			ammo7 = ammo7Max;
//		}
//
//		ammo8 = gun8.GetComponent<GunScript> ().ammoCount;
//		ammo8Max = gun8.GetComponent<GunScript> ().ammoMax;
//		if (ammo8 > ammo8Max) {
//			ammo8 = ammo8Max;
//		}
//
//		ammo9 = gun9.GetComponent<GunScript> ().ammoCount;
//		ammo9Max = gun9.GetComponent<GunScript> ().ammoMax;
//		if (ammo9 > ammo9Max) {
//			ammo9 = ammo9Max;
//		}
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			healthCurrent = healthCurrent - (col.gameObject.GetComponent<AIEnemyScript1>().doDamage);
		}
	}
}
