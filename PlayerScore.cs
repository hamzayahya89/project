using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public bool isAlive;

	private GameObject gameFinishedText;

	void Awake () {
		isAlive = true;
		gameFinishedText = GameObject.Find ("LevelFinished");
		gameFinishedText.SetActive (false);
	}
	
	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == "Collectable") {
			GameplayController.instance.IncrementScore ();
			target.gameObject.SetActive (false);
		}

		if (target.tag == "Skeleton") {
			if (isAlive) {
				isAlive = false;
				GameplayController.instance.DecrementLife ();
				transform.position = new Vector3(0, 100000, 0);
			}
		}

		if (target.tag == "Exit") {
			gameFinishedText.SetActive (true);
			Time.timeScale = 0f;
		}

	}

} // class










































