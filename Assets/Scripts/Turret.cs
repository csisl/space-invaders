using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	// aim at our target
	private Transform target;

	[Header("Attributes")]

	// range of the turret
	public float range = 15f;
	// fire 1 bullet each second
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	[Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";
	public float turnSpeed = 10f;
	public Transform partToRotate;

	/* Bullet data */
	public GameObject bulletPrefab;
	public Transform firePoint;



	// Use this for initialization
	void Start () {
		// call UpdateTarget two times a second
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
		
	}

	// find closest marked enemy in range
	void UpdateTarget(){	
		// get an array of the enemies
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		// store the shortest distance to an enemy we found so far
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies){
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance) {
				// set our shortest distance to distance to enemy
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			} else {
				target = null;
			}
		}

		if(nearestEnemy != null && shortestDistance <= range){
			// we found an enemy in our range
			target = nearestEnemy.transform;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		// do nothing if the target is null
		if(target == null){
			return;
		}

		/****************** TARGET LOCK ON *****************/
		// rotate our turret when there is an enemy
		Vector3 dir = target.position - transform.position;
		// how to turn in order to look in a certain direction
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		// convert from quaternion to euler angles (x,y,z)
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		// rotate around y axis
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (fireCountdown <= 0f){
			Shoot();
			fireCountdown = 1f/fireRate;
		}

		fireCountdown -= Time.deltaTime;

	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		// make sure the range is drawn if the turret is selcted
		Gizmos.DrawWireSphere(transform.position, range);
	}

	void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if(bullet != null){
			bullet.Seek(target);
		}
	}

}
