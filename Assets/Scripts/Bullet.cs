using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// give bullet a target
	private Transform target;

	public float speed = 70f;

	
	public void Seek(Transform _target) {
		target = _target;

	}
	
	// Update is called once per frame
	void Update () {

		// make sure we have a target when firing
		if(target == null){
			Destroy(gameObject);
			return;
		}

		// find the direction the bullet needs to point in to go towards the target
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame){
			// we hit something
			HitTarget();
			return;
		}

		// we haven't hit target, so move
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

	void HitTarget(){
		Destroy(gameObject);
	}
}
