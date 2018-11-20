using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	// singleton pattern
	

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild() {
		return turretToBuild;
	}

}
