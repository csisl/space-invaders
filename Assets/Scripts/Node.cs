using UnityEngine;

public class Node : MonoBehaviour {

	/* > do we have something built on top of the current node?
	   > handle user input
	   > has the player pressed this node */

	public Color hoverColor;
	private Color startColor;
	private Renderer rend;
	public Vector3 positionOffset;

	private GameObject turret;

	BuildManager buildManager;

	void Start() {
		rend = GetComponent<Renderer>();
		// sore our start color
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	// when we click the node
	void OnMouseDown(){

		if (buildManager.GetTurretToBuild() == null) {
			return;
		}

		// we have something already built here
		if (turret != null){
			Debug.Log("Cannot build there!");
			return;
		}

		// build a turret on the node
		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

	}

	// hobver animation
	void OnMouseEnter() {
		// every time the mouse passed by this collider, this will be called once 

		if (buildManager.GetTurretToBuild() == null) {
			return;
		}

		// change the color of the node
		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		// change back to the default color
		rend.material.color = startColor;
	}

}
