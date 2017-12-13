using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject hudPanel;
	public GameObject resultPanel;
	public Text ScoreText;
	public Text CurrentScoreText;
	public Text BestScoreText;
	public GameObject menu;
	public GameObject isPlay;

	private int score;


	public void Score (){
		score++;
		ScoreText.text = score.ToString ();
	}

	public void ShowResult (){
		hudPanel.SetActive (false);
		resultPanel.SetActive (true);
		menu.SetActive (false);
		CurrentScoreText.text = score.ToString ();

		int bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		BestScoreText.text = bestScore.ToString ();

		if (score > bestScore) {
			PlayerPrefs.SetInt ("BestScore", score);
		}
	}
	public void startGame(){
		menu.SetActive (false);
		isPlay.SetActive (true);
	}
	public void Replay(){
		int state = Application.loadedLevel;
		Application.LoadLevel (state);
	}

}
