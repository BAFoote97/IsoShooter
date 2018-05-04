using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

	public float healthPickupTotal;

	public float ammo1PickupTotal;
	public float ammo2PickupTotal;
	public float ammo3PickupTotal;
	public float ammo4PickupTotal;
	public float ammo5PickupTotal;
	public float ammo6PickupTotal;
	public float ammo7PickupTotal;
	public float ammo8PickupTotal;
	public float ammo9PickupTotal;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (0, 2.5f, 0);
		
	}
	void OnTriggerEnter (Collider player)
	{
		if (player.gameObject.tag == "Player")
			Destroy (gameObject);
	}

}
