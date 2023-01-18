using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	private Text scoreText;
	private Text lifeText;

	private int score;
	private int lifeScore;

	void Awake () {
		MakeInstance ();

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		lifeText = GameObject.Find ("LifeText").GetComponent<Text> ();

	}

	void OnEnable() {
		SceneManager.sceneLoaded += LevelFinishedLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= LevelFinishedLoading;
	}

	void LevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Gameplay") {
			if (!GameManager.instance.playerDiedGameRestarted) {
				score = 0;
				lifeScore = 2;
			} else {
				score = GameManager.instance.score;
				lifeScore = GameManager.instance.lifeScore;
			}
			scoreText.text = "x" + score;
			lifeText.text = "x" + lifeScore;
		}
	}
	
	private void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	public void IncrementScore() {
		score++;
		scoreText.text = "x" + score;
	}

	public void DecrementLife() {
		lifeScore--;
		if (lifeScore >= 0) {
			lifeText.text = "x" + lifeScore;
		}
		StartCoroutine (PlayerDied ());
	}

	IEnumerator PlayerDied() {
		yield return new WaitForSeconds (2f);

		if (lifeScore < 0) {
			SceneManager.LoadScene ("MainMenu");
		} else {
			GameManager.instance.playerDiedGameRestarted = true;
			GameManager.instance.score = score;
			GameManager.instance.lifeScore = lifeScore;
			SceneManager.LoadScene ("Gameplay");
		}

	}


} // class








































