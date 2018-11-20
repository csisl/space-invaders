using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	// singleton pattern
	public static BuildManager instance;
	private GameObject turretToBuild;
	public GameObject standardTurretPrefab;
	public GameObject laserPrefab;
	public GameObject missilePrefab;

	void Awake() {
		// every time we start the game there will only be one instance of the build manager
		instance = this;
	}

	public void SetTurretToBuild(GameObject turret){
		// change what turret we want to build
		turretToBuild = turret;
	}
	

	public GameObject GetTurretToBuild() {
		return turretToBuild;
	}

}
