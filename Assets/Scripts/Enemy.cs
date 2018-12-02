using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	private Transform target;
	private int wavepointIndex = 0;


	void Start(){
		target = waypoints.points[0];
	}

	void Update(){
		// move closer to target for every frame that is called
		Vector3 dir = target.position - transform.position;
		// have the same fixed speed
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		// if we reached a waypoint
		if(Vector3.Distance(transform.position, target.position) <= 0.2f){
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint(){

		if(wavepointIndex >= waypoints.points.Length - 1){
			
			// destroy enemy when you reach the end
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = waypoints.points[wavepointIndex];
	}

}