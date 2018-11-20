using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;
	public TurretBlueprint standardTurret;
	public TurretBlueprint laser;
	public TurretBlueprint missile;

	void Start () {
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret() {
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissile() {
		buildManager.SelectTurretToBuild(missile);
	}

	public void SelectLaser() {
		buildManager.SelectTurretToBuild(laser);
	}

}
