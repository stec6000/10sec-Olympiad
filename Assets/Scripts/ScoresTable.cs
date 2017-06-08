using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoresTable : MonoBehaviour {

    public Text player1Score, player2Score;

	void Start () {
        player1Score.text = PlayerPrefs.GetInt("Player1").ToString();
        player2Score.text = PlayerPrefs.GetInt("Player2").ToString();
    }
	
	void Update () {
		
	}

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);

    }

}
