using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene("Level1");
	}

	public void HelpButton() {
		SceneManager.LoadScene("HelpMenu");
	}

	public void MainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

}
