using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

	// singleton pattern
	public static BuildManager instance;
	private TurretBlueprint turretToBuild;
	public GameObject standardTurretPrefab;
	public GameObject laserPrefab;
	public GameObject missilePrefab;
	public Text moneyText;

	void Awake() {
		// every time we start the game there will only be one instance of the build manager
		instance = this;
	}

	void Start() {
		moneyText.text = "$" + PlayerStats.money.ToString();
	}

	// public void SetTurretToBuild(GameObject turret){
	// 	// change what turret we want to build
	// 	turretToBuild = turret;
	// }

	public void SelectTurretToBuild(TurretBlueprint turret) {
		turretToBuild = turret;
	}

	public bool CanBuild { get { return turretToBuild != null; } }

	public void BuildTurretOn(Node node) {

		if (PlayerStats.money < turretToBuild.cost){
			// they don't have enough money to build that turret
			return;
		}

		PlayerStats.money -= turretToBuild.cost;
		moneyText.text = "$" + PlayerStats.money.ToString();

		// build on particular node
		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;
	}


}
