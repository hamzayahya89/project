using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void StartGame() {
		GameManager.instance.playerDiedGameRestarted = false;
		SceneManager.LoadScene ("Gameplay");
	}

} // class
