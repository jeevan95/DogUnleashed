using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text scoreText;
	private int score;﻿
	public Text restartText;
	public Text gameOverText;
	private bool restart;
	public Text quitText;

	void Start () {
		score = 0;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		quitText.text = "Press 'Q' to Quit";
		UpdateScore ();
	}


	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			} else if (Input.GetKeyDown (KeyCode.Q)) {
				SceneManager.LoadScene ("Main Menu");
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Q)) {
				SceneManager.LoadScene ("Main Menu");
			}
		}
	}

		public void AddScore (int newScoreValue){
			score += newScoreValue;
			UpdateScore();
		}

		void UpdateScore(){
			scoreText.text = "Score: " + score;
		}

		public void GameOver(){
			restartText.text = "Press 'R' to Restart";
			quitText.text = "Press 'Q' for Menu";
			restart = true;
			gameOverText.text = "Game Over";
		}


}
