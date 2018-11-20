using UnityEngine;

public class Node : MonoBehaviour {

	/* > do we have something built on top of the current node?
	   > handle user input
	   > has the player pressed this node */

	public Color hoverColor;
	private Color startColor;
	private Renderer rend;

	private GameObject turret;

	void Start() {
		rend = GetComponent<Renderer>();
		// sore our start color
		startColor = rend.material.color;
	}

	// when we click the node
	void OnMouseDown(){

		// we have something already built here
		if (turret != null){
			Debug.Log("Cannot build there!");
			return;
		}

		// build a turret on the node
		

	}

	// hobver animation
	void OnMouseEnter() {
		// every time the mouse passed by this collider, this will be called once 

		// change the color of the node
		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		// change back to the default color
		rend.material.color = startColor;
	}

}
