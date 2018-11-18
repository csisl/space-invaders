using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	// aim at our target
	public Transform target;

	// range of the turret
	public float range = 15f;



	// Use this for initialization
	void Start () {
		// call UpdateTarget two times a second
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
		
	}

	void UpdateTarget(){
		// find closest marked enemy in range
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		// make sure the range is drawn if the turret is selcted
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
